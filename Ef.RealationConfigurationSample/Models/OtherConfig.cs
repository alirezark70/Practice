using Ef.RealationConfigurationSample.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.RealationConfigurationSample.Models
{
   public class Parent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ParentCode { get; set; }



        public List<Child> Children { get; set; }
    }

    public class Child
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ParentCode { get; set; }

        public int ParentId { get; set; }

        public Parent Parent { get; set; }
    }

    public class OtherConfig : IEntityTypeConfig<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            //رفتار برای حذف والد در صورتی که فرزند داشته باشد
            builder.HasOne(e=>e.Children).WithMany().OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            //با تنظیم فوق به دیتابیس میگیم به جز کلید اصلی ما یک پرینسیپال کی هم داریم که همون
            //PersonCode 
            // هستش و تنظیمات به صورت زیر انجام میشود

            builder.HasAlternateKey(e => e.ParentCode);

            builder.HasMany(c => c.Children).WithOne().HasPrincipalKey(p => p.ParentCode);
        }

        
    }
}
