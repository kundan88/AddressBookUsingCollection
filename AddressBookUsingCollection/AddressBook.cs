using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUsingCollection
{
    public class AddressbookEntry
    {
        List<Person> add = new List<Person>();
        public void Show()
        {
            Console.WriteLine("Enter Firstname");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zipcode");
            string zipcode = Console.ReadLine();
            Console.WriteLine("Enter Pincode");
            string pincode = Console.ReadLine();
            add.Add(new Person()
            {
                Firstname = fname,
                Lastname = lname,
                Address = address,
                City = city,
                State = state,
                Zipcode = zipcode,
                Pincode = pincode
            });

            foreach (var per in add)
            {
                Console.WriteLine("-------Person In address book-----------------------------");
                Console.WriteLine("First Name:" + per.Firstname);
                Console.WriteLine("Last Name:" + per.Lastname);
                Console.WriteLine("Address:" + per.Address);
                Console.WriteLine("City:" + per.City);
                Console.WriteLine("State:" + per.State);
                Console.WriteLine("Zipcode:" + per.Zipcode);
                Console.WriteLine("Pincode:" + per.Pincode);
                Console.WriteLine("-----------------------------------------------------------");
            }
        }
       
        // Method to check for duplicate Entry of the same person
        
        public void DuplicateContact()
        {
            Console.Write("Enter How Many contact You want to add?");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine("Press 1 If you want to add a new Contact to the Address Book");
                switch (Console.ReadLine())
                {
                    case "1":
                        for (int j = 0; j < number; j++)
                        {
                            Console.Write("Enter the First Name: ");
                            string fname = Console.ReadLine();
                            Console.WriteLine($"'{fname}' add another name {fname}");
                            if (add.Exists(e => e.Firstname == fname))//used Lambda Expression to check for duplicate entry
                            {
                                
                                Console.WriteLine($" A person having name  '{fname}' exists in our list");
                                
                                Console.ReadKey();
                               
                            }
                            else
                            {
                                Show();
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("The choice is not valid.");
                        break;
                }
            }
        }
    }
}
