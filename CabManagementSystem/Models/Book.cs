namespace CabManagementSystem.Models
{
    public enum Location
    {
        Rajakkad,
        Rajakumari,
        Senpathy,
        Chemmannar,
        Kuthumgal,
        Adimaly,
        Nedumkandam,
        Udumbanchola,
        Santhanpara,
        Poopara,
        NR_City,
        Kallarkutty,
        Kattapana
    }

    public enum Vehicles
    {
        Two_Wheeler,
        Auto,
        Car,
        Van,
        Traveller,
        Bus
    }
    public class Book
    {
        public int Id { get; set; }
        public ApplicationUser Books { get; set; }
        [ForeignKey(nameof(Book))]
      
        public Location PickUp { get; set; }

        [StringLength(15)]
        public Location DropDown { get; set; }

      
        public Vehicles Vehicle { get; set; }

        [StringLength(15)]
        public DateTime Date { get; set; }

        
    }

}
