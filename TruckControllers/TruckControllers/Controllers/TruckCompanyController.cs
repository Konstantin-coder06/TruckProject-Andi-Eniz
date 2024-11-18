using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckData.Data.Entities;
using TruckData.Data;
using System.Security.Cryptography.X509Certificates;

namespace TruckControllers.Controllers
{
    public class TruckCompanyController
    {
        ShipmentDbContext context = new ShipmentDbContext();

        public void AddTruckCompany(string truckCompanyName, string truckCompanyEmail, string truckCompanyPassword, string mainTruckAddress, string truckCompanyNumber)
        {
            context.TrucksCompanies.Add(new TruckCompany
            {
                TruckCompanyName = truckCompanyName,
                TruckCompanyEmail = truckCompanyEmail,
                TruckCompanyPassword = truckCompanyPassword,
                MainTruckAdress = mainTruckAddress,
                TruckCompanyNumber = truckCompanyNumber
            });
            context.SaveChanges();
        }

        public List<TruckCompany> SeeAllTruckCompanies()
        {
            return context.TrucksCompanies.ToList();
        }
        public string GetIdOfCompany(string name)
        {
           var company= context.TrucksCompanies.FirstOrDefault(x => x.TruckCompanyName == name);
            return company.Id.ToString();
        }
        public int IdOfCompany(int id)
        {
            int idcom=0;
           var company=context.TrucksCompanies.FirstOrDefault(x=>x.Id==id);
            if (company != null)
            {
                idcom = company.Id;
            }
            else { idcom = 0; }
            return idcom;
        }
        public void UpdateCompany(string criteria,int id, string info)
        {
            List<TruckCompany> truckCompanies = new List<TruckCompany>();

            if (criteria.ToLower() == "name")
            {
                var trucks=context.TrucksCompanies.FirstOrDefault(x=>x.Id == id);
                trucks.TruckCompanyName = info;
                context.SaveChanges();
                
            }
            else if (criteria.ToLower() == "email")
            {
                var trucks = context.TrucksCompanies.FirstOrDefault(x => x.Id == id);
                trucks.TruckCompanyEmail = info;
                context.SaveChanges();
            }
            else if (criteria.ToLower() == "companynumber")
            {
                var trucks = context.TrucksCompanies.FirstOrDefault(x => x.Id == id);
                trucks.TruckCompanyNumber = info;
                context.SaveChanges();
            }
            else if (criteria.ToLower() == "mainaddress")
            {
                var trucks = context.TrucksCompanies.FirstOrDefault(x => x.Id == id);
                trucks.MainTruckAdress = info;
                context.SaveChanges();
            }

           
        }

        public void RemoveTruckCompany(int truckCompanyId)
        {
            var truckCompany = context.TrucksCompanies.FirstOrDefault(x => x.Id == truckCompanyId);
            if (truckCompany != null)
            {
                context.TrucksCompanies.Remove(truckCompany);
                context.SaveChanges();
            }
        }
        public int GetComponyId(string email)
        {
            var companyStock = context.TrucksCompanies.FirstOrDefault(x => x.TruckCompanyEmail == email);
            return companyStock.Id;
        }

