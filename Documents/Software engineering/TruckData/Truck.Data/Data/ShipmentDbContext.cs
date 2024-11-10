using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckData.Data.Entities;

namespace TruckData.Data
{
    public class ShipmentDbContext : DbContext
    {
        public ShipmentDbContext() : base()
        {

        }
        public DbSet<CompanyStock> CompaniesStocks { get; set; }
        public DbSet<CompanyStock_Shipment> CompaniesStocks_Shipments { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<TruckCompany> TrucksCompanies { get; set; }
    
        public DbSet<TruckCompany_Shipment>TruckCompanies_Shipments { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyStock_Shipment>().HasKey(e => new { e.Shipment_Id, e.CompanyStock_Id });
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<TruckCompany_Shipment>().HasKey(e => new { e.Shipment_Id, e.TruckCompany_Id });
            base.OnModelCreating(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ShipmentDb;Trusted_Connection=True;");
        }
    }
}
