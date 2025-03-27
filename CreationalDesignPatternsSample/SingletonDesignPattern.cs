using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalDesignPatternsSample
{
    internal class SingletonDesignPattern
    {
        public void ExecuteSingletion()
        {
            var singletion = Singletion.Instance;
        }
    }

    public class Singletion
    {
        //best implementation Singletion Design Pattern

        //use Lamda Expression
        private static readonly Lazy<Singletion> _instance = new Lazy<Singletion>(()=>new Singletion());


        //use method CreateInstance ! bothe same work
        //private static readonly Lazy<Singletion> _instance = new Lazy<Singletion>(CreateInstance());

        private Singletion() { }


        //private static Singletion CreateInstance()
        //{
        //    return new Singletion();
        //}

        public static Singletion Instance { get { return _instance.Value; } }
    }
}
