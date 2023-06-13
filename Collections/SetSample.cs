using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class SetSample<T>
    {
        //HashSet<> یک لیست کامنت یونیک و منحصر به فرد میگیره
        //در این لیست برای هر با ادد کردن نیازی به جستجو نداره
        private HashSet<T> _sample;
         
        public SetSample(HashSet<T> sample)
        {
            _sample = sample;
        }
        

        public void Add(T item)
        {
            _sample.Add(item);

            
        }

        public void Operators()
        {

            //این مجموعه برای کار بر روی مجموعه ها هم متد هایی دارد
            HashSet<T> set = new HashSet<T>();

            set.ExceptWith(_sample);


            set.Union(_sample);

            set.IsSubsetOf(_sample);

        }
        
    }

    public class SortedSet<T>
    {
        //SortetList یک لیست مرتب شده یونیک میگیره
        private SortedSet<T> _sample;
        public SortedSet(SortedSet<T> sample)
        {
            _sample = sample;
            
        }


    }
}
