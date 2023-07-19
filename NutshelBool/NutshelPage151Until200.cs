using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutshelBooK
{
    internal class NutshelPage151Until200
    {
    }


    public class ClassTest<T>
    {
        void Main<U>() where U : T { }

    }

    public interface IClassA
    {
        void WriteLine();
    }

    public class ClassA : IClassA
    {
        public string Name { get; set; }

        public virtual void WriteLine()
        {
            Console.WriteLine(Name);
        }
    }
    public class ClassB : ClassA, IClassA
    {
        public override void WriteLine()
        {
            Console.WriteLine(Name);
        }
    }

    public class MainExample
    {
        public void WriteLine()
        {
            ClassA a = new ClassA();

            a.Name = "Hossein";

            SetName(a);
            a.WriteLine();

        }

        private void SetName(ClassA a)
        {
            a = new ClassA();
            a.Name = "Ali";
        }
    }
}

