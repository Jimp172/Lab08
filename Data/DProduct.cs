using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Entity1;

namespace Data
{
    public class DProduct
    {
        private string connectionString = "Data Source=DESKTOP-GRUDL8S;Initial Catalog=FacturaDB;User ID=tecsup;Password=tecsup";

        public List<Product> Get()
        {
            List<Product> productList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // Abre la conexión

                using (SqlCommand command = new SqlCommand("ListarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {

                                ProductId = Convert.ToInt32(reader["product_id"]),
                                Name = reader["name"].ToString(),
                                Price = Convert.ToDecimal(reader["price"]),
                                Stock = Convert.ToInt32(reader["stock"]),
                                Active = Convert.ToBoolean(reader["active"])
                            };

                            productList.Add(product);
                        }
                    }
                }
                connection.Close();
            }
            return productList;
        }

        public void Create(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Stock", product.Stock);

                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public void Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ActualizarProductoNuevo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Product_id", product.ProductId);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@Active", product.Active);

                    command.ExecuteNonQuery();
                }
                    connection.Close();
            }
        }

        public void Delete(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("EliminarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@product_id", product.ProductId);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Active(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ActivarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@product_id", product.ProductId);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
