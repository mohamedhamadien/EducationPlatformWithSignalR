using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPlatform_GraduationProject.Models
{
    public class ContentImage
    {
        [Key]
        public int Id { get; set; } 
        public string? Path { get; set; }
        public Content Content { get; set; }
        [ForeignKey("Content")]
        public int ContentID { get; set; }
    }
}
