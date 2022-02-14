using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBoookSystem
{
    public class Contacts
    {
        // variables
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set;  }
        public string state { get; set; }
        public int zipCode { get; set; }
        public long phoneNumber { get; set; }
        public string email { get; set; }

        //// constructor which get user details
        public Contacts(string firstName, string lastName, string address, string city, string state, int zipCode, long phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
        //Override to string method
        public override string ToString()
        {
            return $"{firstName}{lastName}{address}{city}{state}{zipCode}{phoneNumber}{email}";
        }
        // Method to Display the contact details
        public void Display()
        {
            Console.WriteLine("First Name:{0}", this.firstName);
            Console.WriteLine("Last Name:{0}", this.lastName);
            Console.WriteLine("Address:{0}", this.address);
            Console.WriteLine("City: {0}", this.city);
            Console.WriteLine("State:{0}", this.state);
            Console.WriteLine("Zipcode:{0}", this.zipCode);
            Console.WriteLine("phone number:{0}", this.phoneNumber);
            Console.WriteLine("Email:{0}", this.email);
        }
    }
}
