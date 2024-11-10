using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckControllers.Controllers
{
    public class VehicleController
    {
       /* ShipmentDbContext context = new ShipmentDbContext();
        public void AddVehicle(string brand, string model, int year, string licenseNumber)
        {
            context.Vehicles.Add(new Vehicle
            {
                Brand = brand,
                Model = model,
                Year = year,
                LiscenceNumber = licenseNumber
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
        public int GetId(int id)
        {
            var vehicle = context.Vehicles.FirstOrDefault(x => x.Id == id);
            return vehicle.Id;
        }
        public string GetLicensceNumber(string licensceNumber)
        {
            var vehicle = context.Vehicles.FirstOrDefault(x => x.LiscenceNumber == licensceNumber);
            return vehicle.LiscenceNumber;
        }*/
    }
}
