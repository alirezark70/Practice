using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinLearn
{
    internal class ClassNumberOne
    {
    }


    public interface IFooService
    {
        void PrintName(string name)=>Console.WriteLine(name);
    }


    public class FooService : IFooService
    {

    }
    && (b.EndDateTime is null || b.BoardMemberStatus==Domain.Enums.BoardMembers.BoardMemberStatus.Active ||
                          b.BoardMemberStatus == Domain.Enums.BoardMembers.BoardMemberStatus.Filing))
    public static class FooExtension
    {
        public static void PrintName(this IFooService foo,string name)
        {
            name = "X";
            foo.PrintName(name);
        }
    }
}
