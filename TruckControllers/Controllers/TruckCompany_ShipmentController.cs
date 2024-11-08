using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckData;


namespace TruckControllers.Controllers
{
    public class TruckCompany_ShipmentController
    {
        ShipmentDbContext context = new ShipmentDbContext();

        public void AddTruckCompanyShipment(int truckCompanyId, int shipmentId)
        {
            context.TruckCompanies_Shipments.Add(new TruckCompany_Shipment
            {
                TruckCompany_Id = truckCompanyId,
                Shipment_Id = shipmentId
            });
            context.SaveChanges();
        }

        public List<TruckCompany_Shipment> SeeAllTruckCompanyShipments()
        {
            return context.TruckCompanies_Shipments.ToList();
        }

        public List<TruckCompany_Shipment> SeeTruckCompanyShipmentsBy(string criteria, string info)
        {
            List<TruckCompany_Shipment> shipments = new List<TruckCompany_Shipment>();

            if (criteria.ToLower() == "truckcompanyid")
            {
                shipments = context.TruckCompanies_Shipments.Where(x => x.TruckCompany_Id == int.Parse(info)).ToList();
            }
            else if (criteria.ToLower() == "shipmentid")
            {
                shipments = context.TruckCompanies_Shipments.Where(x => x.Shipment_Id == int.Parse(info)).ToList();
            }

            return shipments;
        }

        public void RemoveTruckCompanyShipment(int truckCompanyId, int shipmentId)
        {
            var truckCompanyShipment = context.TruckCompanies_Shipments
                .FirstOrDefault(x => x.TruckCompany_Id == truckCompanyId && x.Shipment_Id == shipmentId);
            if (truckCompanyShipment != null)
            {
                context.TruckCompanies_Shipments.Remove(truckCompanyShipment);
                context.SaveChanges();
            }
        }

        public void ChangeDataOfTruckCompanyShipment(int truckCompanyId, int shipmentId, string changedData, string newInfo)
        {
            var truckCompanyShipment = context.TruckCompanies_Shipments
                .FirstOrDefault(x => x.TruckCompany_Id == truckCompanyId && x.Shipment_Id == shipmentId);

            if (truckCompanyShipment != null)
            {
                if (changedData.ToLower() == "truckcompanyid")
                {
                    truckCompanyShipment.TruckCompany_Id = int.Parse(newInfo);
                }
                else if (changedData.ToLower() == "shipmentid")
                {
                    truckCompanyShipment.Shipment_Id = int.Parse(newInfo);
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
