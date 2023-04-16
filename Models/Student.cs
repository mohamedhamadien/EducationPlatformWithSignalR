using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPlatform_GraduationProject.Models
{
    public class Student
    {
        [Key]
        public int StId { get; set; }

        public string StName { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public DateTime? RegistedDate { get; set; }

        //public bool PaymentState { get; set; }

        //public bool Available { get; set; }
        public Class Class { get; set; }
        [ForeignKey("Class") , ]
        public int ClassID { get; set; }
        public ICollection<Messages> Messages { get; set; }
        [ForeignKey("ApplicationUser")]
        public string? IdentityUserId { get; set; }
        public ApplicationUser IdentityUser { get; set; }
    }
}
