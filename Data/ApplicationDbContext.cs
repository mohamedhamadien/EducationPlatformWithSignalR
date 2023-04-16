using EducationPlatform_GraduationProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationPlatform_GraduationProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentImage> ContentImages { get; set; }
        public DbSet<ContentPDFs> ContentPDFs { get; set; }
        public DbSet<ContentVideos> ContentVideos { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Months> Months { get; set; }
        public DbSet<Student> Students { get; set; }
		public DbSet<OneDeviceLogin> OneDeviceLogin { get; set; }
		

	}
}