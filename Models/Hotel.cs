using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace COMP2139_Assignment.Models {
    public class Hotel {
        [Required(ErrorMessage = "Hotel ID is required")]
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        public string Amentities { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public double Reviews { get; set; }
    }
}
