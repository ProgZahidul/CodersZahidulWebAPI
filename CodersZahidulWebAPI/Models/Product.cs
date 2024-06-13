using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersZahidul.Models
{
    public enum ProductType
    {
        Mug,
        Jug,
        Cup,
        Bottle,
        Glass
    }
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public ProductType Type { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        public string? ImgPath { get; set; }


    }
}
