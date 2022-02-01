﻿// <auto-generated />
using System;
using Blog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220201132741_Fourth")]
    partial class Fourth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Models.Komentarz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tresc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WpisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WpisId");

                    b.ToTable("Komentarze");
                });

            modelBuilder.Entity("Blog.Models.Ocena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("WpisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WpisId");

                    b.ToTable("Oceny");
                });

            modelBuilder.Entity("Blog.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tagi");
                });

            modelBuilder.Entity("Blog.Models.TagWpis", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("WpisId")
                        .HasColumnType("int");

                    b.HasKey("TagId", "WpisId");

                    b.HasIndex("WpisId");

                    b.ToTable("TagiWpisy");
                });

            modelBuilder.Entity("Blog.Models.Wpis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataDodania")
                        .HasColumnType("datetime2");

                    b.Property<bool>("KomentarzeZablokowane")
                        .HasColumnType("bit");

                    b.Property<string>("Tytul")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zawartosc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wpisy");
                });

            modelBuilder.Entity("Blog.Models.Komentarz", b =>
                {
                    b.HasOne("Blog.Models.Wpis", "Wpis")
                        .WithMany("Komentarze")
                        .HasForeignKey("WpisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wpis");
                });

            modelBuilder.Entity("Blog.Models.Ocena", b =>
                {
                    b.HasOne("Blog.Models.Wpis", "Wpis")
                        .WithMany("Oceny")
                        .HasForeignKey("WpisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wpis");
                });

            modelBuilder.Entity("Blog.Models.TagWpis", b =>
                {
                    b.HasOne("Blog.Models.Tag", "Tag")
                        .WithMany("TagiWpisy")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog.Models.Wpis", "Wpis")
                        .WithMany("TagiWpisy")
                        .HasForeignKey("WpisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("Wpis");
                });

            modelBuilder.Entity("Blog.Models.Tag", b =>
                {
                    b.Navigation("TagiWpisy");
                });

            modelBuilder.Entity("Blog.Models.Wpis", b =>
                {
                    b.Navigation("Komentarze");

                    b.Navigation("Oceny");

                    b.Navigation("TagiWpisy");
                });
#pragma warning restore 612, 618
        }
    }
}
