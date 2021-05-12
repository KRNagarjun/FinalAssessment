using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalAssessment.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GnmEmployee> GnmEmployee { get; set; }
        public virtual DbSet<GnmTruckDetails> GnmTruckDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DELL\\MSSQLSERVERNEW;Database=AcmeFreezerLogistics;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GnmEmployee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__GNM_Empl__AF2DBA79274F9F8E");
            });

            modelBuilder.Entity<GnmTruckDetails>(entity =>
            {
                entity.HasKey(e => e.TruckId)
                    .HasName("PK__GNM_Truc__6632E95BD95808FF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
