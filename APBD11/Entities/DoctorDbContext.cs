using Microsoft.EntityFrameworkCore;

namespace APBD11.Entities
{
    public class DoctorDbContext: DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
        
        public DoctorDbContext()
        {

        }

        public DoctorDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(d => d.IdDoctor);
                entity.Property(d => d.IdDoctor).ValueGeneratedOnAdd();
                entity.ToTable("Doctor");
                
                entity.HasMany(d => d.Prescriptions)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey(p => p.IdDoctor)
                    .IsRequired();

            });
            
            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(p => p.IdPrescription);
                entity.Property(p => p.IdPrescription).ValueGeneratedOnAdd();
                entity.ToTable("Prescription");

            });
            
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.IdPatient);
                entity.Property(p => p.IdPatient).ValueGeneratedOnAdd();
                entity.ToTable("Patient");
                
                entity.HasMany(p => p.Prescriptions)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(p => p.IdPatient)
                    .IsRequired();

            });
            
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(m => m.IdMedicament);
                entity.Property(m => m.IdMedicament).ValueGeneratedOnAdd();
                entity.ToTable("Medicament");

            });
            
            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasKey(pm => new {pm.IdMedicament, pm.IdPrescription});
                entity.ToTable("Prescription_Medicament");
            });
        }
    }
}