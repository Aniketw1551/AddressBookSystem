using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBoookSystem
{
    public class AddressBook
    {
        //properties of AddressBook
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Zip { get; set; }
        public double PhoneNumber { get; set; }
        public string Email { get; set; }


        public void Contact()  //Method to contact 
        {
            Console.WriteLine("FirstName: " + this.FirstName + " LastName: " + this.LastName
                              + " Address: " + this.Address + " City: " + this.City + " State: "
                              + this.State + " Zip: " + this.Zip + " PhoneNumber: "
                              + this.PhoneNumber + " Email: " + this.Email);
        }

        public void AddContact()  //Method to Add Contact in a List
        {
            Console.Write("Enter First Name, Last Name, Address, City, State, Zip, Phone Number, Email \n");
            AddressBook addressBook = new AddressBook()  //Initializing elements using collection-initializer syntax
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                Address = Console.ReadLine(),
                City = Console.ReadLine(),
                State = Console.ReadLine(),
                Zip = Convert.ToDouble(Console.ReadLine()),
                PhoneNumber = Convert.ToDouble(Console.ReadLine()),
                Email = Console.ReadLine(),
            };

            //creating a List to store contacts in List
            IList<AddressBook> AddressBookList = new List<AddressBook>();  //created a List
            AddressBookList.Add(addressBook);
            addressBook.Contact();
        }
    }
}
