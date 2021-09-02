using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            int option, option1;
            string bookName = "Default";
            AddressBookBuilder addressBook = new AddressBookBuilder();

            Console.WriteLine("1. Would you like to work on existing addressbook ? if yes press 1");
            Console.WriteLine("2. Would you like to add  new addressbook ? if yes press 2");
            option1 = Convert.ToInt32(Console.ReadLine());
            switch (option1)
            {
                case 1:
                    addressBook.AddAddressBook(bookName);
                    break;
                case 2:
                    Console.WriteLine("Enter Name Of New Addressbook You want to create : ");
                    bookName = Console.ReadLine();
                    addressBook.AddAddressBook(bookName);
                    break;
            }
            do
            {
                Console.WriteLine($"you are working on {bookName} addressbook ");
                Console.WriteLine("Enter your option :");
                Console.WriteLine("1. Add new contact ");
                Console.WriteLine("2. Display the contacts");
                Console.WriteLine("3. Edit  contacts");
                Console.WriteLine("4. Delete  contacts");
                Console.WriteLine("5. Add new addressbook");
                Console.WriteLine("6. Switch Addressbook");
                Console.WriteLine("7. Search person in a city or State");
                Console.WriteLine("8. Get count of  persons by city or State");
                Console.WriteLine("9. Sort Entries by Person name");
                Console.WriteLine("10.Read or write addressbook contacts using File IO");
                Console.WriteLine("11.Read or write addressbook contacts using CSV file");
                Console.WriteLine("12.Read or write addressbook contacts using Json file");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter First Name :");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name :");
                        string lastName = Console.ReadLine();
                        ContactDetails duplicateCheck = new ContactDetails(firstName, lastName, null, null, null, null, 0, 0);
                        if (addressBook.CheckFor_Duplicate(duplicateCheck, bookName))
                        {
                            break;
                        }
                        Console.WriteLine("Enter Address :");
                        string address = Console.ReadLine();
                        Console.WriteLine("Enter City :");
                        string city = Console.ReadLine();
                        Console.WriteLine("Enter State :");
                        string state = Console.ReadLine();
                        Console.WriteLine("Enter Email :");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter Zip :");
                        int zip = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Phone Number :");
                        long phoneNumber = Convert.ToInt64(Console.ReadLine());
                        addressBook.AddContact(firstName, lastName, address, city, state, email, zip, phoneNumber, bookName);
                        break;
                    case 2:
                        addressBook.DisplayContact(bookName);
                        break;
                    case 3:
                        Console.WriteLine("Enter Full Name of contact which to be edited");
                        string NameToEdit = Console.ReadLine();
                        addressBook.EditContact(NameToEdit, bookName);
                        break;

                    case 4:
                        Console.WriteLine("Enter Full Name of contact which to be deleted");
                        string NameToDelete = Console.ReadLine();
                        addressBook.DeleteContact(NameToDelete, bookName);
                        break;

                    case 5:
                        Console.WriteLine("Enter Name For New AddressBook");
                        string newAddressBook = Console.ReadLine();
                        addressBook.AddAddressBook(newAddressBook);
                        Console.WriteLine("Would you like to Switch to " + newAddressBook);
                        Console.WriteLine("1.Yes \n2.No");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                        {
                            bookName = newAddressBook;
                        }
                        break;
                    case 6:
                        Console.WriteLine("Enter Name Of AddressBook From Below List");
                        foreach (KeyValuePair<string, AddressBookBuilder> item in addressBook.GetAddressBook())
                        {
                            Console.WriteLine(item.Key);
                        }
                        while (true)
                        {
                            bookName = Console.ReadLine();
                            if (addressBook.GetAddressBook().ContainsKey(bookName))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No such AddressBook found. Try Again.");
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine("Would You Like To \n1.Search by city \n2.Search by state");
                        int opt = Convert.ToInt32(Console.ReadLine());
                        switch (opt)
                        {
                            case 1:
                                Console.WriteLine("Enter name of city :");
                                addressBook.SearchPersonByCity(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Enter name of state :");
                                addressBook.SearchPersonByState(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Invalid Input.Enter 1 or 2");
                                break;
                        }
                        break;
                    case 8:
                        addressBook.GetCountByCityOrState(bookName);
                        break;
                    case 9:
                        addressBook.SortEntryByName();
                        break;
                    case 10:
                        ReadandWriteFileIO fileIO = new ReadandWriteFileIO();
                        fileIO.WriteToFile(addressBook.addressBookDictionary);
                        fileIO.ReadFromFile();
                        break;
                    case 11:
                        ReadandWriteCSVFile handler = new ReadandWriteCSVFile();
                        handler.WriteToCsv(addressBook.addressBookDictionary);
                        handler.ReadFromCSV();
                        break;
                    case 12:
                        ReadandWriteJsonFile json = new ReadandWriteJsonFile();
                        json.WriteToFile(addressBook.addressBookDictionary);
                        json.ReadFromFile();
                        break;
                    default:
                        Console.WriteLine("wrong input");
                        break;
                }
                Console.WriteLine("Do you want to continue to The Main Menu?  press 1 if yes,press 0 for Exit");
                option = Convert.ToInt32(Console.ReadLine());
            }
            while (option != 0);

        }
    }
}
