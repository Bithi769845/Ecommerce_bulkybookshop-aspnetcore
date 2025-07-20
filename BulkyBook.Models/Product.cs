using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        public string Discription { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 1000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 1000)]
        public double price { get; set; }
        [Required]
        [Range(1, 1000)]
        public double price50 { get; set; }
        [Required]
        [Range(1,1000)]
        public double price100 { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int categoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int CoverTypeId { get; set; }
        public CoverType CoverType { get; set; }


    }
}
