using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckData.Data.Entities
{
    public class TruckCompany
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TruckCompanyName { get; set; }
        [Required]
        public string TruckCompanyEmail { get; set; }
        [Required]
        public string TruckCompanyPassword { get; set; }
        [Required]
        public string MainTruckAdress { get; set; }
        [Required]
        public string TruckCompanyNumber { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Driver> Drivers { get; set; }

    }
}
