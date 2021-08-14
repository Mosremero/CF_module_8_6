using System;
using System.IO;
namespace Task1
{
    class FolderOper
    {
        public FolderOper(string FolderName)
        {
            this.FolderName = FolderName;
        }
        public string FolderName { get; set; }


        public void FolderAndFileDelete(int waitMinutes)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);
            if (dir.Exists)
            {
                string[] entries = Directory.GetFileSystemEntries(FolderName, "*", SearchOption.AllDirectories);
                int cntDeleteFiles = 0;
                int countFilesInFolder = 0;

                foreach (string e in entries)
                {
                    try
                    {
                        var d = new DirectoryInfo(e);
                        var f = new FileInfo(e);

                        //если выполнено условие для удаления
                        if (IsTrueTimeForDelete(e, 30))
                        {
                            if (d.Exists)
                            {
                                countFilesInFolder = d.GetFiles().Length;
                                //если кол-во файлов в папке = 0, то можно удалять папку
                                if (countFilesInFolder == 0)
                                {
                                    d.Delete();
                                    cntDeleteFiles += 1;
                                    Console.WriteLine("Удалена директория по следующиму пути: {0}", e);
                                }
                                countFilesInFolder = 0;
                            }
                            if (f.Exists)
                            {
                                f.Delete();
                                cntDeleteFiles += 1;
                                Console.WriteLine("Удален файл по следующему пути: {0}", e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Папка/директория {0} не удалена", e);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("При обработке файла/папки возникла ошибка: {0}", ex.Message);
                    }
                }
                if (cntDeleteFiles > 0)
                {
                    Console.WriteLine("Удалено {0} файлов/папок", cntDeleteFiles);
                }
                else
                {
                    Console.WriteLine("Нет удаленных файлов. Не выполнено условие для удаления (30 минут после последнего открытия/изменения)");
                }
            }
            else
            {
                Console.WriteLine("Первоначально указанная папка по пути {0} не существует", FolderName);
            }
        }

        public bool IsTrueTimeForDelete(in string dirPath, in int waitMinutes)
        {
            
            DateTime fileTime;
            //если есть ".", то смотрим на дату создания директории, иначе на время последнего доступа к файлу
            if (dirPath.Contains("."))
            {
                fileTime = File.GetLastAccessTime(dirPath);
            }
            else
            {
                fileTime = File.GetCreationTime(dirPath);
            }

            DateTime endTime = DateTime.Now;

            //возвраем true, если прошло более 30 минут с момента создания директории/доступа к файлу
            if ((endTime - fileTime).TotalMinutes >= waitMinutes)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

    }
}
