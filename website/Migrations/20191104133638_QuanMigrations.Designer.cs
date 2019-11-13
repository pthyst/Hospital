﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using website.Data;

namespace website.Migrations
{
    [DbContext(typeof(WebsiteDbContext))]
    [Migration("20191104133638_QuanMigrations")]
    partial class QuanMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("website.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateLastUsed");

                    b.Property<DateTime>("DateModify");

                    b.Property<string>("Email");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Role_Id");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Role_Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("website.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreate");

                    b.Property<int>("Insurance_Id");

                    b.Property<int>("PayInsurance");

                    b.Property<int>("PayPatient");

                    b.Property<int>("PayTotal");

                    b.Property<int>("Perscription_Id");

                    b.Property<int>("Pharamacist_Id");

                    b.HasKey("Id");

                    b.HasIndex("Insurance_Id");

                    b.HasIndex("Perscription_Id");

                    b.HasIndex("Pharamacist_Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("website.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<int>("Faculty_Id");

                    b.Property<string>("NameFirst")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NameLast")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NameMiddle")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Role_Id");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Faculty_Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("Role_Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("website.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Fee");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("website.Models.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressApartment")
                        .IsRequired();

                    b.Property<string>("AddressCity")
                        .IsRequired();

                    b.Property<string>("AddressDistrict")
                        .IsRequired();

                    b.Property<string>("AddressStreet")
                        .IsRequired();

                    b.Property<DateTime>("DateBirth");

                    b.Property<DateTime>("DateExpire");

                    b.Property<DateTime>("DateLastUsed");

                    b.Property<DateTime>("DateRegistration");

                    b.Property<string>("Gender");

                    b.Property<int>("InsuranceType_Id");

