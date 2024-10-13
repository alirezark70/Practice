using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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
            lock (_lock) {
            if (_done) return;
            }

        }

    }

    public class ThreadPoolExample
    {
        public void TestExample()
        {
           var  ee= ThreadPool.QueueUserWorkItem(DoWork); 

        }


        static void DoWork(object state)
        {
            Console.WriteLine("Main Thrad Is Work");
        }
    }


    public class TaskAsynchoumesExample
    {
        //بعضی وقتا ما میخواهیم نتیجه قبلی 
    }
}
