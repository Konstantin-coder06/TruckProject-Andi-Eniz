using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckData;

namespace TruckControllers.Controllers
{
    public class CompanyStockController
    {
        ShipmentDbContext context = new ShipmentDbContext();

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

        public void RemoveCompanyStock(int companyStockId)
        {
            var companyStock = context.CompaniesStocks.FirstOrDefault(x => x.Id == companyStockId);
            if (companyStock != null)
            {
                context.CompaniesStocks.Remove(companyStock);
                context.SaveChanges();
            }
        }
        public void ChangeDataOfCompanyStock(int id, string changedData, string newInfo)
        {
            var companyStock = context.CompaniesStocks.FirstOrDefault(x => x.Id == id);

            if (companyStock != null)
            {
                if (changedData.ToLower() == "companyname")
                {
                    companyStock.CompanyName = newInfo;
                }
                else if (changedData.ToLower() == "companypassword")
                {
                    companyStock.CompanyPassword = newInfo;
                }
                else if (changedData.ToLower() == "companynumber")
                {
                    companyStock.CompanyNumber = newInfo;
                }
                else if (changedData.ToLower() == "mainadress")
                {
                    companyStock.MainAdress = newInfo;
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
