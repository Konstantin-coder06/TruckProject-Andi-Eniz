using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TruckData;
using System.Threading.Tasks;

namespace TruckControllers.Controllers
{
    public class CompanyStock_ShipmentController
    {
        ShipmentDbContext context = new ShipmentDbContext();

        public void AddCompanyStockShipment(int companyStockId, int shipmentId)
        {
            context.CompaniesStocks_Shipments.Add(new CompanyStock_Shipment
            {
                CompanyStock_Id = companyStockId,
                Shipment_Id = shipmentId
            });
            context.SaveChanges();
        }

        public List<CompanyStock_Shipment> SeeAllCompanyStockShipments()
        {
            return context.CompaniesStocks_Shipments.ToList();
        }

        public List<CompanyStock_Shipment> SeeCompanyStockShipmentsBy(string criteria, string info)
        {
            List<CompanyStock_Shipment> shipments = new List<CompanyStock_Shipment>();

            if (criteria.ToLower() == "companystockid")
            {
                shipments = context.CompaniesStocks_Shipments.Where(x => x.CompanyStock_Id == int.Parse(info)).ToList();
            }
            else if (criteria.ToLower() == "shipmentid")
            {
                shipments = context.CompaniesStocks_Shipments.Where(x => x.Shipment_Id == int.Parse(info)).ToList();
            }

            return shipments;
        }

        public void RemoveCompanyStockShipment(int companyStockId, int shipmentId)
        {
            var companyStockShipment = context.CompaniesStocks_Shipments
                .FirstOrDefault(x => x.CompanyStock_Id == companyStockId && x.Shipment_Id == shipmentId);
            if (companyStockShipment != null)
            {
                context.CompaniesStocks_Shipments.Remove(companyStockShipment);
                context.SaveChanges();
            }
        }

        public void ChangeDataOfCompanyStockShipment(int companyStockId, int shipmentId, string changedData, string newInfo)
        {
            var companyStockShipment = context.CompaniesStocks_Shipments
                .FirstOrDefault(x => x.CompanyStock_Id == companyStockId && x.Shipment_Id == shipmentId);

            if (companyStockShipment != null)
            {
                if (changedData.ToLower() == "companystockid")
                {
                    companyStockShipment.CompanyStock_Id = int.Parse(newInfo);
                }
                else if (changedData.ToLower() == "shipmentid")
                {
                    companyStockShipment.Shipment_Id = int.Parse(newInfo);
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
