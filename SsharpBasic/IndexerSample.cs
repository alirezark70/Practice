using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsharpBasic
{
    public class IndexerSample
    {
        List<ImplementationIndexer> indexers =new List<ImplementationIndexer>();

        public List<ImplementationIndexer> Proseccing()
        {
            indexers.Add(new ImplementationIndexer
            {
                Firstname = "Alireza",
                Lastname="Rezaee",
                NationalCode=13374559,
                Indexer=70
            });
            indexers.Add(new ImplementationIndexer
            {
                Firstname = "Abbas",
                Lastname = "Rezaee",
                NationalCode = 1345432456,
                Indexer = 65
            });

            return indexers;
        }
    }

    public class ImplementationIndexer
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public long NationalCode { get; set; }

        public int Indexer { get; set; }
        public string this[int Indexer]
        {
            get { return this[Indexer]; }

            set { this[Indexer] =  value; }
        }
    }
}
