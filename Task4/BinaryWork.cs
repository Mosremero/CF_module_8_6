using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Task4
{
    class BinaryWork
    {
        const string inputPath = "C:/Users/mosre/Downloads/Students.bin";
        const string outputPath = "C:/Users/mosre/Downloads/Students";

        static void Main()
        {
            Student student = new Student();
            student.ReadValues();
        }

    }
}
