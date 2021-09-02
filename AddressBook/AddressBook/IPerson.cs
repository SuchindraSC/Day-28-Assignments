using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    interface IPerson
    {
        public void AddContact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNumber, string bookName);
        public void EditContact(string name, string bookName);
        public void DeleteContact(string deletename, string bookName);
        public void AddAddressBook(string bookName);
        public void DisplayContact(string bookName);
    }
}
