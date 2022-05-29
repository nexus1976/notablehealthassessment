using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql;

namespace nh.health.infrastructure.dal.command
{
    public partial class CommandContext : DbContext, ICommandContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CommandContext() { }
        public CommandContext(DbContextOptions options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<DoctorPatientSchedule> DoctorPatientSchedules { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql();
                optionsBuilder.EnableDetailedErrors(true);
            }
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");
            

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctors");
                entity.HasKey("Id");
                entity.Property(e => e.Id).IsRequired().ValueGeneratedNever().HasColumnName("id");
                entity.Property(e => e.FullTitle).IsRequired().HasColumnName("fulltitle").HasMaxLength(100);
                entity.Property(e => e.FirstName).IsRequired().HasColumnName("firstname").HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasColumnName("lastname").HasMaxLength(100);
                entity.Property(e => e.OfficePhone).IsRequired(false).HasColumnName("officephone").HasMaxLength(10);
                entity.Property(e => e.Email).IsRequired(false).HasColumnName("email").HasMaxLength(256);
                entity.Property(e => e.IsDeactivated).IsRequired().HasColumnName("isdeactivated").HasDefaultValue(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patients");
                entity.HasKey("Id");
                entity.Property(e => e.Id).IsRequired().ValueGeneratedNever().HasColumnName("id");
                entity.Property(e => e.FirstName).IsRequired().HasColumnName("firstname").HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasColumnName("lastname").HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired(false).HasColumnName("email").HasMaxLength(256);
                entity.Property(e => e.IsDeactivated).IsRequired().HasColumnName("isdeactivated").HasDefaultValue(false);
            });

            modelBuilder.Entity<DoctorPatientSchedule>(entity =>
            {
                entity.ToTable("DoctorPatientSchedules");
                entity.HasKey("Id");
                entity.Property(e => e.Id).IsRequired().ValueGeneratedNever().HasColumnName("id");
                entity.Property(e => e.DoctorId).IsRequired().HasColumnName("doctor_id");
                entity.Property(e => e.PatientId).IsRequired().HasColumnName("patient_id");
                entity.Property(e => e.PatientType).IsRequired().HasColumnName("patienttype");
                entity.Property(e => e.AppointmentDateTime).IsRequired().HasColumnName("appointmentdatetime");
            });
        }

    }
}
