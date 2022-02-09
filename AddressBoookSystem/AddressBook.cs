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
        AddressBookDetails addressDetail = new AddressBookDetails();
        public void ReadInput()
        {
            bool CONTINUE = true;

            //The loop will keep on till user exits from program
            while (CONTINUE)
            {
                Console.WriteLine("Enter your choice: \n");
                Console.WriteLine("1.Add contact 2.Display 3.Edit Contact 4.Delete Contact 5.Add Multiple Contacts 0.Exit \n");


                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddDetails(addressDetail);
                        break;
                    case 2:
                        addressDetail.DisplayContact();
                        break;
                    case 3:
                        Console.WriteLine("Enter the first name of person: ");
                        string ename = Console.ReadLine();
                        addressDetail.EditContact(ename);
                        break;
                    case 4:
                        Console.WriteLine("Enter the first name of person: ");
                        string dName = Console.ReadLine();
                        addressDetail.DeleteContact(dName);
                        break;
                    case 5:
                        AddMultipleContacts();
                        break;
                    case 0:
                        CONTINUE = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void AddDetails(AddressBookDetails addressDetail)
        {
            Console.WriteLine("Give a name to your address book");
            string addbookName = Console.ReadLine();
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

            addressDetail.AddContactDetails(addbookName, firstName, lastName, address, city, state, zipCode, phoneNumber, email);
        }

        
        //Method to Add Multiple Contacts
        public void AddMultipleContacts()
        {
            Console.WriteLine("Please enter how many contact do you want to add");
            int Number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= Number; i++)
            {
                AddressBook.AddDetails(addressDetail);
            }
            Console.WriteLine("All contacts added successfully \n");
        }
    }
}
    

