using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckData.Data.Entities;
using TruckData.Data;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace TruckControllers.Controllers
{
    public class DriverController
    {
        ShipmentDbContext context = new ShipmentDbContext();

        public void AddDriver(string firstName, string lastName, string driverPassword, string email, int experience, string phone,int truckId)
        {
           

           

                context.Drivers.Add(new Driver
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DriverPassword = driverPassword,
                    Email = email,
                    Experience = experience,
                    Phone = phone,
                    TruckCompanyId = truckId

                });
                context.SaveChanges();
           
           
        }

        public List<Driver> SeeAllDrivers()
        {
            return context.Drivers.ToList();
        }

        public void UpdateDriver(string criteria,int id, string info)
        {
         
            if (criteria.ToLower() == "firstname")
            {
                var driverPhone = context.Drivers.FirstOrDefault(x => x.Id == id);
                driverPhone.FirstName = info;

                context.SaveChanges();
              
            }
            if (criteria.ToLower() == "lastname")
            {
                var driverPhone = context.Drivers.FirstOrDefault(x => x.Id == id);
                driverPhone.LastName = info;

                context.SaveChanges();
              
            }
            else if (criteria.ToLower() == "email")
            {
                var driverPhone = context.Drivers.FirstOrDefault(x => x.Id == id);
                driverPhone.Email = info;

                context.SaveChanges();
            }
            if (criteria.ToLower() == "phone")
            {
                var driverPhone = context.Drivers.FirstOrDefault(x => x.Id == id);
                driverPhone.Phone = info;
             
                context.SaveChanges();
            }

        }

        public string GetDriverTruckCompany(int driverId)
        {
            /*var truckCompanyDriver = context.TruckCompanies_Drivers
                .FirstOrDefault(x => x.Driver_Id == driverId);

            if (truckCompanyDriver != null)
            {
                var truckCompany = context.TrucksCompanies
                    .FirstOrDefault(tc => tc.Id == truckCompanyDriver.TruckCompany_Id);

            }*/
            return "Driver not associated with any truck company.";
        }
        public string GetAllDriversFromTruckCompany(int companyId)
        {
            var drivers=context.Drivers.Where(x=>x.TruckCompanyId == companyId).ToList();
            string output = "";
            foreach (var driver in drivers)
            {
                output += $"First name: {driver.FirstName}\nLast name: {driver.LastName}\nEmail: {driver.Email}\nXP: {driver.Experience}\nPhone: {driver.Phone}\n\n";
            }
            return output;
        }
        public int DriverCompany(string email)
        {
            var driver=context.Drivers.FirstOrDefault(x=>x.Email == email);
            return driver.TruckCompanyId;
        }
        public int DriverId()
        {
            var driver = context.Drivers.OrderByDescending(x=>x.Id).FirstOrDefault();
            return driver.TruckCompanyId;
        }
        public int DriverId(string name)
        {
            var driver = context.Drivers.FirstOrDefault(x => x.FirstName == name);
            return driver.Id;
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
        public string GetAllDriverInfo()
        {
            string output = "";
         
            var drivers= context.Drivers.Select(driver => $"--{driver.Id}--\n  First name: {driver.FirstName}\n  Last name: {driver.LastName}\n  Email: {driver.Email}\n  XP: {driver.Experience}\n  Phone{driver.Phone}\n\n").ToList();
            foreach ( var driver in drivers )
            {
                output += $"{driver}\n\n";
            }
            return output;
        }
        public string GetAllDriverInfoByCompany(int companyId)
        {
            string output = "";

            var drivers = context.Drivers.Where(x=>x.TruckCompanyId==companyId).Select(driver => $"--{driver.Id}--\n  First name: {driver.FirstName}\n  Last name: {driver.LastName}\n  Email: {driver.Email}\n  XP: {driver.Experience}\n  Phone{driver.Phone}\n\n").ToList();
            foreach (var driver in drivers)
            {
                output += $"{driver}\n\n";
            }
            return output;
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
        public List<int> GetDriversId()
        {
          return  context.Drivers.Select(x=>x.Id).ToList();
         
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
        }
        public string SingInDriver(string email, string password)
        {
            var driver = context.Drivers.FirstOrDefault(x => x.Email == email && x.DriverPassword == password);
            string output = "";
            if (driver != null)
            {
                output = "Успешно влязохте";
            }
            else
            {
                output = "Няма такъв шофьор";

            }
            return output;
        }
        public string GetDriverName(string email, string password)
        {
            var driver = context.Drivers.FirstOrDefault(x => x.Email == email && x.DriverPassword == password);
            string output = "";
            if (driver != null)
            {
                output = $"{driver.FirstName}";
            }
            else
            {
                output = "Няма такъв шофьор";

            }
            return output;
        }
        public List<string> DriversFirstName(int truckId)
        {
            return context.Drivers.Where(x => x.TruckCompanyId == truckId).Select(x=>x.FirstName).ToList();
           

           
        }
    }
}
