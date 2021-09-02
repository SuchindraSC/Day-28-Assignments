using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AddressBook
{
    class ReadandWriteFileIO
    {
        static string file = @"C:\Users\ADVANCED\Desktop\Day30 TDD\AddressBook\AddressBook\AddressBook.txt";

        public void WriteToFile(Dictionary<string, AddressBookBuilder> addressBookDictionary)
        {
            StreamWriter writer = new StreamWriter(file, true);
            foreach (AddressBookBuilder item in addressBookDictionary.Values)
            {
                foreach (ContactDetails contact in item.addressBook.Values)
                {
                    writer.WriteLine(contact.ToString());
                }
            }
            Console.WriteLine("\nSuccessfully added to Text file.");
            writer.Close();
        }
        public void ReadFromFile()
        {
            Console.WriteLine(File.ReadAllText(file));
        }
    }
}
