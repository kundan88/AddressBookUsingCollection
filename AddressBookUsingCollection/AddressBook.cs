﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUsingCollection
{
    public class AddressBook
    {
        public List<Person> addressBook;
        public AddressBook()
        {
            addressBook = new List<Person>();
        }

        public void AddAddressBookEntry(Person person)
        {
            addressBook.Add(person);
        }
        public void AddAddressBookEntry()
        {
            Person personEntered = new Person();
            Console.WriteLine("Enter First name");
            personEntered.firstName = Console.ReadLine();
            Console.WriteLine("Enter Last name");
            personEntered.lastName = Console.ReadLine();
            if (addressBook.Find(i => personEntered.Equals(i)) != null)
            {
                Console.WriteLine("Person already Exists, enter new person!");
                return;
            }
            Console.WriteLine("Enter Address");
            personEntered.address = Console.ReadLine();
            Console.WriteLine("Enter City");
            personEntered.city = Console.ReadLine();
            Console.WriteLine("Enter State");
            personEntered.state = Console.ReadLine();
            Console.WriteLine("Enter Zip");
            personEntered.zip = Console.ReadLine();
            Console.WriteLine("Enter phoneNumber");
            personEntered.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email");
            personEntered.email = Console.ReadLine();
            addressBook.Add(personEntered);
        }
        public void DisplayNamesInAddresBook()
        {
            if (addressBook.Count == 0)
            {
                Console.WriteLine("No Names to Display");
            }
            foreach (Person person in addressBook)
            {
                person.DisplayPerson();
            }
        }

        public void EditContact(string firstName, string lastName)
        {
            int index = 0;
            bool found = false;
            foreach (Person person in addressBook)
            {
                if (person.firstName == firstName && person.lastName == lastName)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if (found)
            {
                Console.WriteLine("Enter First name");
                addressBook[index].firstName = Console.ReadLine();
                Console.WriteLine("Enter Last name");
                addressBook[index].lastName = Console.ReadLine();
                Console.WriteLine("Enter Address");
                addressBook[index].address = Console.ReadLine();
                Console.WriteLine("Enter City");
                addressBook[index].city = Console.ReadLine();
                Console.WriteLine("Enter State");
                addressBook[index].state = Console.ReadLine();
                Console.WriteLine("Enter Zip");
                addressBook[index].zip = Console.ReadLine();
                Console.WriteLine("Enter phoneNumber");
                addressBook[index].phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter Email");
                addressBook[index].email = Console.ReadLine();
            }
            else
                Console.WriteLine("Entry Not found for the name");
        }
        /// <summary>
        /// UC7:
        /// </summary>
        public void DeleteContact(string firstName, string lastName)
        {
            int index = 0;
            bool found = false;
            foreach (Person person in addressBook)
            {
                if (person.firstName == firstName && person.lastName == lastName)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if (found)
                addressBook.Remove(addressBook[index]);
            else
                Console.WriteLine("Entry Not found");
        }
        /// <summary>
        /// UC11:Ability to sort the entries in the address book alphabetically by Person’s name
        /// </summary>
        public void SortByPersonName()
        {
            addressBook.Sort((x, y) => x.firstName.CompareTo(y.firstName));
        }
        /// <summary>
        /// UC12:Ability to sort the entries in the address book by City, tate, or Zip
        /// </summary>
        public void SortByCityStateZip()
        {
            Console.WriteLine("select sort by");
            Console.WriteLine("1 for sort by city");
            Console.WriteLine("2 for sort by state");
            Console.WriteLine("3 for sort by zip");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    SortByCity();
                    break;
                case 2:
                    SortByState();
                    break;
                case 3:
                    SortByZip();
                    break;
                default:
                    Console.WriteLine("invalid");
                    break;
            }
        }
        public void SortByCity()
        {
            addressBook.Sort((x, y) => x.city.CompareTo(y.city));
        }
        public void SortByState()
        {
            addressBook.Sort((x, y) => x.state.CompareTo(y.state));
        }
        public void SortByZip()
        {
            addressBook.Sort((x, y) => x.zip.CompareTo(y.zip));
        }
    }
}
