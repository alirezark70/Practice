using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPattern
{
    internal class MediatorDesignPattern
    {
        //https://faradars.org/courses/mediator-pattern-in-software-development-using-c-sharp-fvsft95081s18?registered=1
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
        public abstract void Send(string message,Colleague colleague);
    }


    class ConcreteMediator:Mediator
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

    }

    class ConcreteColleague1:Colleague
    {

    }
    class ConcreteColleague2: Colleague
    {

    }
}
