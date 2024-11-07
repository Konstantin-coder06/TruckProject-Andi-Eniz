using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Truck.Data.Entities;

namespace Truck.Data
{
    public class TruckDbContext:DbContext
    {
        public TruckDbContext()
        {

        }
        public TruckDbContext(DbContextOptions<TruckDbContext> options) : base(options)
        {

        }
        public DbSet<CompanyStock> CompaniesStocks { get; set; }
        public DbSet<CompanyStock_Shipment> CompaniesStocks_Shipments { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<TruckCompany> TrucksCompanies { get; set; }
        public DbSet<TruckCompany_Driver> TruckCompanies_Drivers { get; set; }
        public DbSet<TruckCompany_Shipment> TruckCompanies_Shipments { get; set; }
        public DbSet<TruckCompany_Vehicle> TruckCompanies_Vehicles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyStock_Shipment>().HasKey(e => new { e.Shipment_Id, e.CompanyStock_Id });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TruckCompany_Driver>().HasKey(e => new { e.Driver_Id, e.TruckCompany_Id });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TruckCompany_Shipment>().HasKey(e => new { e.Shipment_Id, e.TruckCompany_Id });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TruckCompany_Vehicle>().HasKey(e => new { e.Vehicle_Id, e.TruckCompany_Id });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ShipmentDb;Trusted_Connection=True;");
        }
    }
}
