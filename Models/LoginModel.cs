using System.ComponentModel.DataAnnotations;

using System.Data.SqlClient;

namespace ST10070933CLDV211POE.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        // Mock method for demonstration purposes
        public int SelectUser(string email, string name)
        {
            string connectionString = "Server=tcp:st10070933.database.windows.net,1433;Initial Catalog=ST10070933;Persist Security Info=False;User ID=Tyrese;Password=Tempestx123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
              
                string sqlQuery = "SELECT UserId FROM UserModel WHERE Email = @Email AND Name = @Name";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Name", name);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result); // Return user ID if found
                    }
                    return -1; // User not found
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it or throw)
                    return -1; // Error occurred
                }
            }
        }
    }
}