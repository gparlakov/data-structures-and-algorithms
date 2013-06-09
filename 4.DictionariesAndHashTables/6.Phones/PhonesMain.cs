using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phones
{
    class PhonesMain
    {
        const string RecordsFile = "..\\..\\phones.txt";
        const string CommandsFile = "..\\..\\commands.txt";

        static void Main()
        {
            var input = ReadInputFrom(RecordsFile);
            var records = new PhoneRecords();
            AddRecords(input, records);

            var commands = ReadInputFrom(CommandsFile);

            CommandsExecute(commands, records);    
        }

        private static void CommandsExecute(string[] commands, PhoneRecords records)
        {
            
            foreach (var command in commands)
            {
                IEnumerable<PhoneRecord> commandOutput;
                var nameTown = ExtractArguments(command);
                if (nameTown.Length > 1)
                {
                    var name = nameTown[0].Trim();
                    var town = nameTown[1].Trim();
                    commandOutput = records.Find(name, town);
                }
                else
                {
                    var name = nameTown[0];
                    commandOutput = records.Find(name);
                }

                PrintOutRecords(commandOutput);
                Console.WriteLine("********************");
            }
        }
  
        private static string[]  ExtractArguments(string command)
        {
            var regexp = new Regex(@"\((.+)\)");
            var args = regexp.Match(command);
            
            var arguments = args.Groups[1].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return arguments;
        }

        private static void PrintOutRecords(IEnumerable<PhoneRecord> records)
        {
            foreach (var rec in records)
            {
                Console.WriteLine(rec.Record);
            }
        }

        private static void AddRecords(string[] input, PhoneRecords records)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var nextRecord = new PhoneRecord(input[i]);
                records.Add(nextRecord);
            }
        }

        private static string[] ReadInputFrom(string file)
        {
            StreamReader fileReader = new StreamReader(file);
            string content;
            using (fileReader)
            {
                content = fileReader.ReadToEnd();
            }

            string[] contentLines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return contentLines;
        }
    }
}
