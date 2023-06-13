using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordProject
{

    /// <summary>
    /// Primary Cunstorctor Record
    /// </summary>
    /// ما الان یه کلاس عادی داریم و تنها فرقی که داره اینه که 
    /// Set تبدیل شده به init
    /// this class is immutable means is فقط خواندنی
    /// رکورد فقط برای زمانی که ما فقط با دیتا کاری داریم و با کلاس کار دیگه ای نداریم
    public record PersonPrimaryRecord(int Id, string FirstName,string LastName);
    public class PersonClass
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }


    }
    public record PersonRecord
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }


    }
}
