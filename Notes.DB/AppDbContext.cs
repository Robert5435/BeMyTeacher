using Microsoft.EntityFrameworkCore;

namespace BeMyTeacher.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<TutoringAd> TutoringAds { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Calification> Califications { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=DESKTOP-I4OJB76;Database=BeMyTeacherDB;Integrated Security=True");
            }
    }
}
