using System;
using System.IO;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "C:/Users/mosre/Documents/folderDeleteTest";
            Console.WriteLine("Размер папки {0} и входяших в нее файлов на диске: {1}", url, folderSizeByte(url));
           // Console.WriteLine(folderSizeByte("C:/Users/mosre/Documents/folderDeleteTest"));

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
