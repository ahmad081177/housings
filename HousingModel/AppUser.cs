using System.ComponentModel.DataAnnotations;

namespace HousingModel
{
    public class AppUser
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        //public bool IsEmailConfirmed { get; set; } = false;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }=string.Empty;

        [Required]
        public bool IsAdmin { get; set; } = false;
        [Required]
        public bool IsSeller { get; set; } = false;
        public bool IsBuyer { get; set; } = false;
    }
    public class AppLogin
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}