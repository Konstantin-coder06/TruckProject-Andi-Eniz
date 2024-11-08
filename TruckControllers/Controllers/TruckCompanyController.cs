using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckData;

namespace TruckControllers.Controllers
{
    public class TruckCompanyController
    {
        ShipmentDbContext context = new ShipmentDbContext();

        public void AddTruckCompany(string truckCompanyName, string truckCompanyPassword, string mainTruckAddress, string truckCompanyNumber)
        {
            context.TrucksCompanies.Add(new TruckCompany
            {
                TruckCompanyName = truckCompanyName,
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

        public List<TruckCompany> SeeTruckCompaniesBy(string criteria, string info)
        {
            List<TruckCompany> truckCompanies = new List<TruckCompany>();

            if (criteria.ToLower() == "name")
            {
                truckCompanies = context.TrucksCompanies.Where(x => x.TruckCompanyName == info).ToList();
            }
            else if (criteria.ToLower() == "number")
            {
                truckCompanies = context.TrucksCompanies.Where(x => x.TruckCompanyNumber == info).ToList();
            }
            else if (criteria.ToLower() == "address")
            {
                truckCompanies = context.TrucksCompanies.Where(x => x.MainTruckAdress == info).ToList();
            }

            return truckCompanies;
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

        public void ChangeDataOfTruckCompany(int id, string changedData, string newInfo)
        {
            var truckCompany = context.TrucksCompanies.FirstOrDefault(x => x.Id == id);

            if (truckCompany != null)
            {
                if (changedData.ToLower() == "truckcompanyname")
                {
                    truckCompany.TruckCompanyName = newInfo;
                }
                else if (changedData.ToLower() == "truckcompanypassword")
                {
                    truckCompany.TruckCompanyPassword = newInfo;
                }
                else if (changedData.ToLower() == "maintruckadress")
                {
                    truckCompany.MainTruckAdress = newInfo;
                }
                else if (changedData.ToLower() == "truckcompanynumber")
                {
                    truckCompany.TruckCompanyNumber = newInfo;
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
