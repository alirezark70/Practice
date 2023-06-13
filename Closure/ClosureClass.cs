using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closure
{
    public class ClosureClass
    {
        
        public void TestClosure(int input)
        {
            Func<int, int> AddTestClosure = x =>
            {
                x = input;
                return x;
            };
            //وقتی ما یک لامدا می نویسیم و اینستس بهش میدم
            //لامدا وقتی اجرا بشه یک کلاس انینیموس میسازه و مقدار سازنده یا کانستراکتو را بهش پاس میده
            //اگر ووردی تا استفاده متد تغییر کنه مقدار بعد تغییر در نظر گرفته می شود
            var result = AddTestClosure(input);
            Console.WriteLine(result);

        }
    }
}