        public List<string> GetAllInformation(string email)
        {
            var list = new List<string>();
            TruckCompany truckcompany = context.TrucksCompanies.FirstOrDefault(x => x.TruckCompanyEmail == email);
            list.Add(truckcompany.TruckCompanyName);
            list.Add(truckcompany.TruckCompanyEmail);
            list.Add(truckcompany.TruckCompanyPassword);
            list.Add(truckcompany.MainTruckAdress);
            list.Add(truckcompany.TruckCompanyNumber);
            return list;
        }
        public List<string> UpdateInformation(string name, string email, string password, string mainadress, string number)
        {
            var updates = new List<string>();
            TruckCompany truckCompany = context.TrucksCompanies.FirstOrDefault(x => x.TruckCompanyEmail == email);
            truckCompany.TruckCompanyName = name;
            truckCompany.TruckCompanyEmail = email;
            truckCompany.TruckCompanyPassword = password;
            truckCompany.MainTruckAdress = mainadress;
            truckCompany.TruckCompanyNumber = number;
            context.SaveChanges();
            updates.Add(truckCompany.TruckCompanyName);
            updates.Add(truckCompany.TruckCompanyEmail);
            updates.Add(truckCompany.TruckCompanyNumber);
            updates.Add(truckCompany.MainTruckAdress);
            updates.Add(truckCompany.TruckCompanyNumber);
            return updates;
        }
        public string GetAllTruckCompanyInfo()
        {
            string output = "";

            var drivers = context.TrucksCompanies.Select(truckCompany => $"--{truckCompany.Id}--Name: {truckCompany.TruckCompanyName} {truckCompany.TruckCompanyEmail},Main Adress:  {truckCompany.MainTruckAdress}, Company Number{truckCompany.TruckCompanyNumber}").ToList();

            foreach (var driver in drivers)
            {
                output += $"{driver}\n\n";
            }
            return output;
        }
        public List<string> GetNameofTruckCompanyInfo()
        {
            return context.TrucksCompanies.Select(truckCompany => $"{truckCompany.Id} {truckCompany.TruckCompanyName}").ToList();
            
        }
        public int CompanyId()
        {
            var driver = context.TrucksCompanies.OrderByDescending(x => x.Id).FirstOrDefault();
            return driver.Id;
        }
        public void DeleteTruckById(int truckCompanyId)
        {
            var truckCompany = context.TrucksCompanies.FirstOrDefault(x => x.Id == truckCompanyId);
            if (truckCompany != null)
            {
                context.TrucksCompanies.Remove(truckCompany);
                context.SaveChanges();
            }
        }
        public List<int> GetTrucksId()
        {
            return context.Drivers.Select(x => x.Id).ToList();

        }

        public string GetEmail(string email)
        {
            var truckCompany = context.TrucksCompanies.FirstOrDefault(x => x.TruckCompanyEmail == email);
            return truckCompany.TruckCompanyEmail;
        }
        public string GetPassword(string password)
        {
            var truckCompany = context.TrucksCompanies.FirstOrDefault(x => x.TruckCompanyPassword == password);
            return truckCompany.TruckCompanyPassword;
        }
        public string SingInTruckCompany(string email, string password)
        {
            var truckCompany = context.TrucksCompanies.FirstOrDefault(x => x.TruckCompanyEmail == email && x.TruckCompanyPassword == password);
            string output = "";
            if (truckCompany != null)
            {
                output = "Успешно влязохте";
            }
            else
            {
                output = "Няма такъв шофьор";

            }
            return output;
        }
        public string OneTruckInfo(int id)
        {
            var truck=context.TrucksCompanies.FirstOrDefault(x=>x.Id== id);
            return $"Name:{truck.TruckCompanyName}\nEmail: {truck.TruckCompanyEmail}\nMain address: {truck.MainTruckAdress}\nCompany number {truck.TruckCompanyNumber}";
        }
        public void AddToMapping(int idTruck, int idShipment,int driverid,int vehicleid)
        {
            TruckCompany_Shipment truckCompany_Shipment = new TruckCompany_Shipment()
            {
                TruckCompany_Id = idTruck,
                Shipment_Id = idShipment,
                DriverId = driverid,
                VehicleId = vehicleid
            };
            context.Add(truckCompany_Shipment);
            context.SaveChanges();

          /*  var companyTruck=context.TrucksCompanies.FirstOrDefault(x=>x.Id== idTruck);            var mapping = context.TruckCompanies_Shipments.Where(x => x.TruckCompany_Id == companyTruck.Id);
            foreach ( var mappingItem in mapping)
            {
                var shipments=
            }*/
        }
    }
}
