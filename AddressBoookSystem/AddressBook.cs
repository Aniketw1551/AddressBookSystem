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
        readonly string filePath = @"C:\Users\Aniket\source\repos\AddressBookSystem\AddressBoookSystem\File\PersonData.txt";
        readonly string csvFilePath = @"C:\Users\Aniket\source\repos\AddressBookSystem\AddressBoookSystem\File\CSVData.csv";
        readonly string jsonFilePath = @"C:\Users\Aniket\source\repos\AddressBookSystem\AddressBoookSystem\File\JsonData.json";
        static AddressBookDetails addressDetails = new AddressBookDetails();
        static Dictionary<string, AddressBookDetails> addressBook = new Dictionary<string, AddressBookDetails>();
        static Dictionary<string, List<Contacts>> cityDictionary = new Dictionary<string, List<Contacts>>();
        static Dictionary<string, List<Contacts>> stateDictionary = new Dictionary<string, List<Contacts>>();
        AddressBookRepo AddressBookRepo = new AddressBookRepo();
        // List of class Type
        public void ReadInput()
        {
            bool CONTINUE = true;

            //The loop will keep on unill user exits from program
            while (CONTINUE)
            {
                Console.WriteLine("\nEnter your choice: \n");
                Console.WriteLine("1.Add address book 2.Add contact 3.Display details 4.Edit Contact details 5.Delete Contact\n");
                Console.WriteLine("6.Add Multiple Address book 7.Delete Address book 8.Search specific person with city or state name\n");
                Console.WriteLine("9.Check person by city or state name 10.Count of person/s by city or state 11.Sorting Address book\n");
                Console.WriteLine("12.Sorting by city,state or zipcode 13.Read or write data using FileIO \n");
                Console.WriteLine("14.Read or write data using CSV file 15.Read or write data using json file\n");
                Console.WriteLine("16.Get All Contacts From addressbook DB 17.Update contact details to DB 18.Alter table with startDate\n");
                Console.WriteLine("19.Retrive data by city or state from DB 20.Add new Contact to DB 0.Exit\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddressBook.AddressBookName();
                        break;
                    case 2:
                        AddDetails(AddressBook.AddBookName(addressBook), cityDictionary, stateDictionary);
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
                    case 9:
                        AddressBookDetails.PrintCityandStateList(cityDictionary);
                        AddressBookDetails.PrintCityandStateList(stateDictionary);
                        break;
                    case 10:
                        Console.WriteLine("Enter city name: ");
                        string city = Console.ReadLine();
                        AddressBookDetails.CountofPerson(cityDictionary,city);
                        Console.WriteLine("Enter state name: ");
                        string state = Console.ReadLine(); 
                        AddressBookDetails.CountofPerson(stateDictionary,state);
                        break;
                    case 11:
                        Console.WriteLine("Sorting person names in address boook alphabetically: ");
                        foreach (var data in addressBook.OrderBy(x => x.Key))
                        {
                            Console.WriteLine("{0}", data.Key);
                        }
                        break;
                    case 12:
                        AddressBookDetails.SortData(cityDictionary);
                        break;
                    case 13:
                        FileOperations.WriteInTextFile(addressBook, filePath);
                        FileOperations.ReadFromTextFile(filePath);
                        break;
                    case 14:
                        CsvHelper.WriteIntoCSVFile(addressBook, csvFilePath);
                        CsvHelper.ReadFromCSVFile(csvFilePath);
                        break;
                    case 15:
                        Json.WriteIntoJSONFile(addressBook, jsonFilePath);
                        Json.ReadFromJSONFile(jsonFilePath);
                        break;
                    case 16:
                        AddressBookRepo.GetAllRecords();
                        break;
                    case 17:
                        AddressBookRepo.UpdateContactToDatabase();
                        break;
                    case 18:
                        AddressBookRepo.AddDateField();
                        break;
                    case 19:
                        AddressBookRepo.RetrieveByCityOrState();
                        break;
                    case 20:
                        AddressBookRepo.AddNewContact();
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
        public static void AddDetails(AddressBookDetails addressBookDetails, Dictionary<string, List<Contacts>> cityDictionary, Dictionary<string, List<Contacts>> stateDictionary)
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

            addressBookDetails.AddContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber, email, stateDictionary, cityDictionary);
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