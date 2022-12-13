namespace CabManagementSystem.Models.ViewModels
{
    public class BookDriverViewModel
    {
       public int Id { get; set; }  
        [Required]
        public Vehicles Vehicles { get; set; }
        [Required]
        public string DriverName { get; set; }
        [Required]
        public int CabNumber { get; set; }
        [Required]
        public string Languages { get; set; }
        [Required]
        public string Charge { get; set; }

        [Required]

        public int Contact { get; set; }
        [Required]
        public string Summary { get; set; }

        
    }
}
