using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2139_Assignment.Models {
    public class Booking {
        [Required(ErrorMessage = "Booking ID is required")]
        public int BookingId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public double TotalPrice { get; set; }

        public int PersonCount { get; set; }

        public int? HotelId { get; set; }
        public int? FlightId { get; set; }
        public int? CarRentalId { get; set; }
        public string? UserId { get; set; }

        // Navigation properties
        public virtual Hotel? Hotel { get; set; }
        public virtual Flight? Flight { get; set; }
        public virtual CarRental? CarRental { get; set; }
    }
}
