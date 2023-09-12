using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Model
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CourseName { get; set; }
        [Required]
        public string Coursecode { get; set; }
        public int CourseUnit { get; set; }


        public DateTime CreatedDate { get; set; }
        public List<Student> students { get; set; } = new();


    }
}
