using Ef.RealationConfigurationSample.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.RealationConfigurationSample.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Discount Discount { get; set; }


    }

    public class Discount
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductId { get; set; }

    }


    public class OneToOneConfig : IEntityTypeConfig<Product>
    {
        //ساخت رابطه یک به یک توسط فلونت ای پی ای
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(e => e.Discount).WithOne().HasForeignKey<Discount>(discount => discount.ProductId);
        }
    }

}
