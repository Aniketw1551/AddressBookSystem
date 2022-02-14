using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBoookSystem
{
    public class Json
    {
        // method to write onto json file
        public static void WriteIntoJSONFile(Dictionary<string, AddressBookDetails> contactList, string jsonFilePath)
        {
            Console.WriteLine("Writing Data into JSON File");
            //Iterate over all address books
            foreach (KeyValuePair<string, AddressBookDetails> kv in contactList)
            {
                string book = kv.Key;
                var contacts = kv.Value.getContacts();
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                using (StreamWriter s = new StreamWriter(jsonFilePath))
                {
                    //write onto json file
                    using (JsonTextWriter writer = new JsonTextWriter(s))
                    {
                        serializer.Serialize(writer, contacts);
                    }
                }
            }
        }
        //read data from json file
        public static void ReadFromJSONFile(string jsonFilePath)
        {
            Console.WriteLine("Reading Data from JSON File");
            //deserialize objects 
            List<Contacts> records = JsonConvert.DeserializeObject<List<Contacts>>(File.ReadAllText(jsonFilePath));
            foreach (Contacts record in records)
            {
                Console.WriteLine(record);
            }
        }
    }
}
