using NLayerProject.API.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.DTOs.Category
{
    public class CategoryWithProductDto:CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
