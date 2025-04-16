using FoodTekProject.DTOs.Login.Request;
using FoodTekProject.DTOs.Login.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;


namespace FoodTekProject.Controllers
{
    //Route of the controller 
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //Post endpoint of the Login
        [HttpPost("login")]
        public async Task <IActionResult> LogIn(LoginRequest input)
        {
            //this line not use here 
            var response = new LoginRequest();

            try
            {
                //check if the email or password is empty 

                if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.Password))
                    return BadRequest("Email and Password are required");
                //Connection String 
                string connectionString = "Data Source=REEM-NAEL\\SQLEXPRESS02;Initial Catalog=\"Foodtek Application (1)\";Integrated Security=True;Trust Server Certificate=True";

                //Create and open SQL connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    //execute stored procedure 
                    SqlCommand command = new SqlCommand("sp_LoginUser", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    //Pass email and password parameters to the stored procedure
                    command.Parameters.AddWithValue("@Email", input.Email);
                    command.Parameters.AddWithValue("@Password", input.Password);



                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        var user = new LoginResponse
                        {

                            Email = dt.Rows[0]["Email"].ToString(),
                            FirstName = dt.Rows[0]["FirstName"].ToString(),
                            LastName = dt.Rows[0]["LastName"].ToString(),
                            PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString()
                        };



                        return Ok(user);
                    }
                    return Unauthorized("Invalid email or password");
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    
    
    }
}

