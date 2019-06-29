namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    public class HospitalContext : DbContext
    {
        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PatientEntityConfig(modelBuilder);

            VisitationEntityConfig(modelBuilder);

            DiagnoseEntityConfig(modelBuilder);

            MedicamentEntityConfig(modelBuilder);

            PatientMedicamentEntityConfig(modelBuilder);

            DoctorEntityConfig(modelBuilder);
        }

        private static void DoctorEntityConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(true);

                entity.Property(e => e.Specialty)
                    .HasMaxLength(100)
                    .IsUnicode(true);

            });
        }

        private static void PatientMedicamentEntityConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.PatientId,
                    e.MedicamentId
                });

                entity.HasOne(e => e.Patient)
                    .WithMany(e => e.Prescriptions)
                    .HasForeignKey(e => e.PatientId);

                entity.HasOne(e => e.Medicament)
                    .WithMany(e => e.Prescriptions)
                    .HasForeignKey(e => e.MedicamentId);
            });
        }

        private static void MedicamentEntityConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.MedicamentId);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true);
            });
        }

        private static void DiagnoseEntityConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(e => e.DiagnoseId);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                entity.HasOne(e => e.Patient)
                    .WithMany(e => e.Diagnoses)
                    .HasForeignKey(e => e.PatientId);
            });
        }

        private static void VisitationEntityConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(e => e.VisitationId);

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                entity.HasOne(e => e.Patient)
                    .WithMany(e => e.Visitations)
                    .HasForeignKey(e => e.PatientId);

                entity.HasOne(e => e.Doctor)
                    .WithMany(e => e.Visitations)
                    .HasForeignKey(e => e.DoctorId);
            });
        }

        private static void PatientEntityConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.Property(p => p.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.Property(p => p.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.Property(p => p.Address)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                entity.Property(p => p.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });                
        }
    }
}
