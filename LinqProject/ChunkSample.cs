using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    public static class ChunkSample
    {
        public static void ChunkMethod(int chunkSize=3)
        {
            //قبلا برای صفحه بندی دستی کد می زنیم ولی الان تابع جانگ داریم در دات نت 6

            List<int> chunks = new List<int>() { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
            var result=chunks.Chunk(chunkSize);
        }
    }

    public class GeneratorSample
    {
        //3 تا متد داره که شرح میدیم

        public void GeneratorMethod()
        {
            //عدد بین یک تا صد را میسازه
            var numberRange = Enumerable.Range(0, 100).ToList();

            //یک لیست خالی با اون چیزی که گفتیم میسازه
            var emptyNumber=Enumerable.Empty<int>();

            //یک لیستی را داخل لیست مون میسازه
            var repeat=Enumerable.Repeat(numberRange, 100);
        }
    }
}
