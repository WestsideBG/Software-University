using System;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        public StudentSystemContext(DbContextOptions options)
        : base(options)
        {
            
        }

        public StudentSystemContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(p => p.Name)
                    .HasMaxLength(100)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity.Property(p => p.PhoneNumber)
                    .HasColumnType("CHAR(10)")
                    .IsRequired(false)
                    .IsUnicode(false);

                entity.Property(p => p.RegisteredOn)
                    .HasDefaultValue(DateTime.Now);

                entity.Property(p => p.Birthday)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(p => p.Name)
                    .HasMaxLength(80)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity.Property(p => p.Description)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity.Property(p => p.StartDate)
                    .IsRequired(true);

                entity.Property(p => p.EndDate)
                    .IsRequired(true);

                entity.Property(p => p.Price)
                    .IsRequired(true);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity.Property(p => p.Url)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.HasOne(e => e.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(e => e.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(p => p.Content)
                    .IsUnicode(false)
                    .IsRequired(true);

                entity.HasOne(e => e.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                    .WithMany(c => c.HomeworkSubmissions)
                    .HasForeignKey(e => e.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new {e.StudentId, e.CourseId});

                entity.HasOne(e => e.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                    .WithMany(s => s.StudentsEnrolled)
                    .HasForeignKey(e => e.CourseId);
            });
        }
    }
}