using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PBL3_Tutor.Models
{
    public partial class DBClassContext : DbContext
    {
        public DBClassContext()
            : base("name=DBClassConnectionString")
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(e => e.Classes)
                .WithOptional(e => e.Student)
                .HasForeignKey(e => e.MaHocSinh);
        }
    }
}
