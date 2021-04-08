using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Configuration
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id); //primary key
            builder.Property(x => x.Id).UseIdentityColumn(); //++
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.ToTable("Categories");
        }
    }
}
