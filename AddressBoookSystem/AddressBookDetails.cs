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
        private List<Contacts> contactList = new List<Contacts>();
        private Dictionary<string, Contacts> addressBook = new Dictionary<string, Contacts>();

        //Method to Add Contact in address book
        public void AddContactDetails(string addbookName, string firstName, string lastName, string address, string city, string state, int zipCode, long phoneNumber, string email)
        {
            Contacts contactDetails = new Contacts(addbookName, firstName, lastName, address, city, state, zipCode, phoneNumber, email);
            this.contactList.Add(contactDetails);
            this.addressBook.Add(addbookName, contactDetails);
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
                Console.WriteLine("No Contacts in AddressBook");
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
            foreach (Contacts Data in this.contactList)
            {
                if (Data.firstName.Equals(dName))
                {
                    this.contactList.Remove(Data);
                    Console.WriteLine("Contact is successfully Deleted");
                    break;
                }
            }
        }
    }
}
