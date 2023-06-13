using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleEfConfiguration.FluentConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEfConfiguration.Models
{
    public class CompositKeyEntity
    {
        //وقتی ما 2 تا کلید اصلی داشته باشیم میگیم کامپاسیت کی داریم و به این صورت انجام میشه

        public int Pk1 { get; set; }

        public int Pk2 { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }

    public class CompositKeyConfig : IEntityTypeConfig<CompositKeyEntity>
    {
        public void Configure(EntityTypeBuilder<CompositKeyEntity> builder)
        {
            //بدین صورت 2 تا کلید اصلی یا پی کی داریم
            builder.HasKey(c=> new{c.Pk1,c.Pk2 });
        }
    }

}


