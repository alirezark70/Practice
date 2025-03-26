using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace StructuralPatternSample
{
    internal class DecoratorDesignPatternLoginSample
    {
    }


    public interface ILogin
    {
        void Login();
    }

    public class Login : ILogin
    {
        void ILogin.Login()
        {
            Console.WriteLine("Login Success");
        }
    }

    public class LoginDecorator : ILogin
    {
        private readonly ILogin _login;

        public LoginDecorator(ILogin login)
        {
            _login = login;
        }

        public virtual void Login()
        {
            _login.Login();
        }
    }


    public class SmsLoginDecorator : LoginDecorator
    {
        public SmsLoginDecorator(ILogin login) : base(login)
        {
        }

        public override void Login()
        {

            base.Login();

            Console.WriteLine("Send Sms");
        }
    }
}
