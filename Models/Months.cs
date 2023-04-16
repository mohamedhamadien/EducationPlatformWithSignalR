using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPlatform_GraduationProject.Models
{
    public class Months
    {
        [Key]
        public int MonthId { get; set; }

        public bool? Jan { get; set; }

        public bool? Feb { get; set; }

        public bool? Mar { get; set; }

        public bool? Apr { get; set; }

        public bool? May { get; set; }

        public bool? Jun { get; set; }

        public bool? Jul { get; set; }

        public bool? Aug { get; set; }

        public bool? Sep { get; set; }

        public bool? Oct { get; set; }

        public bool? Nov { get; set; }

        public bool? Dec { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Student")]
        public int StID { get; set; }
    }
}
