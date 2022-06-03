using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PBL3_Tutor.Models
{
    public partial class DBModelContext : DbContext
    {
        public DBModelContext()
            : base("name=DBModelConnectionString")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tutor> Tutors { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Admins)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Staffs)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Tutors)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.phonenumber)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Class)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.phonenumber)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.phonenumber)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tutor>()
                .Property(e => e.phonenumber)
                .IsUnicode(false);

            modelBuilder.Entity<Tutor>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Tutor>()
                .Property(e => e.yearOfBirth)
                .IsUnicode(false);

            modelBuilder.Entity<Tutor>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<Tutor>()
                .Property(e => e.avata)
                .IsUnicode(false);

            modelBuilder.Entity<Tutor>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Tutor>()
                .HasMany(e => e.Registrations)
                .WithRequired(e => e.Tutor)
                .WillCascadeOnDelete(false);
        }
    }
}
