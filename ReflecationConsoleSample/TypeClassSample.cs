using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflecationConsoleSample
{
    public static class TypeClassSample
    {
        public static Type GetType(object input)
        {
            return input.GetType();
        }

        public static string GetNameSpace(object input)
        {
            var typeDetail=GetType(input);
            return typeDetail.Namespace??"";
        }
    }
}
