using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckData;

namespace TruckControllers.Controllers
{
    public class DriverController
    {
        ShipmentDbContext context = new ShipmentDbContext();

        public void AddDriver(string firstName, string lastName, string driverPassword, string email, int experience, string phone)
        {
            context.Drivers.Add(new Driver
            {
                FirstName = firstName,
                LastName = lastName,
                DriverPassword = driverPassword,
                Email = email,
                Experience = experience,
                Phone = phone
            });
            context.SaveChanges();
        }

        public List<Driver> SeeAllDrivers()
        {
            return context.Drivers.ToList();
        }

        public List<Driver> SeeDriversBy(string criteria, string info)
        {
            List<Driver> drivers = new List<Driver>();

            if (criteria.ToLower() == "name")
            {
                drivers = context.Drivers.Where(x => x.FirstName == info || x.LastName == info).ToList();
            }
            else if (criteria.ToLower() == "email")
            {
                drivers = context.Drivers.Where(x => x.Email == info).ToList();
            }
            else if (criteria.ToLower() == "experience")
            {
                drivers = context.Drivers.Where(x => x.Experience == int.Parse(info)).ToList();
            }

            return drivers;
        }

        public string GetDriverTruckCompany(int driverId)
        {
            var truckCompanyDriver = context.TruckCompanies_Drivers
                .FirstOrDefault(x => x.Driver_Id == driverId);

            if (truckCompanyDriver != null)
            {
                var truckCompany = context.TrucksCompanies
                    .FirstOrDefault(tc => tc.Id == truckCompanyDriver.TruckCompany_Id);
                
            }
            return "Driver not associated with any truck company.";
        }

        public void RemoveDriver(int driverId)
        {
            var driver = context.Drivers.FirstOrDefault(x => x.Id == driverId);
            if (driver != null)
            {
                context.Drivers.Remove(driver);
                context.SaveChanges();
            }
        }
        public void ChangeDataOfDriver(int id, string changedData, string newInfo)
        {
            var driver = context.Drivers.FirstOrDefault(x => x.Id == id);

            if (driver != null)
            {
                if (changedData.ToLower() == "firstname")
                {
                    driver.FirstName = newInfo;
                }
                else if (changedData.ToLower() == "lastname")
                {
                    driver.LastName = newInfo;
                }
                else if (changedData.ToLower() == "driverpassword")
                {
                    driver.DriverPassword = newInfo;
                }
                else if (changedData.ToLower() == "email")
                {
                    driver.Email = newInfo;
                }
                else if (changedData.ToLower() == "experience")
                {
                    driver.Experience = int.Parse(newInfo);
                }
                else if (changedData.ToLower() == "phone")
                {
                    driver.Phone = newInfo;
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
