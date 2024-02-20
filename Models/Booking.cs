using System.ComponentModel.DataAnnotations;

namespace COMP2139_Assignment.Models {
    public class Booking {
        [Required(ErrorMessage = "Booking ID is required")]
        public int BookingId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int HotelId { get; set; }

        // Navigation property
        public Hotel? Hotel { get; set; }
    }
}
