namespace CabManagementSystem.Models.ViewModels
{
  

    public class RegisterViewModel
    {
        [Required]
        [StringLength(15)]
        [Display(Name = "Full Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Usertype(driver/Customer)")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
       
        [Display(Name = "Contact Number")]
        public long Phonenumber { get; set; }

        [Display(Name = "LogIn as")]
        public Usertype UserType { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(25)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
