namespace FoodTekProject.Models
{
    public class Users
    {
        public class User
        {
            public int Id { get; set; } 

            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public string Password { get; set; }
            public string ProfileImage { get; set; }

            public DateTime JoinDate { get; set; }
            public string Status { get; set; }

            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }

            public bool IsActive { get; set; }

            public DateTime CreationDate { get; set; }
            public DateTime? UpdateDate { get; set; }

          
        }

    }
}
