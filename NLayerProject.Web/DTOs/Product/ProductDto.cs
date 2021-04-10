using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} is Required !!!")]
        public string Name { get; set; }

        [Range(1,int.MaxValue,ErrorMessage ="{0} must be great than 1")]
        public int Stock { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "{0} must be great than 1")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

    }
}
