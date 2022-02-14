using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBoookSystem
{
    public class FileOperations
    {
        /// <summary>
        /// Method to write person details into PersonData.txt
        /// </summary>
        /// <param name="addressDictionary"></param>
        public static void WriteInTextFile(Dictionary<string, AddressBookDetails> List, string filePath)
        {
            if (File.Exists(filePath))
            {
                //using streamWriter write the data into the file 
                StreamWriter writer = new StreamWriter(filePath);
                foreach (KeyValuePair<string, AddressBookDetails> kv in List)
                {
                    //write line method it will append next data in the nextline
                    writer.WriteLine("AddressBook Name: " + kv.Key);
                    foreach (var list in kv.Value.getContacts())
                    {
                        writer.WriteLine("Name:" + list.firstName + " " + list.lastName + " Address:" + list.address + " City:" + list.city + " State:" + list.state + " Zipcode:" + list.zipCode + " Ph.No:" + list.phoneNumber + " Email:" + list.email);
                    }
                }
                //close the stream
                writer.Close();
            }
            else
            {
                Console.WriteLine("File does not exists");
            }
        }
        /// <summary>
        /// Reading data from Persondata.txt and displaying to the console
        /// </summary>
        /// <param name="filePath"></param>
        public static void ReadFromTextFile(string filePath)
        {
            Console.WriteLine("\n Data from text file\n");
            using (StreamReader file = new StreamReader(filePath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
