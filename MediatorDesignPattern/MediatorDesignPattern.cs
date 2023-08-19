using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MediatorDesignPattern
{
    public class MediatorDesignPattern
    {
        //https://faradars.org/courses/mediator-pattern-in-software-development-using-c-sharp-fvsft95081s18?registered=1


        public void test()
        {
            Console.WriteLine();
        }
    }

    //کلاس های تشکیل دهنده مدیاتور
    //

    //اولین کلاس کلاس واسط یا میانجی 
    //Mediator

    //کلاس میانجی سفت یا
    //Concrete Mediator


    //یک اینترفیس واسط برای برقراری ارتباط با اشیا همکار

    //کاربرد الگوی مدیاتور
    //- مساله هایی که در آن اشیا باهم در تعامل هستند

    // در مساله های که کپسوله سازی در آن باید به دقت انجام شود


    /// <summary>
    /// کلاس واسط یا میانجی 
    /// </summary>
    public abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }


   public class ConcreteMediator : Mediator
    {
        private ConcreteColleague1 _colleague1;
        private ConcreteColleague2 _colleague2;

        public ConcreteColleague1 Colleague1 { set => _colleague1 = value; }
        public ConcreteColleague2 Colleague2 { set => _colleague2 = value; }

        public override void Send(string message, Colleague colleague)
        {
            throw new NotImplementedException();
        }
    }


    public abstract class Colleague
    {
        protected Mediator _mediator;

        public Colleague(Mediator mediator)
        {
            _mediator = mediator;
        }


    }

    public class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator)
        {

        }

        public void Send(string message)
        {
            _mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            WriteLine("Collague 1");
        }
    }
    public class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator) : base(mediator)
        {

        }
        public void Send(string message)
        {
            _mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            WriteLine("Collague 1");
        }
    }
}
