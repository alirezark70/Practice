using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EqualProperties.Models
{
    public class People
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public int Age { get; set; }
    }

    public class CompareEntities<T1,T2>
    {
        private readonly string[] firstentity;

        private readonly string[] lastentity;


        public CompareEntities()
        {
            
        }


        private void FindProperties<T1,T2>()
        {
            Type model1 = (Type)typeof(T1);

            var props = model1.GetProperties();


        }

        
    }

    public class POCOComparer<TPOCO> : IEqualityComparer<TPOCO> where TPOCO : class
    {
        public bool Equals(TPOCO poco1, TPOCO poco2)
        {
            if (poco1 != null && poco2 != null)
            {
                bool areSame = true;
                foreach (var property in typeof(TPOCO).GetPublicProperties())
                {
                    object v1 = property.GetValue(poco1, null);
                    object v2 = property.GetValue(poco2, null);
                    if (!object.Equals(v1, v2))

                    {
                        areSame = false;
                        break;
                    }
                };
                return areSame;
            }
            return poco1 == poco2;
        }   // eo Equals

        public int GetHashCode(TPOCO poco)
        {
            int hash = 0;
            foreach (var property in typeof(TPOCO).GetPublicProperties())
            {
                object val = property.GetValue(poco, null);
                hash += (val == null ? 0 : val.GetHashCode());
            };
            return hash;
        }   // eo GetHashCode
    }   // eo 

    public static partial class TypeExtensionMethods
    {
        public static PropertyInfo[] GetPublicProperties(this Type self)
        {
            
            return self.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where((property) => property.GetIndexParameters().Length == 0 && property.CanRead && property.CanWrite).ToArray();
        }   // eo GetPublicProperties


    }
}
