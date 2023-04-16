using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPlatform_GraduationProject.Models
{
    public class Messages
    {
        [Key]
        public int MId { get; set; }

        public string Body { get; set; } = null!;

        public DateTime Date { get; set; }
        public Chat Chat { get; set; }
        [ForeignKey("Chat")]
        public int ChatID { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Student")]
        public int StID { get; set; }
    }
}
