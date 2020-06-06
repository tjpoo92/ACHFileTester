using System;
using System.Collections.Generic;


namespace ACH_File_Tester
{
    public class ErrorSearch
    {
        public static void ErrorSearchStart(Dictionary<int, string> fileLine)
        {
            LineLengthError(fileLine);

        }
        static void LineLengthError(Dictionary<int, string> fileLine)
        {
            Console.Clear();
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
    }
}

