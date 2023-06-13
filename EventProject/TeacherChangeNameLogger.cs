using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject
{
    public class TeacherChangeNameLogger
    {
        public void Log(object sender,TeacherNameChangeArg arg)
        {
            Console.WriteLine($"Old Name Is {arg.OldName} And New Name Is {arg.NewName}");
        }
    }
}
