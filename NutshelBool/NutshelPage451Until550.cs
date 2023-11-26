using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NutshelBooK
{
    public class NutshelPage451Until550
    {
        void ExecuteWhere()
        {
            List<int> ints = new List<int> { 1,2,3,4,5,6,7,8,9};

           

            ints.WhereAlireza(e=>e>10);
        }
    }
    

    #region Enumerable.Where implementation
    public static class WhereImplementationClass
    {
        public static IEnumerable<TSource> WhereAlireza<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item)) yield return item;
            }
        }
    }

    #endregion

    #region Contains with Ef.Like
    public class ContainsWithEfLikeClass
    {
        public List<string> Get10Names()
        {

            List<string> result=new List<string>();

            for(int i=0; i<10000;i++)
            {
               
                result.Add($"Alireza{i}");
            }
            return result;
        }

        public  string? FindAlirezaNumberUseContains(int number)
        {
            var alirezas=Get10Names();

            return alirezas.Where(e => e.Contains($"Alireza{number}")).FirstOrDefault();
        }

        public string? FindAlirezaNumberUseEfLike(int number)
        {
            var alirezas = Get10Names();

          
            string pattern= $"Alireza{number}";


            return alirezas.Where(e => EF.Functions.Like(e, "%"+pattern+"%")).FirstOrDefault();
        }
    }
    #endregion


    #region Indexed Filtering
    public static class IndexedFilteringClass
    {
        public static void Execute()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            //where 
            //می تونه دوتا المنت داشته باشه که در پایین مورد i 
            //ایندکس کالکشن می باشد و با این مقدار می توان بر روی ایندکس ها کار کرد
            IEnumerable<string> query = names.Where((n, i) => i % 2 == 0);

           
        }
    }
    #endregion


    #region Select Enumerable Implementation
    public static class SelectEnumerableImplemetationClass
    {
        public static IEnumerable<TResult> SelectAlireza<TSource,TResult>(this IEnumerable<TSource>sources,
            Func<TSource,TResult> selector)
        {
            foreach
                (var source in sources)
            {
                yield return selector(source);
            }

        }
        public static IEnumerable<TResult> SelectAlireza<TSource, TResult>(this IEnumerable<TSource> sources,
            Func<TSource, TResult> selector,int currentUserId)
        {
            if (currentUserId is 0)
                throw new Exception("Current User id is null!! Authentication is Faild");

            foreach
                (var source in sources)
            {
                yield return selector(source);
            }

        }

    }

    #endregion
}
