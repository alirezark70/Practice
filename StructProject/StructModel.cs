using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructProject
{
    public readonly struct StructModel
    {
        //قبل از سی شارپ 10 ما نمی تونستیم در سازنده یا استراکت سازنده پیش فرض داشته باشیم 
        //بعد از سی شارپ 10 ما می توانیم ولی با این تفاوت که باید تمام مقادیر سازنده را مقدار دهی کنیم
        // در سازنده ارث بری فعلا نداریم
        
        public StructModel()
        {
            Id = 0;
            Name = "Test";
            Family = "Test";
        }
        //قابلیت در سی شارپ 7 اضافه شده که مییشه ساختار فقط خواندنی باشد 
        //وقتی یک ساختار فقط خواندنی باشد اجرای داخلش هم باید به همین شکل باشد
        
        // private readonly int _id;
        //initial object 
        // در سی شارپ 10 مقدار دهی اولیه یا اینیشیال آبچکت اضافه شده است
        public int Id { get; init; } = 1;
        public string Name { get;  }
        public string Family { get; }
    }
 /// <summary>
 /// قابلیتی که در سی شارپ 10 اضافه شده که رکورد میشه ساختار باشه و 
 /// value type باشد
 /// </summary>
 /// <param name="id"></param>
 /// <param name="name"></param>
 /// <param name="family"></param>
    public record struct StructModelRecord(int id,string name,string family);
}
