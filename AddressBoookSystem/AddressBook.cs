using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBoookSystem
{
    public class AddressBook
    {
        AddressBookDetails addressDetail = new AddressBookDetails();
        //created List of class Type
        public void ReadInput()
        {
            bool CONTINUE = true;

            //The loop will keep on till user exits from program
            while (CONTINUE)
            {
                Console.WriteLine("Enter your choice:");
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
                        string name = Console.ReadLine();
                        addressDetail.EditContact(name);
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
        /// <summary>
        /// This method is used to add a new contact
        /// </summary>
        /// <param name="AddressBookDetails"></param>
        public static void AddDetails(AddressBookDetails addressDetail)
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
            long zipCode = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Phone Number");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            addressDetail.AddContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber, email);
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
    

