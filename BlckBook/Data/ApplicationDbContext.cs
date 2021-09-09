using System;
using System.Collections.Generic;
using System.Text;
using BlckBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlckBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolAddress> SchoolAddresses { get; set; }
        public DbSet<SchoolContact> SchoolContacts { get; set; }
        public DbSet<SchoolAdmin> SchoolAdmins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAddress> TeacherAddresses { get; set; }
        public DbSet<TeacherContact> TeacherContacts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<StudentContact> StudentContacts { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<Subject> Subjects { get; set; }       
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskSubmission> TaskSubmissions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Class>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ClassTeacher>()
                .HasKey(x => new { x.ClassId, x.TeacherId });
            modelBuilder.Entity<ClassTeacher>()
                .HasOne(x => x.Class)
                .WithMany(m => m.Teachers)
                .HasForeignKey(x => x.TeacherId);
            modelBuilder.Entity<ClassTeacher>()
                .HasOne(x => x.Teacher)
                .WithMany(e => e.Classes)
                .HasForeignKey(x => x.ClassId);
        }
    }
}
