using System.ComponentModel.DataAnnotations;

namespace MVC_Assignment.Models
{
    public class Course
    {

        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }


    }
}
