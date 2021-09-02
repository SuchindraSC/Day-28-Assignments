using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using CsvHelper;

namespace AddressBook
{
    class ReadandWriteJsonFile
    {
        string filePath = @"C:\Users\ADVANCED\Desktop\Day30 TDD\AddressBook\AddressBook\AddressBook.json";
        public void WriteToFile(Dictionary<string, AddressBookBuilder> addressBookDictionary)
        {
            foreach (AddressBookBuilder obj in addressBookDictionary.Values)
            {
                foreach (ContactDetails contact in obj.addressBook.Values)
                {
                    string json = JsonConvert.SerializeObject(contact);
                    File.WriteAllText(filePath, json);
                }
            }
            Console.WriteLine("\nSuccessfully added to JSON file.");
        }
        public void ReadFromFile()
        {
            ContactDetails contact = JsonConvert.DeserializeObject<ContactDetails>(File.ReadAllText(filePath));
            Console.WriteLine(contact.ToString());
        }
    }
}
