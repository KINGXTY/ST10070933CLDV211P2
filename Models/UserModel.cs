using System.ComponentModel.DataAnnotations;

using System.Data.SqlClient;

namespace ST10070933CLDV211POE.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        // Method for inserting user data
        public bool InsertUser(UserModel user)
        {
            string connectionString = "Server=tcp:st10070933.database.windows.net,1433;Initial Catalog=ST10070933;Persist Security Info=False;User ID=Tyrese;Password=Tempestx123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO Users (Name, Surname, Email) VALUES (@Name, @Surname, @Email)";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Surname", user.Surname);
                command.Parameters.AddWithValue("@Email", user.Email);

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