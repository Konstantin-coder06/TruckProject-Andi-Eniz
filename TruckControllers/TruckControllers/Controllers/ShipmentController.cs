using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckData.Data.Entities;
using TruckData.Data;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TruckControllers.Controllers
{
    public class ShipmentController
    {
        ShipmentDbContext context = new ShipmentDbContext();

        public void AddShipment(string typeOfStock, string stock, double weight, string fromAddress, string toAddress, DateTime pickupDate, DateTime deliveryDate)
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

        public string SeeAllShipments()
        {
            string output = "";
            var shipments = context.Shipments.ToList();
            foreach (var shipment in shipments)
            {
                output += $"Type: {shipment.TypeOfStock},\nName:{shipment.Stock}\nWeight: {shipment.Weight}\nFrom: {shipment.FromAdress}\nTo: {shipment.ToAdress}\nPick up date: {shipment.PickupDate}\nDelivery date: {shipment.DeliveryDate}\n\n";
            }
            return output;
        }
        public string SeeAllShipmentsByCompany(int companyId)
        {
            string output = "";
            List<Shipment> shipments = new List<Shipment>();
            var mapping = context.CompaniesStocks_Shipments.Where(x => x.CompanyStock_Id == companyId).ToList();

            foreach (var shipment in mapping)
            {
               
                shipments.AddRange(context.Shipments.Where(x => x.Id == shipment.Shipment_Id).ToList());
            }

            foreach (var shipment in shipments)
            {
                output += $"Type: {shipment.TypeOfStock},\nName: {shipment.Stock}\nWeight: {shipment.Weight}\nFrom: {shipment.FromAdress}\nTo: {shipment.ToAdress}\nPick up date: {shipment.PickupDate}\nDelivery date: {shipment.DeliveryDate}\n\n";
            }

            return output;
        }
        public string SeeAllShipmentsLines()
        {
            string output = "";
            var shipments = context.Shipments.ToList();
            foreach (var shipment in shipments)
            {
                output += $"--{shipment.Id}--\n Type: {shipment.TypeOfStock}\nName:{shipment.Stock}\nWeight: {shipment.Weight}\nFrom: {shipment.FromAdress}\nTo: {shipment.ToAdress}\nPick up date: {shipment.PickupDate}\nDelivery date: {shipment.DeliveryDate}\n\n";
            }
            return output;
        }
        public string SeeDateShipment(DateTime pickup)
        {
            string output = "";
            var shipments = context.Shipments.Where(x=>x.PickupDate<=pickup).ToList();
            foreach (var shipment in shipments)
            {
                output += $"Type: {shipment.TypeOfStock}\nName:{shipment.Stock}\nWeight: {shipment.Weight}\nFrom: {shipment.FromAdress}\nTo: {shipment.ToAdress}\nPick up date: {shipment.PickupDate}\nDelivery date: {shipment.DeliveryDate}\n\n";
            }
            return output;
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
       
       /* public List<string> UpdateInformation(int id, string typeOfStock, string stock, double weight, string fromAdress, string toAdress, DateTime pickupDate, DateTime deliveryDate)
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
        }*/
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
        public int GetId(string typeofstock,string stock,double weight,string from,string to, DateTime pick,DateTime del)      
        {
            var shipment = context.Shipments.FirstOrDefault(x=>x.TypeOfStock==typeofstock&&x.Stock==stock&&x.Weight==weight&&x.FromAdress==from&&x.ToAdress==to&&x.PickupDate==pick&&x.DeliveryDate==del);
            return shipment.Id;
        }
        public string GetStockName(string stock)
        {
            var shipment = context.Shipments.FirstOrDefault(x => x.Stock == stock);
            return shipment.Stock;
        }
        public string GetAllShipmentofTruckCompany(int id)
        {
            string output = "";
          var mapping=context.CompaniesStocks_Shipments.Where(x=>x.CompanyStock_Id == id);
            foreach(var map in mapping)
            {
                var shipment = context.Shipments.Where(x => x.Id == map.Shipment_Id);
                foreach(var ship in shipment)
                {
                    output+=$"Type: {ship.TypeOfStock}, Name: {ship.Stock},\n Weight: {ship.Weight}T, From: {ship.FromAdress}, To: {ship.ToAdress},Pick up date: {ship.PickupDate}, Delivery date: {ship.DeliveryDate}\n";
                }
            }
            return output;
        }
        public List<string> ComboBox()
        {
            return context.Shipments.Select(x=>x.FromAdress).ToList();
        }
        public string ShowFrom(string co)
        {
            var shipment=context.Shipments.Where(x=>x.FromAdress.Contains(co));
            string output = "";
            foreach(var ship in shipment)
            {
                output += $"Type: {ship.TypeOfStock}\nName: {ship.Stock}\nWeight: {ship.Weight}T,\n From: {ship.FromAdress}\n To: {ship.ToAdress}\nPick up date: {ship.PickupDate}\n Delivery date: {ship.DeliveryDate}\n\n";
            }
            return output;
        }
    }
}
