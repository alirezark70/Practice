using Ef.RealationConfigurationSample.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef.RealationConfigurationSample.OwnedTypeSample
{
    public class PersonOwner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AddressOwner Address { get; set; }

        public List<Car> Cars { get; set; }

        public List<Money> Money { get; set; }

    }

    public class AddressOwner
    {
        public int Id { get; set; }
        public string Provance { get; set; }

        public string City { get; set; }

        public string Region { get; set; }
    }

    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class  Money
    {
        public int Id { get; set; }

        public int Value { get; set; }
    }

    public class OwnerTypeConfig : IEntityTypeConfig<PersonOwner>
    {
        //این ویژگی برای این است که ما یک آبجکت داشته باشیم ولی در دیتابیس در جدول های مختلف ذخیره میشه
        //برای واکشی هم با یک درخواست همه اطلاعات با فرزندانش لود می شود
        //یعنی در برنامه ما فقط یک انتیتی داریم
        //این ویژگی برای الگوی های مبتنی بر دامنه مناسب است
        public void Configure(EntityTypeBuilder<PersonOwner> builder)
        {
            builder.OwnsOne(e => e.Address).ToTable(nameof(AddressOwner)+"Tb");
            builder.OwnsMany(e => e.Cars).ToTable(nameof(Car) + "Tb");
            builder.OwnsMany(builder => builder.Money).ToTable(nameof(Money) + "Tb");
        }
    }
}
