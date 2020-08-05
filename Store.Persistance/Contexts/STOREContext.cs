﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Store.Persistance.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Store.Persistance.Entities;

namespace Store.Persistance.Contexts
{
    public partial class STOREContext : DbContext
    {
        public STOREContext()
        {
        }

        public STOREContext(DbContextOptions<STOREContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonRole> PersonRoles { get; set; }
        public virtual DbSet<PersonStatus> PersonStatuses { get; set; }
        public virtual DbSet<PersonVehicule> PersonVehicules { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Vehicule> Vehicules { get; set; }
        public virtual DbSet<VehiculeType> VehiculeTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Latitude).HasColumnType("decimal(15, 10)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(15, 10)");

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.StreetName).HasMaxLength(50);

                entity.Property(e => e.StreetNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.DisplayName).HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Person_PersonStatus");
            });

            modelBuilder.Entity<PersonRole>(entity =>
            {
                entity.ToTable("PersonRole");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<PersonStatus>(entity =>
            {
                entity.ToTable("PersonStatus");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PersonVehicule>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PersonVehicule");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonVehicules)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonVehicule_Person");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PersonVehicules)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonVehicule_PersonRole");

                entity.HasOne(d => d.Vehicule)
                    .WithMany(p => p.PersonVehicules)
                    .HasForeignKey(d => d.VehiculeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonVehicule_Vehicule");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => new { e.CreationDate, e.VehiculeId });

                entity.ToTable("Position");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasColumnType("decimal(15, 10)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(15, 10)");

                entity.Property(e => e.Speed).HasColumnType("decimal(8, 4)");

                entity.HasOne(d => d.Vehicule)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.VehiculeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Position_Vehicule");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("Station");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Stations)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Station_Address");
            });

            modelBuilder.Entity<Vehicule>(entity =>
            {
                entity.ToTable("Vehicule");

                entity.Property(e => e.ConsumptionRate).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Mark).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReleaseYear).HasColumnType("date");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Vehicules)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Vehicule_VehiculeType");
            });

            modelBuilder.Entity<VehiculeType>(entity =>
            {
                entity.ToTable("VehiculeType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}