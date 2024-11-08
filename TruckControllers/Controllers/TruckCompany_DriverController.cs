using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TruckData;
using System.Threading.Tasks;

namespace TruckControllers.Controllers
{
    public class TruckCompany_DriverController
    {
        ShipmentDbContext context = new ShipmentDbContext();

        public void AddTruckCompanyDriver(int truckCompanyId, int driverId)
        {
            context.TruckCompanies_Drivers.Add(new TruckCompany_Driver
            {
                TruckCompany_Id = truckCompanyId,
                Driver_Id = driverId
            });
            context.SaveChanges();
        }

        public List<TruckCompany_Driver> SeeAllTruckCompanyDrivers()
        {
            return context.TruckCompanies_Drivers.ToList();
        }

        public List<TruckCompany_Driver> SeeTruckCompanyDriversBy(string criteria, string info)
        {
            List<TruckCompany_Driver> drivers = new List<TruckCompany_Driver>();

            if (criteria.ToLower() == "truckcompanyid")
            {
                drivers = context.TruckCompanies_Drivers.Where(x => x.TruckCompany_Id == int.Parse(info)).ToList();
            }
            else if (criteria.ToLower() == "driverid")
            {
                drivers = context.TruckCompanies_Drivers.Where(x => x.Driver_Id == int.Parse(info)).ToList();
            }

            return drivers;
        }

        public void RemoveTruckCompanyDriver(int truckCompanyId, int driverId)
        {
            var truckCompanyDriver = context.TruckCompanies_Drivers
                .FirstOrDefault(x => x.TruckCompany_Id == truckCompanyId && x.Driver_Id == driverId);
            if (truckCompanyDriver != null)
            {
                context.TruckCompanies_Drivers.Remove(truckCompanyDriver);
                context.SaveChanges();
            }
        }

        public void ChangeDataOfTruckCompanyDriver(int truckCompanyId, int driverId, string changedData, string newInfo)
        {
            var truckCompanyDriver = context.TruckCompanies_Drivers
                .FirstOrDefault(x => x.TruckCompany_Id == truckCompanyId && x.Driver_Id == driverId);

            if (truckCompanyDriver != null)
            {
                if (changedData.ToLower() == "truckcompanyid")
                {
                    truckCompanyDriver.TruckCompany_Id = int.Parse(newInfo);
                }
                else if (changedData.ToLower() == "driverid")
                {
                    truckCompanyDriver.Driver_Id = int.Parse(newInfo);
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
