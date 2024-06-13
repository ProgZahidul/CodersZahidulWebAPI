using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersZahidul.Models.ViewModels
{
    public class ProductVM
    {
        


        public string Title { get; set; }

        public string Brand { get; set; }

        public ProductType Type { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }
        [ValidateNever]
        public IFormFile ImageFile { get; set; }
    }
}
