namespace EducationPlatform_GraduationProject.ViewModels
{
    public class ContentVM
    {
        
        public int Id { get; set; }
        public int ClassIdfk { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Date { get; set; }
        public string ClassName { get; set; }
    }
}
