using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.HMO;

public partial class HmoCoronaContext : DbContext
{
    public HmoCoronaContext()
    {
    }

    public HmoCoronaContext(DbContextOptions<HmoCoronaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoronaVaccine> CoronaVaccines { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientAddress> PatientAddresses { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Serologion> Serologions { get; set; }

    public virtual DbSet<Vaccine> Vaccines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-2ACF5FN\\SQLEXPRESS;Database=HMO_corona;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoronaVaccine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__corona_v__3213E83F2B67ACE0");

            entity.ToTable("corona_vaccine");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Status).HasColumnName("_status");
            entity.Property(e => e.Vac1).HasColumnName("vac1");
            entity.Property(e => e.Vac2).HasColumnName("vac2");
            entity.Property(e => e.Vac3).HasColumnName("vac3");
            entity.Property(e => e.Vac4).HasColumnName("vac4");

            entity.HasOne(d => d.Vac1Navigation).WithMany(p => p.CoronaVaccineVac1Navigations)
                .HasForeignKey(d => d.Vac1)
                .HasConstraintName("FK__corona_vac__vac1__5535A963");

            entity.HasOne(d => d.Vac2Navigation).WithMany(p => p.CoronaVaccineVac2Navigations)
                .HasForeignKey(d => d.Vac2)
                .HasConstraintName("FK__corona_vac__vac2__5629CD9C");

            entity.HasOne(d => d.Vac3Navigation).WithMany(p => p.CoronaVaccineVac3Navigations)
                .HasForeignKey(d => d.Vac3)
                .HasConstraintName("FK__corona_vac__vac3__571DF1D5");

            entity.HasOne(d => d.Vac4Navigation).WithMany(p => p.CoronaVaccineVac4Navigations)
                .HasForeignKey(d => d.Vac4)
                .HasConstraintName("FK__corona_vac__vac4__5812160E");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__patient__3213E83F7A37591C");

            entity.ToTable("patient");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.BurnDate)
                .HasColumnType("date")
                .HasColumnName("burn_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Pic)
                .IsUnicode(false)
                .HasColumnName("pic");
            entity.Property(e => e.Status).HasColumnName("_status");
            entity.Property(e => e.Tel)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tel");

            entity.HasOne(d => d.Address).WithMany(p => p.Patients)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__patient__address__4BAC3F29");
        });

        modelBuilder.Entity<PatientAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__patient___3213E83FBEAFBEA4");

            entity.ToTable("patient_address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Street)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producer__3213E83FD545AE61");

            entity.ToTable("producer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("_name");
        });

        modelBuilder.Entity<Serologion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__serologi__3213E83F17D8A0B8");

            entity.ToTable("serologion");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.PositiveDate)
                .HasColumnType("date")
                .HasColumnName("positive_date");
            entity.Property(e => e.RecoveryDate)
                .HasColumnType("date")
                .HasColumnName("recovery_date");
            entity.Property(e => e.Status).HasColumnName("_status");
        });

        modelBuilder.Entity<Vaccine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vaccine__3213E83F63E30BD1");

            entity.ToTable("vaccine");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Producer).HasColumnName("producer");
            entity.Property(e => e.VacDate)
                .HasColumnType("date")
                .HasColumnName("vac_date");

            entity.HasOne(d => d.ProducerNavigation).WithMany(p => p.Vaccines)
                .HasForeignKey(d => d.Producer)
                .HasConstraintName("FK__vaccine__produce__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
