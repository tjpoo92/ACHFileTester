using System;
using System.Collections.Generic;


namespace ACH_File_Tester
{
    public class ErrorSearch
    {
        public static void ErrorSearchStart(Dictionary<int, string> fileLine)
        {
            LineLengthError(fileLine);
            MissingRequiredHeader(fileLine);

        }
        static void LineLengthError(Dictionary<int, string> fileLine)
        {
            //Console.Clear();
            foreach (var v in fileLine)
            {
                string value = v.Value.ToString();

                if (value.Length != 94)
                {
                    Console.WriteLine("Invalid line length, Line Number: " + v.Key);
                    Console.WriteLine("{0}", fileLine[10]);
                }
            };
        }
        static void MissingRequiredHeader(Dictionary<int,string> fileLine)
        {
            List<string> headers = new List<string>();
            string message = null;
            foreach (var v in fileLine)
            {
                string value = v.Value.ToString();
                switch (value.Substring(0,1))
                {
                    case "1":
                        message += "File Header present\n";
                        headers.Add("1");
                        break;
                    case "5":
                        message += "Batch Header present\n";
                        headers.Add("5");
                        break;
                    case "6":
                        message += "Entry Detail Record present\n";
                        headers.Add("6");
                        break;
                    case "8":
                        message += "Batch Control Total present\n";
                        headers.Add("8");
                        break;
                    case "9":
                        message += "File Control Record present\n";
                        headers.Add("9");
                        break;

                }
                Console.WriteLine(message);
            }
        }
    }
}

