using System.ComponentModel.DataAnnotations;

namespace TaskTrackerApp.Models
{
    public class Todo
    {
        [Key]
        [Display(Name = "#")]
        public int TaskTodoId { get; set; }

        [Required]
        [Display(Name = "Task Name")]
        public string TaskTodoName { get; set; }

        [Required]
        [Display(Name = "Task Description")]
        public string TaskTodoDescription { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Task Date")]
        public DateTime TaskTodoDate { get; set; }
    }
}
