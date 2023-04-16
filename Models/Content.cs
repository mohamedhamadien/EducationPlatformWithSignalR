using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPlatform_GraduationProject.Models
{
    public class Content
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime Date { get; set; }

        [ForeignKey ("Class")]
        public int ClassID { get; set; }
        public Class Class { get; set; }
        public ICollection<ContentImage> Images { get; set; } = null;
        public ICollection<ContentPDFs> PDFs { get; set; } = null;
        public ICollection<ContentVideos> Videos { get; set; } = null;

    }
}
