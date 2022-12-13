namespace CabManagementSystem.Models
{
    public enum Usertype
    {
        Cab_Driver,
        Cab_Customer
    }
    public class ApplicationUser : IdentityUser
    {
        [StringLength(15)]
        public string FirstName { get; set; }

        [StringLength(15)]
        public string LastName { get; set; }
        

       

    }
}
