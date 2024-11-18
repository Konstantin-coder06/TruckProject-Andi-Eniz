using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckData.Data.Entities;
using TruckData.Data;
namespace TruckControllers.Controllers
{
    public class VehicleController
    {
        ShipmentDbContext context = new ShipmentDbContext();
        public void AddVehicle(string brand, string model, int year, string licenseNumber,int companyId)
        {
            context.Vehicles.Add(new Vehicle
            {
                Brand = brand,
                Model = model,
                Year = year,
                LiscenceNumber = licenseNumber,
                TruckCompanyId=companyId
            });
            context.SaveChanges();
        }

        public List<Vehicle> SeeAllVehicles()
        {
            return context.Vehicles.ToList();
        }

        public List<Vehicle> SeeVehiclesBy(string criteria, string info)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            if (criteria.ToLower() == "brand")
            {
                vehicles = context.Vehicles.Where(x => x.Brand == info).ToList();
            }
            else if (criteria.ToLower() == "model")
            {
                vehicles = context.Vehicles.Where(x => x.Model == info).ToList();
            }
            else if (criteria.ToLower() == "year")
            {
                vehicles = context.Vehicles.Where(x => x.Year == int.Parse(info)).ToList();
            }
            else if (criteria.ToLower() == "license")
            {
                vehicles = context.Vehicles.Where(x => x.LiscenceNumber == info).ToList();
            }

            return vehicles;
        }

        public List<string> GetAllInformation(string licensceNumber)
        {
            var list = new List<string>();
            Vehicle vehicle = context.Vehicles.FirstOrDefault(x => x.LiscenceNumber == licensceNumber);
            list.Add(vehicle.Brand);
            list.Add(vehicle.Model);
            list.Add(vehicle.Year.ToString());
            list.Add(vehicle.LiscenceNumber);
            return list;
        }
        public List<string> UpdateInformation(string brand, string model, int year, string licensceNumber)
        {
            var updates = new List<string>();
            Vehicle vehicle = context.Vehicles.FirstOrDefault(x => x.LiscenceNumber == licensceNumber);
            vehicle.Brand = brand;
            vehicle.Model = model;
            vehicle.Year = year;
            vehicle.LiscenceNumber = licensceNumber;
            context.SaveChanges();
            updates.Add(vehicle.Brand);
            updates.Add(vehicle.Model);
            updates.Add(vehicle.Year.ToString());
            updates.Add(vehicle.LiscenceNumber);
            return updates;
        }
        public List<string> GetAllVehicleInfo()
        {
            return context.Vehicles.Select(vehicle => $"{vehicle.Id}, {vehicle.Brand} {vehicle.Model}, {vehicle.Year}, {vehicle.LiscenceNumber},").ToList();
        }
        public void DeleteVehicleById(int vehicleId)
        {
            var vehicle = context.Vehicles.FirstOrDefault(x => x.Id == vehicleId);
            if (vehicle != null)
            {
                context.Vehicles.Remove(vehicle);
                context.SaveChanges();
            }
        }
        public int GetVehicleId(string licensceNumber)
        {
            var vehicle = context.Vehicles.FirstOrDefault(x => x.LiscenceNumber == licensceNumber);
            return vehicle.Id;
        }
      
        public string GetLicensceNumber(string licensceNumber)
        {
            var vehicle = context.Vehicles.FirstOrDefault(x => x.LiscenceNumber == licensceNumber);
            return vehicle.LiscenceNumber;
        }
        public List<string> VehicleOneCompany(int truckid)
        {
             //context.Drivers.Where(x => x.TruckCompanyId == truckId).Select(x => x.FirstName).ToList();
            return context.Vehicles.Where(x => x.TruckCompanyId == truckid).Select(x => x.Brand).ToList();
        }
        public int VehicleId(string name)
        {
            var driver = context.Vehicles.FirstOrDefault(x => x.Brand == name);
            return driver.Id;
        }
    }
}
