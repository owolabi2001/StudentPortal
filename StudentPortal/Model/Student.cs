using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Model
{

    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Programme { get; set; }

        //[Index(IsUnique = true)]
        public string MatricNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Course> Courses { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } 

    }
}
