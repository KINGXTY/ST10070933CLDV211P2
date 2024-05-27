using System.ComponentModel.DataAnnotations;

using System.Data.SqlClient;

namespace ST10070933CLDV211POE.Models
{
    public class TransactionModel
    {
        public string Product { get; set; }
        public string Category { get; set; }
        public string Availability { get; set; }

        // Method for inserting transaction data
        public bool InsertTransaction(TransactionModel transaction)
        {
            string connectionString = "Server=tcp:st10070933.database.windows.net,1433;Initial Catalog=ST10070933;Persist Security Info=False;User ID=Tyrese;Password=Tempestx123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO Transactions (Product, Category, Availability) VALUES (@Product, @Category, @Availability)";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@Product", transaction.Product);
                command.Parameters.AddWithValue("@Category", transaction.Category);
                command.Parameters.AddWithValue("@Availability", transaction.Availability);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if rows were affected, indicating successful insertion
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it or throw)
                    return false; // Insertion failed
                }
            }
        }
    }
}