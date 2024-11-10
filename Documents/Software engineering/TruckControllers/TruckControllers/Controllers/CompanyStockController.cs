using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckControllers.Controllers
{
    public class CompanyStockController
    {
        /*ShipmentDbContext context = new ShipmentDbContext();

        public void AddCompanyStock(string companyName, string companyPassword, string companyNumber, string mainAddress)
        {
            context.CompaniesStocks.Add(new CompanyStock
            {
                CompanyName = companyName,
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
        public List<string> GetAllStocksInfo()
        {
            return context.CompaniesStocks.Select(companyStock => $"{companyStock.Id}, {companyStock.CompanyName} {companyStock.CompanyEmail}, {companyStock.CompanyPassword}, {companyStock.CompanyNumber},{companyStock.MainAdress},").ToList();
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
        public int GetCompanyStockId(string email)
        {
            var companyStock = context.CompaniesStocks.FirstOrDefault(x => x.CompanyEmail == email);
            return companyStock.Id;
        }
        public int GetId(int id)
        {
            var companyStock = context.CompaniesStocks.FirstOrDefault(x => x.Id == id);
            return companyStock.Id;
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
        }*/

    }
}

