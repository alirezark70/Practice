using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleEfConfiguration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleEfConfiguration.FluentConfig
{
    //روش برای جداسازی تنظیمات فلونت استفاده میشه و یک اینترفیس ساختم که بتونم جداگانه تفکیک کنم
    public class PeopleConfig : IEntityTypeConfig<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Ignore(nameof(Person.FirstName));

            //value Comvertion
            //بعضی وقتا ما میخواهیم فرمتی که یک فیلد در اپلیکیشن ما داره تفاوت داشته باشه با مورد که در دیتابیس ذخیره میشه
            //نمونش اینام ها 
            builder.Property(e => e.PersonType).HasConversion<string>();

            //پارامتر اول سن به استرینگ تبدیل می کنه و در دیتابیس ذخیره می کنه
            //پارامتر دوم استرینگ را به اینت تبدیل می کنه
            builder.Property(e => e.Age).HasConversion(a=>a.ToString(),a=> int.Parse(a));

            //با ساخت کلاس و ارث بری از 
            //ValueConverter
            //میشه تبدیل را یک دفعه نوشت و برای همه مدل های مشابه استفاده کرد
            builder.Property(e => e.Age).HasConversion<IntToStringConverter>();
        }
    }


    public interface IEntityTypeConfig<Entity>:IEntityTypeConfiguration<Entity> where Entity : class 
    {
        
    }

    public class IntToStringConverter : ValueConverter<int, string>
    {
        public IntToStringConverter(Expression<Func<int, string>> convertToProviderExpression,
            Expression<Func<string, int>> convertFromProviderExpression, ConverterMappingHints? mappingHints = null) 
            : base(c=>c.ToString(),c=>int.Parse(c))
        {
        }
    }
}

