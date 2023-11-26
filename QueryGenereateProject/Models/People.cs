using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenereateProject.Models
{
    public class People2
    {
        public int Id { get; set; }
        public int aaa { get; set; }

        public DateTime CreateDate { get; set; }
    }

    public class People : BaseDataModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string NationalCode { get; set; }

    }

    public class QuerySqlModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalCode { get; set; }

        public string PositionName { get; set; }

        public DateTime StartDate { get; set; }

        public string DocumentDesctiption { get; set; }
    }


    public static class ConvertClass
    {
        public static void Convert<T>(T input)
        {
            if (input is not null)
            {
                Type Ttype = input.GetType();

                PropertyInfo[] arrayPropertyInfos = Ttype.GetProperties();

                foreach (PropertyInfo propertyInfo in arrayPropertyInfos.Where(e=>e.PropertyType == typeof(string)))
                {
                    string? v = propertyInfo.GetValue(input, null)?.ToString();

                    if (!string.IsNullOrEmpty(v))
                    {
                        propertyInfo.SetValue(input, v.ToUpper(), null);
                    }
                }

            }

        }

        public static string MakeYeKePersian(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            const char arabicKaf = (char)1603;
            const char arabicYa = (char)1610;

            const char persianKaf = (char)1705;
            const char persianYe = (char)1740;

            return value.Replace(arabicYa, persianYe)
                .Replace(arabicKaf, persianKaf);
        }
    }


    
}
