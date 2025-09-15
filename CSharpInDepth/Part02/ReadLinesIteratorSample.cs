//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CSharpInDepth.Part02
//{
//    //: این یک پیاده‌سازی تقریبی و ساده‌شده است، برای خوانایی بازنویسی شده است.
//    public class ReadLinesIteratorSample : IEnumerable<string>, IEnumerator<string>
//    {
//        public int state;            // نشانگر حالت
//        public string? current;      // مقدار فعلی برای Current
//        public string path;          // پارامتر کپی‌شده
//        private StreamReader? reader;// متغیر محلی که باید بین yield حفظ شود
//        private int initialThreadId; // برای بهینه‌سازی single-threaded

//        public ReadLinesIteratorSample(int state)
//        {
//            this.state = state;
//            this.initialThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
//        }

//        // Stub متدی که در سورس اصلی فراخوانی می‌شود
//        public static IEnumerable<string> ReadLines(string path)
//        {
//            var iter = new ReadLinesIteratorSample(-2);
//            iter.path = path;
//            return iter;
//        }

//        public IEnumerator<string> GetEnumerator()
//        {
//            // اگر هنوز GetEnumerator فراخوانی نشده و در همان ترد هستیم، this را بازمی‌گردانیم
//            if (state == -2 && initialThreadId == System.Threading.Thread.CurrentThread.ManagedThreadId)
//            {
//                state = 0; // آماده آغاز
//                return this;
//            }
//            else
//            {
//                var copy = new ReadLinesIteratorSample(-2);
//                copy.path = this.path;
//                return copy;
//            }
//        }

//        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

//        public string Current => current!; // فرض non-null برای سادگی
//        object? System.Collections.IEnumerator.Current => Current;

//        public bool MoveNext()
//        {
//            try
//            {
//                switch (state)
//                {
//                    case 0:
//                        // شروع متد: باز کردن reader

//                        {
//                            reader = new StreamReader(path);
//                            state = 1;
//                            goto case 1;
//                        }
                        

//                    case 1:
//                        // حلقه خواندن
//                        while (true)
//                        {
//                            string? line = reader.ReadLine();
//                            if (line == null)
//                            {
//                                // اتمام: برو به cleanup و پایان
//                                state = -1;
//                                // قبل از بازگشت false، بلاک finally اجرا خواهد شد توسط Dispose یا fault
//                                return false;
//                            }
//                            // آماده‌سازی برای بازگشت یک مقدار
//                            current = line;
//                            // قبل از برگشت true، حالت را ست می‌کنیم تا ادامه از اینجا باشد
//                            state = 2; // حالت بعد از yield
//                            return true;

//                    case 2:
//                                // وقتی دوباره MoveNext فراخوانی شد، ادامه از اینجا انجام می‌شود
//                                // بازگشت به حلقه for/while برای خواندن خط بعدی
//                                state = 1;
//                                continue;
//                            }
//                            default:
//                    return false;
//                        }
//                }
//        catch
//            {
//                // اگر استثنایی در MoveNext رخ دهد، cleanup انجام شود سپس استثنا مجددا پرتاب شود
//                Dispose(); // این اطمینان می‌دهد finallyها اجرا می‌شود
//                throw;
//            }
//        }

//        // Dispose مسئول اجرای cleanup (معادل finally در سورس)
//        public void Dispose()
//        {
//            // اگر reader هنوز باز است، ببند
//            if (reader != null)
//            {
//                try
//                {
//                    reader.Dispose();
//                    Console.WriteLine("In finally: closing reader (from Dispose)");
//                }
//                finally
//                {
//                    reader = null;
//                }
//            }
//            state = -1; // علامت‌گذاری به‌عنوان کامل‌شده
//        }

//        public void Reset() => throw new NotSupportedException();
//    }
//}
