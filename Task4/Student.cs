using System;
using System.IO;
using System.Text;

namespace Task4
{
    class Student
    {
        string parseText;
        public string url = "C:/Users/mosre/Downloads/Students.dat";
        public void ReadValues()
        {
            if (File.Exists(url))
            {
                
                using (BinaryReader br = new BinaryReader(File.Open(url, FileMode.Open)))
                {
                  
                    var myString = Encoding.Default.GetString(br.ReadBytes(4096));
                    parseText = myString;
                }

                Console.WriteLine(parseText);
            }

        }
    }
}
