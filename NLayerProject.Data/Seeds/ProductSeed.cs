using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Seeds
{
    class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Kalem", Price = 5.23m,Stock=100,CategoryId=_ids[0] }
                );
            builder.HasData(
                new Product { Id = 2, Name = "Kurşun Kalem", Price = 15.73m, Stock = 100, CategoryId = _ids[0] }
                );
            builder.HasData(
                new Product { Id = 3, Name = "Kitap", Price = 51.23m, Stock = 300, CategoryId = _ids[1] }
                );
            builder.HasData(
                new Product { Id = 4, Name = "Defter", Price = 15.23m, Stock = 100, CategoryId = _ids[1] }
                );
        }
    }
}
