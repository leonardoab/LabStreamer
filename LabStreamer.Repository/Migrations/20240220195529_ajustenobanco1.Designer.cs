﻿// <auto-generated />
using System;
using LabStreamer.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabStreamer.Repository.Migrations
{
    [DbContext(typeof(LabStreamerContext))]
    [Migration("20240220195529_ajustenobanco1")]
    partial class ajustenobanco1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LabStreamer.Domain.Conta.Agreggates.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("LabStreamer.Domain.Streamer.Agreggates.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BandaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BandaId");

                    b.ToTable("Album", (string)null);
                });

            modelBuilder.Entity("LabStreamer.Domain.Streamer.Agreggates.Banda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banda", (string)null);
                });

            modelBuilder.Entity("LabStreamer.Domain.Streamer.Agreggates.ListaFavorita", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ListaFavorita", (string)null);
                });

            modelBuilder.Entity("LabStreamer.Domain.Streamer.Agreggates.Musica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BandaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("BandaId");

                    b.ToTable("Musica", (string)null);
                });

            modelBuilder.Entity("ListaFavoritaMusica", b =>
                {
                    b.Property<Guid>("ListaFavoritasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MusicasId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ListaFavoritasId", "MusicasId");

                    b.HasIndex("MusicasId");

                    b.ToTable("ListaFavoritaMusica");
                });

            modelBuilder.Entity("LabStreamer.Domain.Streamer.Agreggates.Album", b =>
                {
                    b.HasOne("LabStreamer.Domain.Streamer.Agreggates.Banda", null)
                        .WithMany("Albuns")
                        .HasForeignKey("BandaId");
                });

            modelBuilder.Entity("LabStreamer.Domain.Streamer.Agreggates.ListaFavorita", b =>
                {
                    b.HasOne("LabStreamer.Domain.Conta.Agreggates.Usuario", null)
                        .WithMany("ListaFavoritas")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("LabStreamer.Domain.Streamer.Agreggates.Musica", b =>
                {
                    b.HasOne("LabStreamer.Domain.Streamer.Agreggates.Album", null)
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumId");

                    b.HasOne("LabStreamer.Domain.Streamer.Agreggates.Banda", null)
                        .WithMany("Musicas")
                        .HasForeignKey("BandaId");
                });

            modelBuilder.Entity("ListaFavoritaMusica", b =>
                {
                    b.HasOne("LabStreamer.Domain.Streamer.Agreggates.ListaFavorita", null)
                        .WithMany()
                        .HasForeignKey("ListaFavoritasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabStreamer.Domain.Streamer.Agreggates.Musica", null)
                        .WithMany()
                        .HasForeignKey("MusicasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LabStreamer.Domain.Conta.Agreggates.Usuario", b =>
                {
                    b.Navigation("ListaFavoritas");
                });

            modelBuilder.Entity("LabStreamer.Domain.Streamer.Agreggates.Album", b =>
                {
                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("LabStreamer.Domain.Streamer.Agreggates.Banda", b =>
                {
                    b.Navigation("Albuns");

                    b.Navigation("Musicas");
                });
#pragma warning restore 612, 618
        }
    }
}
