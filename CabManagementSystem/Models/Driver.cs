namespace CabManagementSystem.Models
{
   
    [Index("Liscense", IsUnique = true)]
    [Index("Number", IsUnique = true)]

    public class Driver
    {
       

       public int Id { get; set; }
        [StringLength(10)]
        public string Number { get; set; }
     
        public Vehicles Vehicle { get; set; }
  

        [StringLength(20)]
        public string Liscense { get; set; }

        [StringLength(15)]
        public long Contact { get; set; }

       


    }
}
