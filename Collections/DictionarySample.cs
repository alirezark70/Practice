using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public abstract class DictionaryMain<TKey,TVlaue>
    {
        //یه دیکشنری به اصطلاح hash table  هم می گوییند


       private Dictionary<TKey, TVlaue> dictionaryValue;
        public DictionaryMain()
        {
            dictionaryValue=new Dictionary<TKey, TVlaue>();
        }

        public void AddToDictionary(TKey key, TVlaue value)
        {
            dictionaryValue.Add(key,value);
        }

        public void UpdateDictionary(TKey key, TVlaue value)
        {
            dictionaryValue[key]=value;
        }

        public void RemoveItemFromDictionary(TKey key)
        {
            dictionaryValue.Remove(key);
        }

        public void CoountDictionay()
        {
            Console.WriteLine(dictionaryValue.Count());
        }

        public bool IfIsThereInList(TKey key)
        {
            return dictionaryValue.ContainsKey(key);//چک می کنه کلید در لیست موجوود است یا خیر
        }
    }

    public class DictionarySample:DictionaryMain<int,string>
    {
        public void CreateSampleList()
        {
            Dictionary<int, string> dictionaryValue = new Dictionary<int, string>();
            dictionaryValue.Add(1, "Alireza");
            dictionaryValue.Add(2, "Sommaye");
            dictionaryValue.Add(3, "Saeed");
            dictionaryValue.Add(4, "Masoud");
            dictionaryValue.Add(5, "Majid");
            dictionaryValue.Add(6, "Abbas");
        }
    }

    public class SortedDictionarySample
    {
        SortedDictionary<int, string> sample = new SortedDictionary<int, string>();
        //دقیقا مثل دیکشنری است ولی مرتب شده
    }

    public class DictionaryEntitySample: DictionaryMain<int,PersonModel>
    {
        
    }

    public class PersonModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
