using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ST10070933CLDV211POE.Models
{
    public class ProductModel
    {
        // Define the properties of the ProductModel class
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool Availability { get; set; }

        // Mock method for demonstration purposes
        public bool InsertProduct(ProductModel product)
        {
            string connectionString = "Server=tcp:st10070933.database.windows.net,1433;Initial Catalog=ST10070933;Persist Security Info=False;User ID=Tyrese;Password=Tempestx123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                string sqlQuery = "INSERT INTO ProductModel (productName, productPrice, productCategory, productAvailability) VALUES (@productName, @productPrice, @productCategory, @productAvailability)";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@productName", product.Name);
                command.Parameters.AddWithValue("@productPrice", product.Price);
                command.Parameters.AddWithValue("@productCategory", product.Category);
                command.Parameters.AddWithValue("@productAvailability", product.Availability);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if rows were affected, indicating successful insertion
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it or throw)
                    // Consider logging the exception details for debugging
                    return false; // Insertion failed
                }
            }
        }
    }
}