using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PersonData
    {
        private string connectionString = "Data Source=LAB1504-23\\SQLEXPRESS;Initial Catalog=demodb;User Id=mendoza;Password=123456";

        public List<Person> Get()
        {
            List<Person> people = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ObtenerPersonas", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Person person = new Person();
                    person.PersonID = Convert.ToInt32(reader["PersonID"]);
                    person.FirstName = reader["FirstName"].ToString();
                    person.LastName = reader["LastName"].ToString();
                    person.Age = Convert.ToInt32(reader["Age"]);
                    people.Add(person);
                }
                reader.Close();
            }

            return people;
        }

        public void Insert()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }
    }
}
