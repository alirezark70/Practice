using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    public static class ZipSample
    {
        //دو لیست یکی درمیان هم کنار هم میزاره
        //طول زیپبه اندازه لیست کوتاه ما می باشد
       static List<int> list01 = new List<int> { 1, 3, 5, 7 };
       static List<int> list02 = new List<int> { 2, 4, 6, 8 };

        public static void ZipList()
        {
            var zipResult = list01.Zip(list02);

            foreach(var item in zipResult)
            {
                Console.WriteLine($"First :{item.First} -- Secend : {item.Second}");
            }
        }
    }
}
