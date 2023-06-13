using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    public class PartitionSample
    {
        public void PageList(int pageIndex,int pageCount=10)
        {
            List<int> list = new List<int>();

            //با این روش پارتیشن بندی می کنیم
            var result=list.Skip(pageCount*pageIndex).Take(pageCount);

        }
    }
}
