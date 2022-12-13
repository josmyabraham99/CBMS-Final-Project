namespace CabManagementSystem.Models
{
    public enum CabTypes
    {
        Two_Wheeler,
        Auto,
        Car,
        Van,
        Traveller,
        Bus
    }


    public class BookDriver { 
        public int Id { get; set; } 
        public Vehicles Vehicles { get; set; }

         [StringLength(20)]
        public string DriverName { get; set; }

        public int CabNumber { get; set; }

        [StringLength(50)]
        public string Languages { get; set; }

        [StringLength(50)]
        public string Charge { get; set; }
        public int Contact { get; set; }

        [StringLength(25)]
        public string Summary { get; set; }





    }
}
