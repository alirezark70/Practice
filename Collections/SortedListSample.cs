using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collections
{
    public class SortedListSample
    {
        //لیست های از قبل مرتب شده است
        //این لیست ترکیب 
        // Key , Value 
        //میگیره

        //we can use lookup for it

        public static void TestTwo()
        {
            List<string> names = new List<string>();
            names.Add("Smith");
            names.Add("Stevenson");
            names.Add("Jones");

            ILookup<char, string> namesByInitial = names.ToLookup((n) => n[0]);

            // count the names
            Console.WriteLine("J's: {0}", namesByInitial['J'].Count()); // 1
            Console.WriteLine("S's: {0}", namesByInitial['S'].Count()); // 2
            Console.WriteLine("Z's: {0}", namesByInitial['Z'].Count());
        }

        public static void Test()
        {
            Type[] SampleTypes = new[] { typeof(List<>), typeof(string), typeof(Enumerable), typeof(XmlReader) };
            
            IEnumerable<Type> allTypes = SampleTypes.Select(x =>x.Assembly).Select(x =>x.GetType());

            ILookup<string, Type> lookup = allTypes.ToLookup(t => t.Namespace);

            foreach (Type type in lookup["System.Reflection"])
            {
                Console.WriteLine("{0}: {1}",
                                  type.FullName, type.Assembly.GetName().Name);
            }
        }
    }
}
