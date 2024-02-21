using System.ComponentModel.DataAnnotations;

namespace COMP2139_Assignment.Models
{
    public class Flight {
        [Required(ErrorMessage = "Flight ID is required")]
        public int FlightId { get; set; }
        [Required(ErrorMessage = "Airline is required")]
        public string Airline { get; set; } = string.Empty;
        [Required(ErrorMessage = "Source is required")]
        public string Source { get; set; } = string.Empty;
        [Required(ErrorMessage = "Destination is required")]
        public string Destination { get; set; } = string.Empty;
        public double Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureFrom { get; set; }
        [DataType(DataType.Date)]
        public DateTime DepartureTo { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnFrom { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnTo { get; set; }
    }
}
