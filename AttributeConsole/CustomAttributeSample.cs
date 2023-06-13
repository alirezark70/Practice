using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeConsole
{
    //Attribute
    //آخر کلاس استفاده می کنیم وقتی استفاده می کنیم حذف می کنیم
    [AutoScan(author:"Alireza Rezaee",isBug:true,description:"Test")]
    public class CustomAttributeSample
    {

    }

    //با این میگیم که کجا باید استفاده بشه 
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class AutoScanAttribute:Attribute
    {
        private readonly string _Author;

        public string Description { get; set; }
        public DateTime ChangeDateTime { get; set; }
        public bool IsBug { get; }

        public AutoScanAttribute(string author, string description, bool isBug)
        {
            _Author = author;
            Description = description;
            IsBug = isBug;
        }
    }
}
