using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MvcCoreDemoprj.Models
{
    public partial class MVCAssigementContext : DbContext
    {
        public MVCAssigementContext()
        {
        }

        public MVCAssigementContext(DbContextOptions<MVCAssigementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCountry> TblCountries { get; set; } = null!;
        public virtual DbSet<TblState> TblStates { get; set; } = null!;
        public virtual DbSet<TblUserRegister> TblUserRegisters { get; set; } = null!;
        public virtual DbSet<Tblcity> Tblcities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblCountry");

                entity.Property(e => e.CountryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CountryID");

                entity.Property(e => e.CountryName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblState>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblState");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.StateId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("StateID");

                entity.Property(e => e.StateName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblUserRegister>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblUserRegister");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Tblcity>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblcity");

                entity.Property(e => e.CityId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CityID");

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.StateId).HasColumnName("StateID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
