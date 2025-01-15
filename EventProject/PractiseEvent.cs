using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject
{
    public delegate void SecondsEventHandler(object sender, SecondsArg e);

    public class SecondsArg:EventArgs
    {
        public DateTime LastEventRise { get; set; }

    }

    public class ProssessorTime
    {
        public event SecondsEventHandler SecondsChanged;
        private readonly TimeSpan _span;

        public void Execute()
        {

        }


        public void RaiseSecondsChanged(SecondsArg arg) 
        {
            if(SecondsChanged != null)
            {
                SecondsChanged(this, arg);
            }
        }

    }
}
