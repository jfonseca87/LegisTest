﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Legis.Votaciones.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Legis.Votaciones.Repository.SqlImplementations
{
    public partial class VotacionesdbContext : DbContext
    {
        public VotacionesdbContext()
        {
        }

        public VotacionesdbContext(DbContextOptions<VotacionesdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidatos> Candidatos { get; set; }
        public virtual DbSet<Elecciones> Elecciones { get; set; }
        public virtual DbSet<EleccionesCandidatos> EleccionesCandidatos { get; set; }
        public virtual DbSet<ResultadosElecciones> ResultadosElecciones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Votantes> Votantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Candidatos>(entity =>
            {
                entity.HasKey(e => e.CandidatoId)
                    .HasName("PK__Candidat__ED83BFADE267A52B");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Elecciones>(entity =>
            {
                entity.HasKey(e => e.EleccionId)
                    .HasName("PK__Eleccion__4D6CE41FE42E8849");

                entity.Property(e => e.Activa).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EleccionesCandidatos>(entity =>
            {
                entity.HasOne(d => d.Candidato)
                    .WithMany(p => p.EleccionesCandidatos)
                    .HasForeignKey(d => d.CandidatoId)
                    .HasConstraintName("FK__Eleccione__Candi__2F10007B");

                entity.HasOne(d => d.Eleccion)
                    .WithMany(p => p.EleccionesCandidatos)
                    .HasForeignKey(d => d.EleccionId)
                    .HasConstraintName("FK__Eleccione__Elecc__2E1BDC42");
            });

            modelBuilder.Entity<ResultadosElecciones>(entity =>
            {
                entity.HasOne(d => d.Candidato)
                    .WithMany(p => p.ResultadosElecciones)
                    .HasForeignKey(d => d.CandidatoId)
                    .HasConstraintName("FK__Resultado__Candi__32E0915F");

                entity.HasOne(d => d.Eleccion)
                    .WithMany(p => p.ResultadosElecciones)
                    .HasForeignKey(d => d.EleccionId)
                    .HasConstraintName("FK__Resultado__Elecc__31EC6D26");

                entity.HasOne(d => d.Votante)
                    .WithMany(p => p.ResultadosElecciones)
                    .HasForeignKey(d => d.VotanteId)
                    .HasConstraintName("FK__Resultado__Votan__33D4B598");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId)
                    .HasName("PK__Usuarios__2B3DE7B883189FDC");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EsInterno).HasDefaultValueSql("((0))");

                entity.Property(e => e.NomUsuario)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Votantes>(entity =>
            {
                entity.HasKey(e => e.VotanteId)
                    .HasName("PK__Votantes__3DCA8F6488461A98");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}