                    b.Property<string>("NameFirst")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NameLast")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NameMiddle")
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumberHome")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("PhoneNumberPersonal")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("InsuranceType_Id");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("website.Models.InsuranceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PayLimit");

                    b.Property<double>("PayPercent");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("InsuranceTypes");
                });

            modelBuilder.Entity("website.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Admin_Id");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateModify");

                    b.Property<int>("Instore");

                    b.Property<int>("MedicineUnit_Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Price");

                    b.Property<string>("Thumbnail");

                    b.HasKey("Id");

                    b.HasIndex("Admin_Id");

                    b.HasIndex("MedicineUnit_Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("website.Models.MedicineUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Unit")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Unit")
                        .IsUnique();

                    b.ToTable("MedicineUnits");
                });

            modelBuilder.Entity("website.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressApartment")
                        .IsRequired();

                    b.Property<string>("AddressCity")
                        .IsRequired();

                    b.Property<string>("AddressDistrict")
                        .IsRequired();

                    b.Property<string>("AddressStreet")
                        .IsRequired();

                    b.Property<int>("BMP");

                    b.Property<string>("Blood_Type");

                    b.Property<DateTime>("DateBirth");

                    b.Property<string>("Gender");

                    b.Property<int?>("Height");

                    b.Property<int>("Insurance_Id");

                    b.Property<string>("NameFirst")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NameLast")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NameMiddle")
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Rh");

                    b.Property<int>("Role_Id");

                    b.Property<int?>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("Insurance_Id");

                    b.HasIndex("Role_Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("website.Models.Perscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateModify");

                    b.Property<int>("Doctor_Id");

                    b.Property<int>("Faculty_Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Patient_Id");

                    b.HasKey("Id");

                    b.HasIndex("Doctor_Id");

                    b.HasIndex("Faculty_Id");

                    b.HasIndex("Patient_Id");

                    b.ToTable("Perscriptions");
                });

            modelBuilder.Entity("website.Models.PerscriptionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Days");

                    b.Property<int>("Evening");

                    b.Property<int>("Medicine_Id");

                    b.Property<int>("Morning");

                    b.Property<int>("Noon");

                    b.Property<string>("Note");

                    b.Property<int>("Perscription_Id");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("Medicine_Id");

                    b.HasIndex("Perscription_Id");

                    b.ToTable("PerscriptionDetails");
                });

            modelBuilder.Entity("website.Models.Pharamacist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateLastUsed");

                    b.Property<DateTime>("DateModify");

                    b.Property<string>("Email");

                    b.Property<string>("NameFirst")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NameLast")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NameMiddle")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Role_Id");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("Role_Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Pharamacists");
                });

            modelBuilder.Entity("website.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("website.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Faculty_Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Faculty_Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("website.Models.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Session")
                        .IsRequired();

                    b.Property<DateTime>("TimeEnd");

                    b.Property<DateTime>("TimeStart");

                    b.HasKey("Id");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("website.Models.ShiftPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateStart");

                    b.Property<int>("Doctor_Id");

                    b.Property<int>("Room_Id");

                    b.Property<int>("Shift_Id");

                    b.HasKey("Id");

                    b.HasIndex("Doctor_Id");

                    b.HasIndex("Room_Id");

                    b.HasIndex("Shift_Id");

                    b.ToTable("ShiftPlans");
                });

            modelBuilder.Entity("website.Models.WaitingLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Patient_Id");

                    b.Property<int>("Room_Id");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("Patient_Id");

                    b.HasIndex("Room_Id");

                    b.ToTable("WaitingLines");
                });

            modelBuilder.Entity("website.Models.Admin", b =>
                {
                    b.HasOne("website.Models.Role", "Role")
                        .WithMany("Admins")
                        .HasForeignKey("Role_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("website.Models.Bill", b =>
                {
                    b.HasOne("website.Models.Insurance", "Insurance")
                        .WithMany("Bills")
                        .HasForeignKey("Insurance_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("website.Models.Perscription", "Perscription")
                        .WithMany("Bills")
                        .HasForeignKey("Perscription_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("website.Models.Pharamacist", "Pharamacist")
                        .WithMany("Bills")
                        .HasForeignKey("Pharamacist_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("website.Models.Doctor", b =>
                {
                    b.HasOne("website.Models.Faculty", "Faculty")
                        .WithMany("Doctors")
                        .HasForeignKey("Faculty_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("website.Models.Role", "Role")
                        .WithMany("Doctors")
                        .HasForeignKey("Role_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("website.Models.Insurance", b =>
                {
                    b.HasOne("website.Models.InsuranceType", "InsuranceType")
                        .WithMany("Insurances")
                        .HasForeignKey("InsuranceType_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("website.Models.Medicine", b =>
                {
                    b.HasOne("website.Models.Admin", "Admin")
                        .WithMany("Medicines")
                        .HasForeignKey("Admin_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("website.Models.MedicineUnit", "MedicineUnit")
                        .WithMany("Medicines")
                        .HasForeignKey("MedicineUnit_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("website.Models.Patient", b =>
                {
                    b.HasOne("website.Models.Insurance", "Insurance")
                        .WithMany("Patients")
                        .HasForeignKey("Insurance_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("website.Models.Role", "Role")
                        .WithMany("Patients")
                        .HasForeignKey("Role_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("website.Models.Perscription", b =>
                {
                    b.HasOne("website.Models.Doctor", "Doctor")
                        .WithMany("Perscriptions")
                        .HasForeignKey("Doctor_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("website.Models.Faculty", "Faculty")
                        .WithMany("Perscriptions")
                        .HasForeignKey("Faculty_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("website.Models.Patient", "Patient")
                        .WithMany("Perscriptions")
                        .HasForeignKey("Patient_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("website.Models.PerscriptionDetail", b =>
                {
                    b.HasOne("website.Models.Medicine", "Medicine")
                        .WithMany("PerscriptionDetails")
                        .HasForeignKey("Medicine_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("website.Models.Perscription", "Perscription")
                        .WithMany("PerscriptionDetails")
                        .HasForeignKey("Perscription_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("website.Models.Pharamacist", b =>
                {
                    b.HasOne("website.Models.Role", "Role")
                        .WithMany("Pharamacists")
                        .HasForeignKey("Role_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("website.Models.Room", b =>
                {
                    b.HasOne("website.Models.Faculty", "Faculty")
                        .WithMany("Rooms")
                        .HasForeignKey("Faculty_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("website.Models.ShiftPlan", b =>
                {
                    b.HasOne("website.Models.Doctor", "Doctor")
                        .WithMany("ShiftPlans")
                        .HasForeignKey("Doctor_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("website.Models.Room", "Room")
                        .WithMany("ShiftPlans")
                        .HasForeignKey("Room_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("website.Models.Shift", "Shift")
                        .WithMany("ShiftPlans")
                        .HasForeignKey("Shift_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("website.Models.WaitingLine", b =>
                {
                    b.HasOne("website.Models.Patient", "Patient")
                        .WithMany("WaitingLines")
                        .HasForeignKey("Patient_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("website.Models.Room", "Room")
                        .WithMany("WaitingLines")
                        .HasForeignKey("Room_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
