using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPlatform_GraduationProject.Models
{
    public class Chat
    {
        [Key]
        public int ChatId { get; set; }
        public string? Title { get; set; }
        public Class Class { get; set; }
        [ForeignKey("Class")]
        public int ClassIDFK { get; set; }
        public ICollection<Messages> Messages { get; set; }
    }
}
