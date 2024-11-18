﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckData.Data.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string LiscenceNumber { get; set; }
        [Required]
        public int TruckCompanyId {  get; set; }
        public TruckCompany TruckCompany { get; set; }
    }
}
