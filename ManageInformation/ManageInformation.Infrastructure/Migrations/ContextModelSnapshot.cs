﻿// <auto-generated />
using System;
using ManageInformation.Infrastructure;
using ManageInformation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ManageInformation.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ManageInformation.Domain.Model.Cars", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CarMarka")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CarNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerLicenseId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerLicenseId");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("ManageInformation.Domain.Model.GIBDD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("License")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("gibdd");
                });

            modelBuilder.Entity("ManageInformation.Domain.Model.MVD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Passport")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("mvd");
                });

            modelBuilder.Entity("ManageInformation.Domain.Model.Nalogovaya", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("INN")
                        .HasColumnType("integer");

                    b.Property<string>("bills")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("property")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("nalogi");
                });

            modelBuilder.Entity("ManageInformation.Domain.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GIBDDId")
                        .HasColumnType("integer");

                    b.Property<int>("MVDId")
                        .HasColumnType("integer");

                    b.Property<int>("NalogovayaId")
                        .HasColumnType("integer");

                    b.Property<int>("PFRId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GIBDDId");

                    b.HasIndex("MVDId");

                    b.HasIndex("NalogovayaId");

                    b.HasIndex("PFRId");

                    b.ToTable("person");
                });

            modelBuilder.Entity("ManageInformation.Domain.Model.PFR", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("SNILS")
                        .HasColumnType("integer");

                    b.Property<string>("SocialStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WorkBook")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("pfr");
                });

            modelBuilder.Entity("ManageInformation.Domain.Model.Cars", b =>
                {
                    b.HasOne("ManageInformation.Domain.Model.GIBDD", "OwnerLicense")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerLicenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OwnerLicense");
                });

            modelBuilder.Entity("ManageInformation.Domain.Model.Person", b =>
                {
                    b.HasOne("ManageInformation.Domain.Model.GIBDD", "GIBDD")
                        .WithMany()
                        .HasForeignKey("GIBDDId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManageInformation.Domain.Model.MVD", "MVD")
                        .WithMany()
                        .HasForeignKey("MVDId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManageInformation.Domain.Model.Nalogovaya", "Nalogovaya")
                        .WithMany()
                        .HasForeignKey("NalogovayaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManageInformation.Domain.Model.PFR", "PFR")
                        .WithMany()
                        .HasForeignKey("PFRId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GIBDD");

                    b.Navigation("MVD");

                    b.Navigation("Nalogovaya");

                    b.Navigation("PFR");
                });

            modelBuilder.Entity("ManageInformation.Domain.Model.GIBDD", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}