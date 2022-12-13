namespace CabManagementSystem.Models.ViewModels
{
    public class BookViewModel
    {
        [Required]
      
        [Display(Name = "PickUp Place")]
        public Location PickUp  { get; set; }

        [Required]
        
        [Display(Name = "DropDown Place")]
        public Location DropDown { get; set; }

        [Required]
       
        [Display(Name = "PickUp Date & Time")]
        public DateTime Date { get; set; }

        [Required]

        [Display(Name = "Vehicle Required")]
        public  Vehicles Vehicle { get; set; }



    }
}
