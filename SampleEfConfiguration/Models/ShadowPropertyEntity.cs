using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleEfConfiguration.Context;
using SampleEfConfiguration.FluentConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEfConfiguration.Models
{
    public class ShadowPropertyEntity
    {
        //بدین معنی است که یه سری پروپرتی که در اپلیکیشن ما نیست و فقط در دیتابیس و لایه دیتا اکسس ما هستنش
        //مثل
        //IsDeleted
        //DeletedBy
        public int Id { get; set; }

        public int Name { get; set; }

    }
    public class ShadowPropertyRepository
    {
        private readonly ExampleDbContext _exampleDbContext;

        public ShadowPropertyRepository()
        {
                _exampleDbContext = new ExampleDbContext();
        }

        public ShadowPropertyEntity QueryForShadowProperty()
        {
            //برای ایجاد کوئری شرطی بر روی شادو پروپرتی
            var result=_exampleDbContext.ShadowPropertyEntites.FirstOrDefault(c=>EF.Property<bool>(c,"IsDeleted")==false);

            return result;
        }

        public void ChangeValueShadowProperty()
        {
            //برای تغییر مقدار 
            ShadowPropertyEntity shadowProperty = QueryForShadowProperty();
            _exampleDbContext.Entry(shadowProperty).Property<bool>("IsDeleted").CurrentValue = true;

        }
    }

    public class ShadowPropertyConfig : IEntityTypeConfig<ShadowPropertyEntity>
    {
        public void Configure(EntityTypeBuilder<ShadowPropertyEntity> builder)
        {
            //این پروپرتی ها شادو پروپرتی هستند و فقط در دیتابیس ایجاد می شوند
            //شادو پروپرتی برو روی 
            //AsNoTracking
            //کار نیمی کنه چون باید برای دسترسی به آنها اطلاعات ترک شده باشند
            builder.Property<int>("DeletedBy");

            builder.Property<bool>("IsDeleted");
        }
    }
}
