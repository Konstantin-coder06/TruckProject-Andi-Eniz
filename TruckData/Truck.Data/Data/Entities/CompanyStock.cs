using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckData.Data.Entities
{
    public class CompanyStock
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyEmail { get; set; }
        [Required]
        public string CompanyPassword { get; set; }
        [Required]
        public string CompanyNumber { get; set; }
        [Required]
        public string MainAdress { get; set; }
    }
}
