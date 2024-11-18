using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckData.Data.Entities;
using TruckData.Data;

namespace TruckControllers.Controllers
{
    public class CompanyStockController
    {
        ShipmentDbContext context = new ShipmentDbContext();

        public void AddCompanyStock(string companyName,string email, string companyPassword, string companyNumber, string mainAddress)
        {
            context.CompaniesStocks.Add(new CompanyStock
            {
                CompanyName = companyName,
                CompanyEmail = email,
                CompanyPassword = companyPassword,
                CompanyNumber = companyNumber,
                MainAdress = mainAddress
            });
            context.SaveChanges();
        }

        public List<CompanyStock> SeeAllCompanyStocks()
        {
            return context.CompaniesStocks.ToList();
        }

        public List<CompanyStock> SeeCompanyStocksBy(string criteria, string info)
        {
            List<CompanyStock> companyStocks = new List<CompanyStock>();

            if (criteria.ToLower() == "name")
            {
                companyStocks = context.CompaniesStocks.Where(x => x.CompanyName == info).ToList();
            }
            else if (criteria.ToLower() == "number")
            {
                companyStocks = context.CompaniesStocks.Where(x => x.CompanyNumber == info).ToList();
            }
            else if (criteria.ToLower() == "address")
            {
                companyStocks = context.CompaniesStocks.Where(x => x.MainAdress == info).ToList();
            }

            return companyStocks;
        }
        public List<string> GetAllInformation(string email)
        {
            var list = new List<string>();
            CompanyStock companyStock = context.CompaniesStocks.FirstOrDefault(x => x.CompanyEmail == email);
            list.Add(companyStock.CompanyName);
            list.Add(companyStock.CompanyEmail);
            list.Add(companyStock.CompanyPassword);
            list.Add(companyStock.CompanyNumber);
            list.Add(companyStock.MainAdress);
            return list;
        }
        public List<string> UpdateInformation(string companyName, string companyEmail, string companyPassword, string companyNumber, string mainAdress)
        {
            var updates = new List<string>();
            CompanyStock companyStock = context.CompaniesStocks.FirstOrDefault(x => x.CompanyEmail == companyEmail);
            companyStock.CompanyName = companyName;
            companyStock.CompanyEmail = companyEmail;
            companyStock.CompanyPassword = companyPassword;
            companyStock.CompanyNumber = companyNumber;
            companyStock.MainAdress = mainAdress;
            context.SaveChanges();
            updates.Add(companyStock.CompanyName);
            updates.Add(companyStock.CompanyEmail);
            updates.Add(companyStock.CompanyPassword);
            updates.Add(companyStock.CompanyNumber);
            updates.Add(companyStock.MainAdress);
            return updates;
        }
        public string GetAllStocksInfo()
        {
            string output = "";

            var drivers = context.CompaniesStocks.Where(x=>x.Id!=2)
                .ToList();

            foreach (var driver in drivers)
            {

                output += $"--{driver.Id}--Name: {driver.CompanyName}, {driver.CompanyEmail}, Company Number: {driver.CompanyNumber}, Main Adress {driver.MainAdress}\n\n";

            }
            return output;
        }
        public void DeleteCompanyStockById(int companyStockId)
        {
            var companyStock = context.CompaniesStocks.FirstOrDefault(x => x.Id == companyStockId);
            if (companyStock != null)
            {
                context.CompaniesStocks.Remove(companyStock);
                context.SaveChanges();
            }
        }
        public int GetCompanyStockssId()
        {
            var companyStock = context.CompaniesStocks.OrderByDescending(x=>x.Id).FirstOrDefault();
            if (companyStock == null)
            {
                throw new Exception("Company stock with the specified email was not found.");
            }
            return companyStock.Id;
        }
        public int GetCompanyStockId(string email)
        {
            var companyStock = context.CompaniesStocks.FirstOrDefault(x=>x.CompanyEmail==email);
            if (companyStock == null)
            {
                throw new Exception("Company stock with the specified email was not found.");
            }
            return companyStock.Id;
        }
        public List<int> GetId()
        {
           return context.CompaniesStocks.Select(x=>x.Id).Where(x=>x!=2).ToList();
           
        }
        public string GetEmail(string email)
        {
            var companyStock = context.CompaniesStocks.FirstOrDefault(x => x.CompanyEmail == email);
            return companyStock.CompanyEmail;
        }
        public string GetPassword(string password)
        {
            var companyStock = context.CompaniesStocks.FirstOrDefault(x => x.CompanyPassword == password);
            return companyStock.CompanyPassword;
        }
        public string SingInCompanyStock(string email, string password)
        {
            var driver = context.CompaniesStocks.FirstOrDefault(x => x.CompanyEmail == email && x.CompanyPassword == password);
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
        public void AddToMapping(int companyId,int shipmentId)
        {
            var shipment = context.CompaniesStocks_Shipments.FirstOrDefault(x => x.Shipment_Id == shipmentId && x.CompanyStock_Id == companyId);
            if (shipment == null)
            {
                CompanyStock_Shipment companyStock_Shipment = new CompanyStock_Shipment()
                {
                    Shipment_Id = shipmentId,
                    CompanyStock_Id = companyId
                };
                context.Add(companyStock_Shipment);
                context.SaveChanges();
            }
        }
    }
}

