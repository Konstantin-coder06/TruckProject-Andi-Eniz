using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TruckData;
using System.Threading.Tasks;

namespace TruckControllers.Controllers
{
    public class ShipmentController
    {
        ShipmentDbContext context = new ShipmentDbContext();

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

        public void RemoveShipment(int shipmentId)
        {
            var shipment = context.Shipments.FirstOrDefault(x => x.Id == shipmentId);
            if (shipment != null)
            {
                context.Shipments.Remove(shipment);
                context.SaveChanges();
            }
        }

        public void ChangeDataOfShipment(int id, string changedData, string newInfo)
        {
            var shipment = context.Shipments.FirstOrDefault(x => x.Id == id);

            if (shipment != null)
            {
                if (changedData.ToLower() == "typeofstock")
                {
                    shipment.TypeOfStock = newInfo;
                }
                else if (changedData.ToLower() == "stock")
                {
                    shipment.Stock = newInfo;
                }
                else if (changedData.ToLower() == "weight")
                {
                    shipment.Weight = double.Parse(newInfo);
                }
                else if (changedData.ToLower() == "fromadress")
                {
                    shipment.FromAdress = newInfo;
                }
                else if (changedData.ToLower() == "toadress")
                {
                    shipment.ToAdress = newInfo;
                }
                else if (changedData.ToLower() == "pickupdate")
                {
                    shipment.PickupDate = newInfo;
                }
                else if (changedData.ToLower() == "deliverydate")
                {
                    shipment.DeliveryDate = newInfo;
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