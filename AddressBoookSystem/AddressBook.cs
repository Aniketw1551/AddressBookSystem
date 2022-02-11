using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBoookSystem
{
    public class AddressBook
    {
        //created List of class Type
        static AddressBookDetails addressDetails = new AddressBookDetails();
        static Dictionary<string, AddressBookDetails> addressBook = new Dictionary<string, AddressBookDetails>();
        public void ReadInput()
        {
            bool CONTINUE = true;

            //The loop will keep on till user exits from program
            while (CONTINUE)
            {
                Console.WriteLine("Enter your choice: \n");
                Console.WriteLine("1.Add address book 2.Add contact 3.Display details 4.Edit Contact details 5.Delete Contact\n");
                Console.WriteLine("6.Add Multiple Address book 7.Delete Address book 8.Search specific person with city or state name 0.Exit\n");


                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddressBook.AddressBookName();
                        break;
                    case 2:
                        AddDetails(AddressBook.AddBookName(addressBook));
                        break;
                    case 3:
                        addressDetails = AddressBook.AddBookName(addressBook);
                        addressDetails.DisplayContact();
                        break;
                    case 4:
                        addressDetails = AddressBook.AddBookName(addressBook);
                        Console.WriteLine("Enter the first name of person");
                        string ename = Console.ReadLine();
                        addressDetails.EditContact(ename);
                        break;
                    case 5:
                        addressDetails = AddressBook.AddBookName(addressBook);
                        Console.WriteLine("Enter the first name of person");
                        string dname = Console.ReadLine();
                        addressDetails.DeleteContact(dname);
                        break;
                    case 6:
                        AddMultipleAddressBook();
                        break;
                    case 7:
                        Console.WriteLine("Enter name of the address book name you want to delete: ");
                        string addressBookName = Console.ReadLine();
                        addressBook.Remove(addressBookName);
                        break;
                    case 8:
                        AddressBookDetails.SearchPersonWithCityorStateName(addressBook);
                        break;
                    case 0:
                        CONTINUE = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void AddressBookName() //Method for creating address book in dictionary
        {
            Console.WriteLine("Enter name for your address book: ");
            string addressbookname = Console.ReadLine();
            addressBook.Add(addressbookname, addressDetails);
        }
        public static void AddDetails(AddressBookDetails addressDetails)
        {
            Console.WriteLine("Enter first Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zipcode");
            int zipCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Phone Number");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();

            addressDetails.AddContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber, email);
        }

        //Method to Add Multiple Address books
        public void AddMultipleAddressBook()
        {
            Console.WriteLine("Please enter how many address book do you want to add: ");
            int Number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= Number; i++)
            {
                AddressBook.AddressBookName();
            }
            Console.WriteLine("All address book added successfully \n");
        }
        //method to find the address of particular address book
        public static AddressBookDetails AddBookName(Dictionary<string, AddressBookDetails> addBook)
        {
            addressBook = addBook;
            Console.WriteLine("Enter address book name: ");
            string name = Console.ReadLine();
            AddressBookDetails address = addressBook[name];
            return address;
        }
    }
}
