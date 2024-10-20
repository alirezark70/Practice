using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NutshelBooK
{
    public class NutshelPage550Until700
    {

    }

    public class FinalizerExample
    {

    }

    public class TempFileRef
    {
        static internal readonly ConcurrentQueue<TempFileRef> FailedDeletions = new ConcurrentQueue<TempFileRef>();
        public readonly string FilePath;
        public Exception DeletionError { get; private set; }

        public TempFileRef(string filePath)
        {
            FilePath = filePath;
        }

        ~TempFileRef()
        {
            try
            {
                File.Delete(FilePath);
            }
            catch (Exception ex)
            {
                DeletionError = ex;
                FailedDeletions.Enqueue(this);   // باززنده‌سازی
            }
        }
    }


    public class ThreadSafly
    {
        private bool _done;
        private readonly object _lock = new object();
        //این کد برای اینکه دوتا ترد نتونن همزمان به بخش قابل نوشتن دسترسی پیدا کنن
        //یعنی یه ترد خونه ولی هنوز نرسیده به متد برگشتیش و ترد بعدی هم واردش میشه
        public void Go()
        {
            lock (_lock)
            {
                if (_done) return;
            }

        }

    }

    public class ThreadPoolExample
    {
        public void TestExample()
        {
            var ee = ThreadPool.QueueUserWorkItem(DoWork);

        }


        static void DoWork(object state)
        {
            Console.WriteLine("Main Thrad Is Work");
        }
    }


    public class TaskAsynchoumesExample
    {
        //بعضی وقتا ما میخواهیم نتیجه قبلی تمام شود تا عملیات بعدی شروع شود
        //برای اینکار اینگونه عمل می کنیم

        //void DisplayPrimeCounts()
        //{
        //    DisplayPrimeCountsFrom(0);
        //}

        //void DisplayPrimeCountsFrom(int i)
        //{
        //    var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
        //    awaiter.OnCompleted(() =>
        //    {
        //        Console.WriteLine(awaiter.GetResult() + " primes between...");
        //        if (++i < 10) DisplayPrimeCountsFrom(i);
        //        else Console.WriteLine("Done");
        //    });
        //}
    }

    public class ValueTaskExample
    {
        //وقتی ما میخواهیم یک عملیات غیر همزمان انجام بدهیم 
        //و این عملیات سبک هست 
        //به جای ایجاد 
        //Task<T>
        //می توانیم از
        //ValueTask 
        //استفاده کنیم
        //که سربار کمتری دارد

        async ValueTask<int> GenNumber()
        {
            return await Task.FromResult(42);
        }
    }


    public class IOTaskExample
    {
        public async Task ReadFileAsync(string filePath, IProgress<string> progress, CancellationToken cancellationToken)
        {
            //برای عملیات 
            //io bound 
            //بسیار مناسب است از عملیات غیر همزمان استفاده کنیم
            //Iprogress یه 
            //دلیگیت است که روند پیشرفت تسک را گزارش می دهد
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                int totalBytesRead = 0;
                while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                {
                    totalBytesRead += bytesRead;
                    progress.Report("File Is" + (int)((double)totalBytesRead / fileStream.Length * 100));
                }
            }
        }
    }


    public class CombinatorsExample
    {
        //Combinators ترکیب کننده ها
        //این ها چند وظیفه یا تسک را با هم ترکیب می کنند 
        // و روند انجام تسک ها را مدیریت می کنند

        #region WhenAll
        async Task<int> Delay1() { await Task.Delay(1000); return 1; }
        async Task<int> Delay2() { await Task.Delay(2000); return 2; }
        async Task<int> Delay3() { await Task.Delay(3000); return 3; }

        public async Task WhenAll()
        {
            var results = await Task.WhenAll(Delay1(), Delay2(), Delay3());
            Console.WriteLine($"Results: {string.Join(", ", results)}");

            //وقتی بخواهیم مجموعه ای وظایف به صورت همزمان شروع شوند 
            //هر کدام از این فرایند میبایست تمام شوند
            //تسک ها به طور همزمان شروع می شوند و در انتهای به تسک اصلی برمیگرددند
            //جواب ریسالت برابر از با 3 تسکت و همه مقادیر

        }

        //مثال برای 
        //whenAll
        async Task<int> GetTotalSize(string[] uris)
        {
            //downloadTasks
            //وقتی اندازه همه دانلود ها تمام شد
            //whenAll
            //مقادیر را نمایش میدهد
            IEnumerable<Task<int>> downloadTasks = uris.Select(async uri =>
                (await new WebClient().DownloadDataTaskAsync(uri)).Length);

            int[] contentLengths = await Task.WhenAll(downloadTasks);
            return contentLengths.Sum();
        }

        #endregion


        #region WhenAny
        //این تسک اولین تسکی به پایان برسد را چاپ می کند
        async Task WhenAnyExample()
        {
            var firstCompletedTask = await Task.WhenAny(Delay1(), Delay2(), Delay3());
            int result = await firstCompletedTask;
            Console.WriteLine($"First Completed Result: {result}");
        }  


        #endregion
    }
}


