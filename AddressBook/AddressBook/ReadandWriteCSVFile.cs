using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Globalization;
using CsvHelper;

namespace AddressBook
{
    class ReadandWriteCSVFile
    {
        string importFilePath = @"C:\Users\ADVANCED\Desktop\Day30 TDD\AddressBook\AddressBook\AddressBook.csv";
        //string exportFilePath = @""
        public void WriteToCsv(Dictionary<string, AddressBookBuilder> addressbookDictionary)
        {
            using (StreamWriter writer = new StreamWriter(importFilePath))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (AddressBookBuilder item in addressbookDictionary.Values)
                    {
                        List<ContactDetails> contactRecord = item.addressBook.Values.ToList();
                        csv.WriteRecords(contactRecord);
                    }
                }
            }
        }
        public void ReadFromCSV()
        {
            using (StreamReader reader = new StreamReader(importFilePath))
            {
                using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    Console.WriteLine("Below are Contents of CSV File");
                    List<ContactDetails> contactRecord = csv.GetRecords<ContactDetails>().ToList();
                    foreach (ContactDetails contact in contactRecord)
                    {
                        Console.WriteLine(contact.ToString());
                    }
                }
            }
        }
    }
}
