using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCs
{
    public  class SingletonClasses
    {
        private SingletonClasses() { }
        //private static SingletonClasses instance = null;
        //public static SingletonClasses Instance
        //{
        //    //get
        //    //{
        //    //    //if (instance == null)
        //    //    //{
        //    //    //    instance = new SingletonClasses();
        //    //    //}
        //    //    //return instance;
        //    //}
        //}

        public int Id { get; set; }
    }
    
}
