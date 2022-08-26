
using System.Globalization;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AddressBookUsingCollection
{
    class AddressBookCollection
    {
        public Dictionary<string, AddressBook> addressBookDictionary;//Dictionary collection
        public Dictionary<string, List<Person>> cityDictionary;
        public Dictionary<string, List<Person>> stateDictionary;

        public AddressBookCollection()
        {
            addressBookDictionary = new Dictionary<string, AddressBook>();
        }
        public void PrintAllAddressBookNames()
        {
            foreach (var AddressBookItem in addressBookDictionary)
            {
                Console.WriteLine(AddressBookItem.Key);
            }
        }
        public void SearchPersonInCityOrState(string firstName, string lastName)
        {
            foreach (var addressBookEntry in addressBookDictionary)
            {
                List<Person> PersonInCitiesOrStates = addressBookEntry.Value.addressBook.FindAll(i => (i.firstName == firstName) && (i.lastName == lastName));
                foreach (Person person in PersonInCitiesOrStates)
                {
                    Console.WriteLine($" {person.firstName} {person.lastName} is in {person.city} {person.state}");
                }
            }
        }
        public void ViewPersonByCityOrState(string city, string state)
        {
            foreach (var addressBookEntry in addressBookDictionary)
            {
                List<Person> PersonInCitiesOrStates = addressBookEntry.Value.addressBook.FindAll(i => (i.city == city) && (i.state == state));
                foreach (Person person in PersonInCitiesOrStates)
                {
                    Console.WriteLine($" {person.city} {person.state} is in {person.city} {person.state}");
                }
            }
        }
        public void ViewCountByCityOrState(string city, string state)
        {
            foreach (var addressBookEntry in addressBookDictionary)
            {
                List<Person> ViewCountByCityOrState = addressBookEntry.Value.addressBook.FindAll(i => (i.city == city) && (i.state == state));
                foreach (Person person in ViewCountByCityOrState)
                {
                    Console.WriteLine($"Total person in {city} are : " + ViewCountByCityOrState.Count);
                }
            }
        }


        /// <summary>
        /// UC15:Ability to Read or Write the Address Book with Persons Contact as JSON File
        /// </summary>
        public void WriteAddressBookCollectionFromJsonFiles()
        {
            string folderPath = @"C:\Users\DELL\Desktop\Assignment\AddressBookUsingCollection\AddressBookUsingCollection10\";
            foreach (var AddressBookItem in addressBookDictionary)
            {
                string filePath = folderPath + AddressBookItem.Key + ".json";
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter writer = new StreamWriter(filePath))
                using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(writer, AddressBookItem.Value.addressBook);
                }
            }
        }
        public void ReadAddressBookCollectionFromJsonFiles()
        {
            string folderPath = @"C:\Users\DELL\Desktop\Assignment\AddressBookUsingCollection\AddressBookUsingCollection10\Employee.json";
            string result = File.ReadAllText(folderPath);
            List<Person> contactDetails = JsonConvert.DeserializeObject<List<Person>>(result);
            Console.WriteLine("Successfully read records from the file" + contactDetails);
            Console.WriteLine(result);
        }

    }
}
