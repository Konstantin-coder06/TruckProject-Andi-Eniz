using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckControllers.Controllers
{
    public class TruckCompanyController
    {
        /*ShipmentDbContext context = new ShipmentDbContext();

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

        public List<TruckCompany> SeeTruckCompaniesBy(string criteria, string info)
        {
            List<TruckCompany> truckCompanies = new List<TruckCompany>();

            if (criteria.ToLower() == "name")
            {
                truckCompanies = context.TrucksCompanies.Where(x => x.TruckCompanyName == info).ToList();
            }
            else if (criteria.ToLower() == "email")
            {
                truckCompanies = context.TrucksCompanies.Where(x => x.TruckCompanyEmail == info).ToList();
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
        public List<string> GetAllTruckCompanyInfo()
        {
            return context.TrucksCompanies.Select(truckCompany => $"{truckCompany.Id}, {truckCompany.TruckCompanyName} {truckCompany.TruckCompanyEmail}, {truckCompany.TruckCompanyPassword}, {truckCompany.MainTruckAdress},{truckCompany.TruckCompanyNumber}").ToList();
        }
        public void DeleteDriverById(int truckCompanyId)
        {
            var truckCompany = context.TrucksCompanies.FirstOrDefault(x => x.Id == truckCompanyId);
            if (truckCompany != null)
            {
                context.TrucksCompanies.Remove(truckCompany);
                context.SaveChanges();
            }
        }
        public int GetTruckCompanyId(string email)
        {
            var truckCompany = context.TrucksCompanies.FirstOrDefault(x => x.TruckCompanyEmail == email);
            return truckCompany.Id;
        }
        public int GetId(int id)
        {
            var truckCompany = context.TrucksCompanies.FirstOrDefault(x => x.Id == id);
            return truckCompany.Id;
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
        }*/
    }
}
