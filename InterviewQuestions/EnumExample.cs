using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{

    public static class EnumExampleClass<T> where T : struct
    {
        public static string[] GetString()
        {
            string[] result = Enum.GetNames(typeof(T));
            return result;
        }

        public static int[] GetNumber()
        {
            int[] result = (int[])Enum.GetValues(typeof(T));
            return result;
        }

        public static Dictionary<int,string> GetEnumDetails()
        {
            Dictionary<int,string> result = new Dictionary<int,string>();
           for(int i=0;i<GetNumber().Count(); i++)
            {
                result.Add(GetNumber()[i],GetString()[i]);

            }
            return result;
        }


      
    }

    public enum WeekDay
    {
        [Description("شنبه")]
        shanbe,

        [Description("یکشنبه")]
        yekshanbe,

        [Description("دوشنبه")]
        doshanbe,

        [Description("سه شنبه")]
        seshanbe,

        [Description("چهارشنبه")]
        chaharshanbe,

        [Description("پنج شنبه")]
        panjshanbe,

        [Description("جمعه")]
        jome
    }
}
