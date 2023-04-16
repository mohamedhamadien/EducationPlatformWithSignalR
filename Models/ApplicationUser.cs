using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPlatform_GraduationProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        public string StName { get; set; } = null!;
        [NotMapped]
        public string? Phone { get; set; }
        [NotMapped]
        public string? Address { get; set; }
        [NotMapped]
        public DateTime? RegistedDate { get; set; }
        [NotMapped]
        public int ClassID { get; set; }
    }
}
