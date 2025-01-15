using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject
{
    public delegate void ThresholdReachedEventHandler(object sender, ThresholdReachedEventArgs e);

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

    public class Counter
    {
        private int _count;
        public int Threshold { get; set; }

        // 3) تعریف رویداد  
        public event ThresholdReachedEventHandler ThresholdReached;

        public void Add(int x)
        {
            _count += x;
            if (_count >= Threshold)
            {
                // 4) صدا زدن رویداد  
                OnThresholdReached(new ThresholdReachedEventArgs
                {
                    Threshold = Threshold,
                    TimeReached = DateTime.Now
                });
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            if (ThresholdReached != null)
            {
                ThresholdReached(this, e);
            }
        }
    }

    public class ProssessEvent
    {
        public void ProssessMethod()
        {
            Counter c = new Counter();
            c.Threshold = 10;

            // مشترک شدن به رویداد  
            c.ThresholdReached += C_ThresholdReached;

            Console.WriteLine("افزایش مقدار شمارنده...");
            for (int i = 0; i < 3; i++)
            {
                c.Add(4); // در مجموع از مقدار آستانه (10) عبور خواهد کرد  
            }

            Console.ReadLine();
        }

        private static void C_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"آستانه {e.Threshold} در زمان {e.TimeReached} رد شد!");
        }
    }
}
