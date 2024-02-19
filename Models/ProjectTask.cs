using System.ComponentModel.DataAnnotations;

namespace COMP2139_Assignment.Models {
    public class ProjectTask {
        public ProjectTask() {
            Title = "";
            Description = "";
        }
        public ProjectTask(int projectTaskId, string title, string description) {
            ProjectTaskId = projectTaskId;
            Title = title;
            Description = description;
        }

        [Required(ErrorMessage = "Project Task ID is required")]
        public int ProjectTaskId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Description { get; set; }
        // FK
        public int ProjectId { get; set; }

        // Navigation property
        public Project? Project { get; set; }
    }
}
