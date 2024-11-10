using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckControllers.Controllers
{
    public class ShipmentController
    {
        /*ShipmentDbContext context = new ShipmentDbContext();

        public void AddShipment(string typeOfStock, string stock, double weight, string fromAddress, string toAddress, string pickupDate, string deliveryDate)
        {
            context.Shipments.Add(new Shipment
            {
                TypeOfStock = typeOfStock,
                Stock = stock,
                Weight = weight,
                FromAdress = fromAddress,
                ToAdress = toAddress,
                PickupDate = pickupDate,
                DeliveryDate = deliveryDate
            });
            context.SaveChanges();
        }

        public List<Shipment> SeeAllShipments()
        {
            return context.Shipments.ToList();
        }

        public List<Shipment> SeeShipmentsBy(string criteria, string info)
        {
            List<Shipment> shipments = new List<Shipment>();

            if (criteria.ToLower() == "type")
            {
                shipments = context.Shipments.Where(x => x.TypeOfStock == info).ToList();
            }
            else if (criteria.ToLower() == "fromaddress")
            {
                shipments = context.Shipments.Where(x => x.FromAdress == info).ToList();
            }
            else if (criteria.ToLower() == "toaddress")
            {
                shipments = context.Shipments.Where(x => x.ToAdress == info).ToList();
            }

            return shipments;
        }
        public List<string> GetAllInformation(int id)
        {
            var list = new List<string>();
            Shipment shipment = context.Shipments.FirstOrDefault(x => x.Id == id);
            list.Add(shipment.TypeOfStock);
            list.Add(shipment.Stock);
            list.Add(shipment.Weight.ToString());
            list.Add(shipment.FromAdress);
            list.Add(shipment.ToAdress);
            list.Add(shipment.PickupDate);
            list.Add(shipment.DeliveryDate);
            return list;
        }
        public List<string> UpdateInformation(int id, string typeOfStock, string stock, double weight, string fromAdress, string toAdress, string pickupDate, string deliveryDate)
        {
            var updates = new List<string>();
            Shipment shipment = context.Shipments.FirstOrDefault(x => x.Id == id);
            shipment.TypeOfStock = typeOfStock;
            shipment.Stock = stock;
            shipment.Weight = weight;
            shipment.FromAdress = fromAdress;
            shipment.ToAdress = toAdress;
            shipment.PickupDate = pickupDate;
            shipment.DeliveryDate = deliveryDate;
            context.SaveChanges();
            updates.Add(shipment.Stock);
            updates.Add(shipment.Weight.ToString());
            updates.Add(shipment.FromAdress);
            updates.Add(shipment.ToAdress);
            updates.Add(shipment.PickupDate);
            updates.Add(shipment.DeliveryDate);
            return updates;
        }
        public List<string> GetAllShipmentInfo()
        {
            return context.Shipments.Select(shipment => $"{shipment.Id}, {shipment.TypeOfStock} {shipment.Stock}, {shipment.Weight}, {shipment.FromAdress},{shipment.ToAdress},{shipment.PickupDate},{shipment.DeliveryDate}").ToList();
        }
        public void DeleteShipmentById(int shipmentId)
        {
            var shipment = context.Shipments.FirstOrDefault(x => x.Id == shipmentId);
            if (shipment != null)
            {
                context.Shipments.Remove(shipment);
                context.SaveChanges();
            }
        }
        public int GetId(int id)
        {
            var shipment = context.Shipments.FirstOrDefault(x => x.Id == id);
            return shipment.Id;
        }
        public string GetStockName(string stock)
        {
            var shipment = context.Shipments.FirstOrDefault(x => x.Stock == stock);
            return shipment.Stock;
        }*/
    }
}
