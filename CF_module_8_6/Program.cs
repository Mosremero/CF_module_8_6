using System;
using System.IO;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string url = "C:/Users/mosre/Documents/folderDeleteTest";
            long befLength;
            long aftLength;
            FolderOper folder = new FolderOper(url);
            befLength = folderSizeByte(folder.FolderName);
            Console.WriteLine("До очистки папка {0} весит: {1} байт", url, befLength);
            //очистка
            folder.FolderAndFileDelete(30);
            aftLength = folderSizeByte(folder.FolderName);
            Console.WriteLine("После очистки папки {0} весит: {1} байт. Удалено: {2} байт", url, aftLength, befLength - aftLength);

        }
        static long folderSizeByte(string url)
        {
            DirectoryInfo di = new DirectoryInfo(url);
            try
            {
                if (di.Exists)
                {
                    return di.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
                }
                else
                {
                    Console.WriteLine("Папка не существует");
                    return 0;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при подсчете", ex.Message);
                return 0;
            }


        }
    }
}
