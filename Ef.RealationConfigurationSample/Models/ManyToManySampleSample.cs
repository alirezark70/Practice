using Ef.RealationConfigurationSample.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.RealationConfigurationSample.Models
{
    public class ProductManyToMany
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductAndTagRelationShip> ProductsTags { get; set; }
    }

    public class TagManyToMany
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductAndTagRelationShip> ProductsTags { get; set; }
    }

    public class ProductAndTagRelationShip
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }
        public int? TagId { get; set; }


        public ProductManyToMany Product { get; set; }

        public TagManyToMany Tag { get; set; }
    }


}
