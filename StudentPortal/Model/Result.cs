using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Model
{
    public class Result
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double CA1 { get; set; }
        public double CA2 { get; set; }
        public double CA3 { get; set; }
        public double Exam { get; set; }
        


    }
}
