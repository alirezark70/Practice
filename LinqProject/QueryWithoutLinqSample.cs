using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    public class QueryWithoutLinqSample
    {
        List<string> list = new List<string>
            {
                "Alireza","Saeed","Masoud","Morteza","Hosssin","Javad","Mehdi","Ali","Mohammad","Hassan","Hossing"
            };
        public void PrintPersonal(string contain,string startWith,string endWith,bool sort)
        {
            List<string> result = new List<string>(list.Count);

            foreach(var item in list)
            {
                if(!string.IsNullOrEmpty(contain))
                {
                    if(item==contain)
                    result.Add(item);
                }    
            }

            if(!string.IsNullOrEmpty(startWith)&& string.IsNullOrEmpty(endWith))
            {
                if (!string.IsNullOrEmpty(startWith))
                {
                    foreach (var item in list)
                    {
                        if (item.StartsWith(startWith))
                            result.Add(item);
                    }
                }
            }
            if (string.IsNullOrEmpty(startWith) && !string.IsNullOrEmpty(endWith))
            {
                if (!string.IsNullOrEmpty(endWith))
                {
                    foreach (var item in list)
                    {
                        if (item.EndsWith(endWith))
                            result.Add(item);
                    }
                }

            }
            if(!string.IsNullOrEmpty(startWith) && !string.IsNullOrEmpty(endWith))
            {
                foreach(var item in list)
                {
                    if(item.StartsWith(startWith)&& item.EndsWith(endWith))
                    {
                        result.Add(item);
                    }
                }
            }

            if (sort)
                result.Sort();

            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
