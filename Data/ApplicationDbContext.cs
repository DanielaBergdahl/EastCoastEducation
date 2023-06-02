using EastCoastEducation.Model;
using Microsoft.EntityFrameworkCore;

namespace EastCoastEducation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCompetence> TeachersCompetences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Student and course relationship...according to tutorial 1-----------
            //modelBuilder.Entity<StudentCourse>()
            //    .HasKey(sc => new { sc.CourseId, sc.StudentId });

            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne(s => s.Student)
            //    .WithMany(sc => sc.StudentCourses)
            //    .HasForeignKey(s => s.StudentId);

            //modelBuilder.Entity<StudentCourse>()
            //    .HasOne(s => s.Course)
            //    .WithMany(sc => sc.StudentCourses)
            //    .HasForeignKey(c => c.CourseId);
            ////----------------------------------------------------------

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.Students)
                .UsingEntity<StudentCourse>(
l => l.HasOne<Course>().WithMany(e => e.StudentCourses),
r => r.HasOne<Student>().WithMany(e => e.StudentCourses));

            
            ////Teacher and Competence relationship...according to tutorial 1--------------
            //modelBuilder.Entity<TeacherCompetence>()
            //    .HasKey(tc => new { tc.TeacherId, tc.CompetenceId });

            //modelBuilder.Entity<TeacherCompetence>()
            //    .HasOne(t => t.Teacher)
            //    .WithMany(tc => tc.TeacherCompetences)
            //    .HasForeignKey(t => t.TeacherId);

            //modelBuilder.Entity<TeacherCompetence>()
            //    .HasOne(t => t.Competence)
            //    .WithMany(tc => tc.TeacherCompetences)
            //    .HasForeignKey(c => c.CompetenceId);
            ////---------------------------------------------------------------------
            
            modelBuilder.Entity<Teacher>()
                .HasMany(f => f.Competences)
                .WithMany(f => f.Teachers)
                .UsingEntity<TeacherCompetence>(
l => l.HasOne<Competence>().WithMany(e => e.TeacherCompetences),
r => r.HasOne<Teacher>().WithMany(e => e.TeacherCompetences));

            modelBuilder.Entity<Course>()
                .HasOne(e => e.Teacher)
                .WithMany(e => e.Courses)
                .HasForeignKey(e => e.TeacherId)
                .IsRequired();
        }
         
    }
}
