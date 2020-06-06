using System;
using System.Collections.Generic;
using System.IO;

namespace ACH_File_Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Please enter the file path for your NACHA formatted ACH file (.txt format only):");

            string FilePath = "ACH.txt"; //Console.ReadLine();
            var sr = new StreamReader(FilePath);
            string line;
            int LineNumber = 0;
            Dictionary<int, string> fileLine = new Dictionary<int, string>();


            while ((line = sr.ReadLine()) != null)
            {
                LineNumber++;
                fileLine.Add(LineNumber, line);
            }
            Console.WriteLine("Please choose an option:\n1 File Info\n2 Error Search");
            string Response = Console.ReadLine();
            switch (Response)
            {
                case "1":
                    FileInfo.FileInfoType(fileLine);
                    break;
                case "2":
                    ErrorSearch.ErrorSearchStart(fileLine);
                    break;
            }
            Console.ReadLine();
        }

           

        
        
    }
}


