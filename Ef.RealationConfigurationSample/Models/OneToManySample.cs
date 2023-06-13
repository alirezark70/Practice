using Ef.RealationConfigurationSample.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.RealationConfigurationSample.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProductId { get; set; }

        
        

    }

    public class ProductTwo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //اکه مرتب سازی برای ما مهم نباشد بهتره که از هش ست استفاده کنیم چون پرفرمنس بهتری دارد
        public HashSet<Comment> Comments { get; set; }

    }

    public class OneToManyConfig : IEntityTypeConfig<ProductTwo>
    {
        public void Configure(EntityTypeBuilder<ProductTwo> builder)
        {
            builder.HasMany(e => e.Comments).WithOne().HasForeignKey(e=>e.ProductId);
        }
    }

}
