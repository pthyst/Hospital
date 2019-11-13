using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using website.Models;

namespace website.Data
{
    public class WebsiteDbContext:DbContext
    {
        public WebsiteDbContext(DbContextOptions options) : base(options) { } // Để trống

        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Patient> Patients { get; set;}
        public DbSet<Room> Rooms { get; set; }
        public DbSet<WaitingLine> WaitingLines { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftPlan> ShiftPlans { get; set; }
        public DbSet<Perscription> Perscriptions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<MedicineUnit> MedicineUnits { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Pharamacist> Pharamacists { get; set; }
        public DbSet<PerscriptionDetail> PerscriptionDetails { get; set; }
        public DbSet<Bill> Bills { get; set; }

        // Đánh chỉ mục Unique Index cho các trường trong bảng
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bảng InsuranceType
            modelBuilder.Entity<InsuranceType>().HasIndex(i => i.Type).IsUnique();

            // Bảng Insurance    không có Unique Index
            // Bảng Patient      không có Unique Index

            // Bảng Room
            modelBuilder.Entity<Room>().HasIndex(r => r.Name).IsUnique();

            // Bảng WaitingLine không có Unique Index

            // Bảng Faculty
            modelBuilder.Entity<Faculty>().HasIndex(f => f.Name).IsUnique();

            // Bảng Doctor
            modelBuilder.Entity<Doctor>().HasIndex(d => d.Username).IsUnique();
            modelBuilder.Entity<Doctor>().HasIndex(d => d.PhoneNumber).IsUnique();
            modelBuilder.Entity<Doctor>().HasIndex(d => d.Email).IsUnique();

            // Bảng Shift        không có Unique Index
            // Bảng ShiftPlan    không có Unique Index
            // Bảng Perscription không có Unique Index

            // Bảng Role
            modelBuilder.Entity<Role>().HasIndex(r => r.Name).IsUnique();

            // Bảng Admin
            modelBuilder.Entity<Admin>().HasIndex(a => a.Username).IsUnique();

            // Bảng MedicineUnit
            modelBuilder.Entity<MedicineUnit>().HasIndex(m => m.Unit).IsUnique();

            // Bảng Medicine
            modelBuilder.Entity<Medicine>().HasIndex(m => m.Name).IsUnique();

            // Bảng Pharamacist
            modelBuilder.Entity<Pharamacist>().HasIndex(p => p.Username).IsUnique();
            modelBuilder.Entity<Pharamacist>().HasIndex(p => p.PhoneNumber).IsUnique();
            modelBuilder.Entity<Pharamacist>().HasIndex(p => p.Email).IsUnique();

            // Bảng PerscriptionDetail không có Unique Index
            // Bảng Bill               không có Unique Index


        }
    }
}
