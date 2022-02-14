using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBoookSystem
{
    public class AddressBookDetails
    {
        //Collection Class
        private List<Contacts> contactList;
        private List<Contacts> cityList;
        private List<Contacts> stateList;
        public AddressBookDetails()
        {
            this.contactList = new List<Contacts>();
        }
        //Method to Add Contact in address book
        public void AddContactDetails(string firstName, string lastName, string address, string city, string state, int zipCode, long phoneNumber, string email, Dictionary<string, List<Contacts>> stateDictionary, Dictionary<string, List<Contacts>> cityDictionary)
        {
            // finding the data that already has the same first name
            Contacts contact = this.contactList.Find(x => x.firstName.Equals(firstName));
            if (contact == null) // using if condition to add contact if not present 
            {
                Contacts contactDetails = new Contacts(firstName, lastName, address, city, state, zipCode, phoneNumber, email);
                this.contactList.Add(contactDetails);
                if (!cityDictionary.ContainsKey(city))
                {
                    cityList = new List<Contacts>();
                    cityList.Add(contactDetails);
                    cityDictionary.Add(city, cityList);
                }
                else
                {
                    List<Contacts> cities = cityDictionary[city];
                    cities.Add(contactDetails);
                }
                if (!stateDictionary.ContainsKey(state))
                {
                    stateList = new List<Contacts>();
                    stateList.Add(contactDetails);
                    stateDictionary.Add(state, stateList);
                }
                else
                {
                    List<Contacts> states = stateDictionary[state];
                    states.Add(contactDetails);
                }
            }
            else
            {
                Console.WriteLine("Person {0} is already exist in the address book", firstName); //printing message if person name is already in address book

            }
        }
        //Method to Display Contact in address book
        public void DisplayContact()
        {

            if (this.contactList.Count != 0)  //checking ContactList is empty or not
            {
                foreach (Contacts data in this.contactList)
                {
                    data.Display();
                }
            }
            else
                Console.WriteLine("No Contacts in AddressBook\n");
        }
        //Method to get contacts 
        public List<Contacts> getContacts()
        {
            if (contactList.Count == 0)
                return null;
            else
                return contactList;
        }
        public void EditContact(string ename) //Method to Edit Contact 
        {
            // checks for every object whether the name is equal to the given name
            foreach (Contacts data in this.contactList)
            {
                if (data.firstName.Equals(ename))
                {
                    Console.WriteLine("Enter your choice:");
                    Console.WriteLine("1. Last Name");
                    Console.WriteLine("2. Address");
                    Console.WriteLine("3. City");
                    Console.WriteLine("4. State");
                    Console.WriteLine("5. Zip");
                    Console.WriteLine("6. Phone Number");
                    Console.WriteLine("7. Email");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            data.lastName = Console.ReadLine();
                            Console.WriteLine("Last name updated successfully");
                            break;
                        case 2:
                            data.address = Console.ReadLine();
                            Console.WriteLine("Address updated successfully");
                            break;
                        case 3:
                            data.city = Console.ReadLine();
                            Console.WriteLine("City updated successfully");
                            break;
                        case 4:
                            data.state = Console.ReadLine();
                            Console.WriteLine("State updated successfully");
                            break;
                        case 5:
                            data.zipCode = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Zipcode updated successfully");
                            break;
                        case 6:
                            data.phoneNumber = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Phonenumber updated successfully");
                            break;
                        case 7:
                            data.email = Console.ReadLine();
                            Console.WriteLine("Email updated successfully");
                            break;
                        default:
                            Console.WriteLine("Please check your choice");
                            break;
                    }
                }
                else
                    Console.WriteLine("Error,No Contact With this Name");
            }
        }
        //Method to Delete a contact deatils of person
        public void DeleteContact(string dName)
        {
            foreach (Contacts c in this.contactList)
            {
                if (c.firstName.Equals(dName))
                {
                    this.contactList.Remove(c);
                    Console.WriteLine("Contact is successfully Deleted");
                    break;
                }
            }
        }
        // Method to search person by city or state name
        public static void SearchPersonWithCityorStateName(Dictionary<string, AddressBookDetails> addressDictionary)
        {
            List<Contacts> list = null;
            Console.WriteLine("Enter City or State name to search specific person");
            string name = Console.ReadLine();
            foreach (var data in addressDictionary)
            {
                AddressBookDetails address = data.Value;
                list = address.contactList.FindAll(a => a.city.Equals(name) || a.state.Equals(name));
                if (list.Count > 0)
                {
                    DisplayList(list);
                }
            }
            if (list == null)
            {
                Console.WriteLine("No person is present in the address book with same city or state name");
            }
        }
        //Method to display the data in the list 
        public static void DisplayList(List<Contacts> list)
        {
            foreach (var data in list)
            {
                data.Display();
            }
        }
        // Method to display the details  of person by city or state
        public static void PrintCityandStateList(Dictionary<string, List<Contacts>> dictionary)
        {
            foreach (var data in dictionary)
            {
                Console.WriteLine("Details of a person in {0}", data.Key);
                foreach (var p in data.Value)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", p.firstName, p.lastName, p.address,
                                                                   p.city, p.state, p.zipCode, p.phoneNumber, p.email);
                }
                Console.WriteLine("\n");
            }
        }
        // Method to get no of person by city or state
        public static void CountofPerson(Dictionary<string, List<Contacts>> dictionary, string name)
        {
            if (dictionary.ContainsKey(name))
            {
                foreach (var p in dictionary)
                {
                    Console.WriteLine("Number of person/s {0}:", p.Value.Count);
                    break;
                }
            }
        }
        // Method to sort the data by zipcode,city and state
        public static void SortData(Dictionary<string, List<Contacts>> dictionary)
        {
            //storing the result in the list and displaying the result
            List<Contacts> list = new List<Contacts>();
            foreach (var data in dictionary)
            {
                foreach (var item in data.Value)
                {
                    list.Add(item);
                }
            }
            Console.WriteLine("\nDisplaying the person list based on City: ");
            //display the sorted value based on city
            foreach (var item in list.OrderBy(detail => detail.city))
            {
                item.Display();
            }
            Console.WriteLine("\nDisplaying the person list based on state: ");
            //display the sorted value based on state
            foreach (var item in list.OrderBy(detail => detail.state))
            {
                item.Display();
            }
            Console.WriteLine("\nDisplaying the person list based on ZipCode: ");
            //display the sorted value based on zipCode
            foreach (var item in list.OrderBy(detail => detail.zipCode))
            {
                item.Display();
            }
        }
    }
}