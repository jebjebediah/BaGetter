﻿// <auto-generated />
using System;
using BaGetter.Database.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaGetter.Database.MySql.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "latin1");

            modelBuilder.Entity("BaGetter.Core.Package", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Authors")
                        .HasMaxLength(4000)
                        .HasColumnType("varchar(4000)");

                    b.Property<string>("Description")
                        .HasMaxLength(4000)
                        .HasColumnType("varchar(4000)");

                    b.Property<long>("Downloads")
                        .HasColumnType("bigint");

                    b.Property<bool>("HasEmbeddedIcon")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("HasReadme")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("IconUrl")
                        .HasMaxLength(4000)
                        .HasColumnType("varchar(4000)");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<bool>("IsPrerelease")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Language")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LicenseUrl")
                        .HasMaxLength(4000)
                        .HasColumnType("varchar(4000)");

                    b.Property<bool>("Listed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MinClientVersion")
                        .HasMaxLength(44)
                        .HasColumnType("varchar(44)");

                    b.Property<string>("NormalizedVersionString")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("Version");

                    b.Property<string>("OriginalVersionString")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("OriginalVersion");

                    b.Property<string>("ProjectUrl")
                        .HasMaxLength(4000)
                        .HasColumnType("varchar(4000)");

                    b.Property<DateTime>("Published")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReleaseNotes")
                        .HasColumnType("longtext")
                        .HasColumnName("ReleaseNotes");

                    b.Property<string>("RepositoryType")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RepositoryUrl")
                        .HasMaxLength(4000)
                        .HasColumnType("varchar(4000)");

                    b.Property<bool>("RequireLicenseAcceptance")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.Property<int>("SemVerLevel")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasMaxLength(4000)
                        .HasColumnType("varchar(4000)");

                    b.Property<string>("Tags")
                        .HasMaxLength(4000)
                        .HasColumnType("varchar(4000)");

                    b.Property<string>("Title")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Key");

                    b.HasIndex("Id");

                    b.HasIndex("Id", "NormalizedVersionString")
                        .IsUnique();

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("BaGetter.Core.PackageDependency", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int?>("PackageKey")
                        .HasColumnType("int");

                    b.Property<string>("TargetFramework")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("VersionRange")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Key");

                    b.HasIndex("Id");

                    b.HasIndex("PackageKey");

                    b.ToTable("PackageDependencies");
                });

            modelBuilder.Entity("BaGetter.Core.PackageType", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<int>("PackageKey")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.HasKey("Key");

                    b.HasIndex("Name");

                    b.HasIndex("PackageKey");

                    b.ToTable("PackageTypes");
                });

            modelBuilder.Entity("BaGetter.Core.TargetFramework", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Moniker")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<int>("PackageKey")
                        .HasColumnType("int");

                    b.HasKey("Key");

                    b.HasIndex("Moniker");

                    b.HasIndex("PackageKey");

                    b.ToTable("TargetFrameworks");
                });

            modelBuilder.Entity("BaGetter.Core.PackageDependency", b =>
                {
                    b.HasOne("BaGetter.Core.Package", "Package")
                        .WithMany("Dependencies")
                        .HasForeignKey("PackageKey");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("BaGetter.Core.PackageType", b =>
                {
                    b.HasOne("BaGetter.Core.Package", "Package")
                        .WithMany("PackageTypes")
                        .HasForeignKey("PackageKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");
                });

            modelBuilder.Entity("BaGetter.Core.TargetFramework", b =>
                {
                    b.HasOne("BaGetter.Core.Package", "Package")
                        .WithMany("TargetFrameworks")
                        .HasForeignKey("PackageKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");
                });

            modelBuilder.Entity("BaGetter.Core.Package", b =>
                {
                    b.Navigation("Dependencies");

                    b.Navigation("PackageTypes");

                    b.Navigation("TargetFrameworks");
                });
#pragma warning restore 612, 618
        }
    }
}
