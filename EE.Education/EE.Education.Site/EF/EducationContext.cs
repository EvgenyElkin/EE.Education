using EE.Education.Site.EF.Entities;
using EE.Education.Site.EF.Entities.Events;
using Microsoft.EntityFrameworkCore;

namespace EE.Education.Site.EF
{
    public class EducationContext : DbContext
    {
        public EducationContext(DbContextOptions options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<TaskGroupEntity> TaskGroups { get; set; }

        public DbSet<EventEntity> Events { get; set; }
        public DbSet<TaskEventEntity> TaskEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("education");
            modelBuilder.Entity<TeacherLink>()
                .HasKey(x => new {x.CourseId, x.TeacherId});
            modelBuilder.Entity<StudentLink>()
                .HasKey(x => new { x.CourseId, StundentId = x.StudentId });
            base.OnModelCreating(modelBuilder);
        }
    }
}