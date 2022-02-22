using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBoookSystem
{
    public class AddressBookRepo
    {
        //SqlServer Connection String
        public static string connectionString = "Data Source=ANIKET-PC;Initial Catalog = AddressBookService; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        readonly SqlConnection connection = new SqlConnection(connectionString);
        //Method to get all records from DB
        public void GetAllRecords()
        {
            try
            {
                ContactModel model = new ContactModel();
                using (this.connection)
                {
                    //Sql Query
                    string query = @"select c.first_name, c.last_name, c.city, c.phone_no, b.book_name, b.book_type 
                                 from contact c inner join addbooknametype b on c.book_id = b.book_id WHERE LOWER(c.first_name)='Sana';";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    //Open Connection of DB
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //Read Records from DB Rows Wise
                        while (reader.Read())
                        {
                            model.Firstname = reader.GetString(0);
                            model.Lastname = reader.GetString(1);
                            model.City = reader.GetString(2);
                            model.Phone = reader.GetString(3);
                            model.B_Name = reader.GetString(4);
                            model.B_Type = reader.GetString(5);
                            Console.WriteLine(model.Firstname + " " + model.Lastname + " " + model.City + " " + model.Phone + " " + model.B_Name + " " + model.B_Type);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Rows does not exist");
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //Adding new field of startdate to contact table
        public void AddDateField()
        {
            try
            {
                using (this.connection)
                {
                    string query = "ALTER TABLE contact ADD StartDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP;";
                    SqlCommand command = new SqlCommand(query, connection);
                    this.connection.Open();
                    command.ExecuteReader();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //update Contact with State
        public void UpdateContactToDatabase()
        {
            string query = "update contact set state = 'Jharkhand' where first_name = 'Vikas';";
            try
            {
                using (this.connection)
                {
                    this.connection.Open();
                    SqlCommand command = new SqlCommand(query, this.connection);
                    //Executes Sql statement to Update in DB
                    var rows = command.ExecuteNonQuery();
                    //Close Connection of database
                    this.connection.Close();
                    if (rows != 0)
                        Console.WriteLine("Updated in DB");
                    else
                        Console.WriteLine(rows);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
}
