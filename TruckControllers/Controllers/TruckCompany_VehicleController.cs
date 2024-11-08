using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckData;


namespace TruckControllers.Controllers
{
    public class TruckCompany_VehicleController
    {
        ShipmentDbContext context = new ShipmentDbContext();

        public void AddTruckCompanyVehicle(int truckCompanyId, int vehicleId)
        {
            context.TruckCompanies_Vehicles.Add(new TruckCompany_Vehicle
            {
                TruckCompany_Id = truckCompanyId,
                Vehicle_Id = vehicleId
            });
            context.SaveChanges();
        }

        public List<TruckCompany_Vehicle> SeeAllTruckCompanyVehicles()
        {
            return context.TruckCompanies_Vehicles.ToList();
        }

        public List<TruckCompany_Vehicle> SeeTruckCompanyVehiclesBy(string criteria, string info)
        {
            List<TruckCompany_Vehicle> vehicles = new List<TruckCompany_Vehicle>();

            if (criteria.ToLower() == "truckcompanyid")
            {
                vehicles = context.TruckCompanies_Vehicles.Where(x => x.TruckCompany_Id == int.Parse(info)).ToList();
            }
            else if (criteria.ToLower() == "vehicleid")
            {
                vehicles = context.TruckCompanies_Vehicles.Where(x => x.Vehicle_Id == int.Parse(info)).ToList();
            }

            return vehicles;
        }

        public void RemoveTruckCompanyVehicle(int truckCompanyId, int vehicleId)
        {
            var truckCompanyVehicle = context.TruckCompanies_Vehicles
                .FirstOrDefault(x => x.TruckCompany_Id == truckCompanyId && x.Vehicle_Id == vehicleId);
            if (truckCompanyVehicle != null)
            {
                context.TruckCompanies_Vehicles.Remove(truckCompanyVehicle);
                context.SaveChanges();
            }
        }

        public void ChangeDataOfTruckCompanyVehicle(int truckCompanyId, int vehicleId, string changedData, string newInfo)
        {
            var truckCompanyVehicle = context.TruckCompanies_Vehicles
                .FirstOrDefault(x => x.TruckCompany_Id == truckCompanyId && x.Vehicle_Id == vehicleId);

            if (truckCompanyVehicle != null)
            {
                if (changedData.ToLower() == "truckcompanyid")
                {
                    truckCompanyVehicle.TruckCompany_Id = int.Parse(newInfo);
                }
                else if (changedData.ToLower() == "vehicleid")
                {
                    truckCompanyVehicle.Vehicle_Id = int.Parse(newInfo);
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
