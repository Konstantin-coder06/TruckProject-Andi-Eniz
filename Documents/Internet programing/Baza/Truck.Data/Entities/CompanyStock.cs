using System.ComponentModel.DataAnnotations;

namespace Truck.Data.Entities
{
    public class CompanyStock
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyPassword { get; set; }
        [Required]
        public string CompanyNumber { get; set; }
        [Required]
        public string MainAdress { get; set; }
    }
}