using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    public class QuerySyntaxAndMethodSyntax
    {
        List<string> list = new List<string>
            {
                "Alireza","Saeed","Masoud","Morteza","Hosssin","Javad","Mehdi","Ali","Mohammad","Hassan","Hossing"
            };
        #region Query Syntax
        public void QuerySyntax()
        {
            //در اینجا تایپ زیر را می دهد
            //IOrderdEnumrable
            var result=from a in list where a.StartsWith("A") orderby a descending select a;
        }
        #endregion


        #region Method Syntax
        public void MethodSyntax()
        {
            //return type IEnumrable
            //دست ما اینجا باز تره نسبت به کوئری سینتکس
            var result = list.Where(e => e.StartsWith("A")).OrderByDescending(e => e).Select(e=>e);


            //فیلتر بهمراه جستجوی بر روی ایندکس
            var resultIndex=list.Where((e,Index)=>e.StartsWith("A") && Index>4).ToList();
            //در کوئری بالا ایندکس جایگاه نشستن دیتا می باشد و گفتیم که اونایی که ایندکس شون بزرگتر از 4 است
        }



        #endregion



        private void FilterByType(List<object> input)
        {
            //دستور زیر مقادیر عددی را از داخل لیست آبجکت انتخاب می کند
            var result=input.OfType<int>().ToList();
        }
    }
}
