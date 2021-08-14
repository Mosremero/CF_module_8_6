using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            FolderOper folder = new FolderOper("C:/Users/mosre/Documents/folderDeleteTest");
            folder.FolderAndFileDelete(30);
        }
    }
}
