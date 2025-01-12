using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSSharp
{
    public class IndexerSample
    {
        ImplementationIndexer indexer=new ImplementationIndexer();

        public void Proseccing()
        {
            indexer[109];
        }
    }

    public class ImplementationIndexer
    {
        public string this[int input]
        {
            get { return this[input]; }

            set { this[input] ="sample" +value; }
        }
    }
}
