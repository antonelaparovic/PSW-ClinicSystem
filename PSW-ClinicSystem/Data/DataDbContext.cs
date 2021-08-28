using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }

        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Pharmacist> Pharmacist { get; set; }
        public DbSet<Pharmacy> Pharmacy { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Referral> Referral { get; set; }
        public DbSet<SpecialistField> SpecialistField { get; set; }







        // public class YourDbContextFactory : IDesignTimeDbContextFactory<DataDbContext>
        // {
        //     public DataDbContext CreateDbContext(string[] args)
        //     {
        //         var optionsBuilder = new DbContextOptionsBuilder<DataDbContext>();
        //         optionsBuilder.UseMySQL("server=localhost;user=root;database=ClinicDb;password=vanjaana1321");

        //         return new DataDbContext(optionsBuilder.Options);
        //     }
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseMySQL("server=localhost;user=root;database=ClinicDb;password=vanjaana1321");
        }
    }
}
