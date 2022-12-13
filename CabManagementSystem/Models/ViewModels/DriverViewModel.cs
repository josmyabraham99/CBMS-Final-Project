namespace CabManagementSystem.Models.ViewModels
{
    public class DriverViewModel
    {
        [Required]

        [Display(Name = "Cab Registration Number")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Vehicle Type")]
        public Vehicles Vehicle { get; set; }

        [Required]

        [Display(Name = "Liscense Number")]
        public string Liscense { get; set; }

        [Required]

        [Display(Name = "Contact Number")]
        public long Contact { get; set; }


    }
}
