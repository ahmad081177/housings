namespace HousingModels
{
    public class AppUser
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsSeller { get; set; }
    }
    public class Admin : AppUser
    {

    }
    
}
