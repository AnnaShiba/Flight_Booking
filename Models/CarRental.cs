using System;
using System.ComponentModel.DataAnnotations;



namespace COMP2139_Assignment.Models

{
    public class CarRental
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Make { get; set; } 

        [Required]
        [StringLength(100)]
        public string Model { get; set; } 

        [Required]
        public int Year { get; set; } 

        [Required]
        [StringLength(10)]
        public string Color { get; set; } 

        [Required]
        public decimal PricePerDay { get; set; }

        [Required]
        public bool IsAvailable { get; set; } 

        [DataType(DataType.Date)]
        public DateTime AvailableFrom { get; set; } 

        [DataType(DataType.Date)]
        public DateTime AvailableUntil { get; set; } 

    
    }
}
