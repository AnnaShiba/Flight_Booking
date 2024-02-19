using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace COMP2139_Assignment.Models {
    public class Project {
        public Project() {
            Name = "";
            Description = "";
        }
        public Project(int projectId, string name, string description) {
            ProjectId = projectId;
            Name = name;
            Description = description;
        }

        [Required(ErrorMessage = "Project ID is required")]
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string? Status {  get; set; }
    }
}
