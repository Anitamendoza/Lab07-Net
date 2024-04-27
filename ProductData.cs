using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class ProductData
    {
        private string connectionString = "Data Source=LAB1504-23\\SQLEXPRESS;Initial Catalog=FacturaDB;User Id=mendoza;Password=123456";

        public List<Product> Get()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ListarProductos", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductID = Convert.ToInt32(reader["product_id"]);
                    product.Name = reader["name"].ToString();
                    product.Price = Convert.ToDecimal(reader["price"]);
                    product.Stock = Convert.ToInt32(reader["stock"]);
                    product.Active = Convert.ToBoolean(reader["active"]);
                    products.Add(product);
                }
                reader.Close();
            }

            return products;
        }
    }
}
