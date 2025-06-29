using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCleanCode
{
    //share no , Copy Data For thread saftly
    public class CuncurrencySample
    { 
    //{
    //    public void CalculateNumber()
    //    {
    //        var input =IEnumerable<long>.(1,1000000).ToList();

    //        Stopwatch sw = Stopwatch.StartNew();

    //        sw.Start();
    //        var result= SingleThreadCalculate(input);

    //        Console.WriteLine(result);

    //        sw.Stop();

    //        Console.WriteLine(sw.ElapsedMilliseconds);
    //    }


    //    private long SingleThreadCalculate(List<long> slices)
    //    {
    //        var analyzer=new Analyzer();

    //        var results = analyzer.Analyze(slices);

    //        return results;
    //    }

    //    private long MultiThreadCaluate(List<long> input)
    //    {
    //        List<List<long>> slices = new List<List<long>>();

    //        long sliceSize = 500;
    //        for (long i = 0; i < input.Count; i += sliceSize)
    //            slices.Add(input.Skip(i).Take(sliceSize).ToList());

    //        var results = new List<long>();


    //        Parallel.ForEach(slices, (slice) =>
    //        {

    //            var analyzer = new Analyzer();
    //            long result = analyzer.Analyze(slice);  // هر Thread با داده خود کار می‌کند
    //            lock (results) { results.Add(result); } // فقط collect نتیجه به تنظیم synchronization نیاز دارد
    //        });

    //        return results.Sum();
    //    }
    //}


    //public class Analyzer
    //{
    //    public long Analyze(List<long> data)
    //    {
    //        long sum = 0;
    //        foreach (var num in data)
    //            sum += num;
    //        return sum; // هر Thread کپی sum خودش را دارد و فقط روی همان کار می‌کند
    //    }
    }
}
