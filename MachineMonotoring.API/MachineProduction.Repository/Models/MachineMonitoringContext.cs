using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MachineProduction.Repository.Models
{
    public partial class MachineMonitoringContext : DbContext
    {
        public MachineMonitoringContext()
        {
        }

        public MachineMonitoringContext(DbContextOptions<MachineMonitoringContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<MachineProduction> MachineProduction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MachineMonitoring;User ID=sa;Password=ecs789");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machine>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MachineProduction>(entity =>
            {
                entity.Property(e => e.MachineId).HasColumnName("MachineID");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.MachineProduction)
                    .HasForeignKey(d => d.MachineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineProduction_Machine");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
