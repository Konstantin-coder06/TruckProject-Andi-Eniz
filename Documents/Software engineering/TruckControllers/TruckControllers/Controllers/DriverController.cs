using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckControllers.Controllers
{
    public class DriverController
    {
       /* ShipmentDbContext context = new ShipmentDbContext();

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
        public List<string> GetAllInformation(string email)
        {
            var list = new List<string>();
            Driver driver = context.Drivers.FirstOrDefault(x => x.Email == email);
            list.Add(driver.FirstName);
            list.Add(driver.LastName);
            list.Add(driver.Email);
            list.Add(driver.Phone);
            return list;
        }
        public List<string> UpdateInformation(string firstname, string lastname, string email, string phone)
        {
            var updates = new List<string>();
            Driver driver = context.Drivers.FirstOrDefault(x => x.Email == email);
            driver.FirstName = firstname;
            driver.LastName = lastname;
            driver.Phone = phone;
            driver.Email = email;
            context.SaveChanges();
            updates.Add(driver.FirstName);
            updates.Add(driver.LastName);
            updates.Add(driver.Phone);
            updates.Add(driver.Email);
            return updates;
        }
        public List<string> GetAllDriverInfo()
        {
            return context.Drivers.Select(driver => $"{driver.Id}, {driver.FirstName} {driver.LastName}, {driver.DriverPassword}, {driver.Email},{driver.Experience},{driver.Phone},").ToList();
        }
        public void DeleteDriverById(int driverId)
        {
            var driver = context.Drivers.FirstOrDefault(x => x.Id == driverId);
            if (driver != null)
            {
                context.Drivers.Remove(driver);
                context.SaveChanges();
            }
        }
        public int GetDriverId(string email)
        {
            var driver = context.Drivers.FirstOrDefault(x => x.Email == email);
            return driver.Id;
        }
        public int GetId(int id)
        {
            var driver = context.Drivers.FirstOrDefault(x => x.Id == id);
            return driver.Id;
        }
        public string GetEmail(string email)
        {
            var driver = context.Drivers.FirstOrDefault(x => x.Email == email);
            return driver.Email;
        }
        public string GetPassword(string password)
        {
            var driver = context.Drivers.FirstOrDefault(x => x.DriverPassword == password);
            return driver.DriverPassword;
        }*/
    }
}
