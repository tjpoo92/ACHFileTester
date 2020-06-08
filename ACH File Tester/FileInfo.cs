using System;
using System.Collections.Generic;

namespace ACH_File_Tester
{
    public class FileInfo
    {

        public static void FileInfoType(Dictionary<int, string> fileLine)
        {
            Console.Clear();
            Console.WriteLine("Would you like to go line by line or all at once?\n1 Line by line\n2 All at once");
            string Response = Console.ReadLine();

            if (Response == "1")
            {
                RecordTypeLineByLine(fileLine);
            }
            if (Response == "2")
            {
                RecordTypeAllAtOnce(fileLine);
            }
            //Would like to handle the exception right now this causes a loop when entering 1, ends after performing 2
            //else
            //{
            //    FileInfoType(fileLine);
            //}
        }

        static void RecordTypeLineByLine(Dictionary<int, string> fileLine)
        {
            Console.Clear();

            foreach (var v in fileLine)
            {
                string value = v.Value.ToString();


                switch (value.Substring(0, 1))
                {
                    case "1":
                        FileHeader(value);
                        Console.ReadLine();
                        break;
                    case "5":
                        BatchHeader(value);
                        Console.ReadLine();
                        break;
                    case "6":
                        EntryDetailRecord(value);
                        Console.ReadLine();
                        break;
                    case "7":
                        EntryDetailAddendaRecord(value);
                        Console.ReadLine();
                        break;
                    case "8":
                        BatchControlRecord(value);
                        Console.ReadLine();
                        break;
                    case "9":
                        FileControlRecord(value);
                        Console.ReadLine();
                        break;


                }


            }
        }
        static void RecordTypeAllAtOnce(Dictionary<int, string> fileLine)
        {
            Console.Clear();

            foreach (var v in fileLine)
            {
                string value = v.Value.ToString();


                switch (value.Substring(0, 1))
                {
                    case "1":
                        FileHeader(value);
                        Console.WriteLine();
                        break;
                    case "5":
                        BatchHeader(value);
                        Console.WriteLine();
                        break;
                    case "6":
                        EntryDetailRecord(value);
                        Console.WriteLine();
                        break;
                    case "7":
                        EntryDetailAddendaRecord(value);
                        Console.WriteLine();
                        break;
                    case "8":
                        BatchControlRecord(value);
                        Console.WriteLine();
                        break;
                    case "9":
                        FileControlRecord(value);
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void FileHeader(string line)
        {
            if (line.Substring(0, 1) == "1")
            {
                Console.WriteLine(line);
                Console.WriteLine("This is the File Header");
                Dictionary<string, string> fileHeader = new Dictionary<string, string>
                {
                    {"Immediate Destination", line.Substring(3, 10).Trim()},
                    {"Immediate Origin", line.Substring(13, 10).Trim()},
                    {"File Creation Date (YYMMDD)", line.Substring(23, 6).Trim()},
                    {"Immediate Destination Name",  line.Substring(40, 23).Trim()},
                    {"Immediate Origin Name", line.Substring(63, 23).Trim()}
                };
                foreach (KeyValuePair<string, string> kvp in fileHeader)
                {
                    Console.WriteLine("{0, -30} {1, 15}", kvp.Key, kvp.Value);
                };
            }
            else Console.WriteLine("This is not a File Header");
        }

        static void BatchHeader(string line)
        {
            if (line.Substring(0, 1) == "5")
            {
                Console.WriteLine(line);
                Console.WriteLine("This is the Batch Header");
                Dictionary<string, string> batchHeader = new Dictionary<string, string>
                {
                    { "Service Class Code", line.Substring(1, 3).Trim() },
                    { "Company Name", line.Substring(4, 16).Trim() },
                    { "Company Identification", line.Substring(40, 10).Trim() },
                    { "Standard Entry Class Code", line.Substring(50, 3).Trim() },
                    { "Company Entry Description", line.Substring(53, 10).Trim() },
                    { "Effective Entry Date (YYMMDD)", line.Substring(69, 6).Trim() },
                    { "Originating DFI Identification", line.Substring(79, 8).Trim() }
                };
                foreach (KeyValuePair<string, string> kvp in batchHeader)
                {
                    Console.WriteLine("{0,-30} {1,15}", kvp.Key, kvp.Value);
                };
            }
            else Console.WriteLine("This is not a Batch Header");
        }

        static void EntryDetailRecord(string line)
        {
            if (line.Substring(0, 1) == "6")
            {
                Console.WriteLine(line);
                Console.WriteLine("This is an Entry Detail Record");
                Dictionary<string, string> entryDetailRecord = new Dictionary<string, string>
                {
                    { "Transaction Code", line.Substring(1, 2).Trim() },
                    { "Receiving DFI Identification", line.Substring(3, 8).Trim() },
                    { "DFI Account Number", line.Substring(12, 17).Trim() },
                    { "Amount", line.Substring(29, 10).Trim() }, //look at formatting as currency
                    { "Individual Name", line.Substring(54, 22).Trim() },
                    { "Trace Number", line.Substring(79, 15).Trim() },

                };
                foreach (KeyValuePair<string, string> kvp in entryDetailRecord)
                {
                    Console.WriteLine("{0,-30} {1,15}", kvp.Key, kvp.Value);
                };
            }
            else Console.WriteLine("This is not an Entry Detail Record");
        }

        private static void EntryDetailAddendaRecord(string line)
        {
            if (line.Substring(0, 1) == "7")
            {
                Console.WriteLine(line);
                Console.WriteLine("This is an Entry Detail Addenda Record");
                Dictionary<string, string> entryDetailAddendaRecord = new Dictionary<string, string>
                {
                    { "Addenda Type Code", line.Substring(1, 2).Trim() },
                    { "Payment Related Information", line.Substring(3, 80).Trim() },
                    { "Addenda Sequence Number", line.Substring(83, 4).Trim() },
                    { "Entry Detail Sequence Number", line.Substring(29, 10).Trim() },

                };
                foreach (KeyValuePair<string, string> kvp in entryDetailAddendaRecord)
                {
                    Console.WriteLine("{0,-30} {1,15}", kvp.Key, kvp.Value);
                };
            }
            else Console.WriteLine("This is not an Entry Detail Addenda Record");
        }

        private static void BatchControlRecord(string line)
        {
            if (line.Substring(0, 1) == "8")
            {
                Console.WriteLine(line);
                Console.WriteLine("This is an Batch Control Record");
                Dictionary<string, string> batchControlRecord = new Dictionary<string, string>
                {
                    { "Service Class Code", line.Substring(1, 3).Trim() },
                    { "Entry / Addenda Count", line.Substring(4, 6).Trim() },
                    { "Entry Hash", line.Substring(10, 10).Trim() },
                    { "Total Debit Entry Dollar Amount", line.Substring(20, 12).Trim() }, //look at formatting as currency
                    { "Total Credit Entry Dollar Amount", line.Substring(32, 12).Trim() },
                    { "Company Identification", line.Substring(44, 10).Trim() },
                    { "Originating DFI Identification", line.Substring(79, 8).Trim() },
                    { "Batch Number", line.Substring(87, 7).Trim() }

                };
                foreach (KeyValuePair<string, string> kvp in batchControlRecord)
                {
                    Console.WriteLine("{0,-30} {1,15}", kvp.Key, kvp.Value);
                };
            }
            else Console.WriteLine("This is not an Batch Control Record");
        }

        private static void FileControlRecord(string line)
        {
            if (line.Substring(0, 1) == "9" && line.Substring(1, 1) != "9")
            {
                Console.WriteLine(line);
                Console.WriteLine("This is the File Control Record");
                Dictionary<string, string> fileControlRecord = new Dictionary<string, string>
                { //formatting to remove leading zeros and currency
                    { "Batch Count", line.Substring(1, 6).Trim() },
                    { "Block Count", line.Substring(7, 6).Trim() },
                    { "Entry / Addenda Count", line.Substring(13, 8).Trim() },
                    { "Entry Hash", line.Substring(21, 10).Trim() },
                    { "Total Debit Entry Dollar Amount in File", line.Substring(31, 12).Trim() },
                    { "Total Credit Entry Dollar Amount in File", line.Substring(43, 12).Trim() }
                };
                foreach (KeyValuePair<string, string> kvp in fileControlRecord)
                {
                    Console.WriteLine("{0,-30} {1,15}", kvp.Key, kvp.Value); //more formatting to fix
                };
            }
            else if (line.Substring(0, 1) == "9" && line.Substring(1, 1) == "9")
            {
                Console.WriteLine(line);
                Console.WriteLine("This is the File Control Record");
            }
            else Console.WriteLine("This is not a File Control Record");
        }
    }
}
