using System.ComponentModel.DataAnnotations;

namespace EducationPlatform_GraduationProject.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string Title { get; set; } = null!;

        public ICollection<Student> Students { get; set; }
        public ICollection<Content> Contents { get; set; }
        public Chat Chat { get; set; }
    }
}
