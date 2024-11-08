using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TruckData;
using System.Threading.Tasks;

namespace TruckControllers.Controllers
{
    public class VehicleController
    {
        ShipmentDbContext context = new ShipmentDbContext();

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

        public void RemoveVehicle(int vehicleId)
        {
            var vehicle = context.Vehicles.FirstOrDefault(x => x.Id == vehicleId);
            if (vehicle != null)
            {
                context.Vehicles.Remove(vehicle);
                context.SaveChanges();
            }
        }
        public void ChangeDataOfVehicle(int id, string changedData, string newInfo)
        {
            var vehicle = context.Vehicles.FirstOrDefault(x => x.Id == id);

            if (vehicle != null)
            {
                if (changedData.ToLower() == "brand")
                {
                    vehicle.Brand = newInfo;
                }
                else if (changedData.ToLower() == "model")
                {
                    vehicle.Model = newInfo;
                }
                else if (changedData.ToLower() == "year")
                {
                    vehicle.Year = int.Parse(newInfo);
                }
                else if (changedData.ToLower() == "liscencenumber")
                {
                    vehicle.LiscenceNumber = newInfo;
                }
                else
                {
                    throw new ArgumentException("No such data type to change!");
                }
                context.SaveChanges();
            }
        }

    }
}
