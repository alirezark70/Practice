using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
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


    #region Parallel Foreach 

    public class ParallelForeachClass
    {
        public void Execute()
        {
            // 2 million
            var limit = 2_000_000;
            var numbers = Enumerable.Range(0, limit).ToList();

            var watch = Stopwatch.StartNew();
            var primeNumbersFromForeach = GetPrimeList(numbers);
            watch.Stop();

            var watchForParallel = Stopwatch.StartNew();
            var primeNumbersFromParallelForeach = GetPrimeListWithParallel(numbers);
            watchForParallel.Stop();

            Console.WriteLine($"Classical foreach loop | Total prime numbers : {primeNumbersFromForeach.Count} | Time Taken : {watch.ElapsedMilliseconds} ms.");
            Console.WriteLine($"Parallel.ForEach loop  | Total prime numbers : {primeNumbersFromParallelForeach.Count} | Time Taken : {watchForParallel.ElapsedMilliseconds} ms.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
        private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();
        private static IList<int> GetPrimeListWithParallel(IList<int> numbers)
        {
            var primeNumbers = new ConcurrentBag<int>();

            Parallel.ForEach(numbers, number =>
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            });

            return primeNumbers.ToList();
        }
        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void InsertRange<T>(T inputs) where T : List<T> 
        {
            Parallel.ForEach<T>(inputs, input =>
            {
                //Add
            });

        }
            

    }

    #endregion


    #region SelectMany
    public class SelectManyClass
    {
        //برای فراخوانی فرزندان یک مدل کار بسیار مناسبی است 

        public void SelectManyExecute()
        {
            string[] nameList = { "Alieza Rezaee", "Sommaye Babaei" };
            

            var  fullName=nameList.SelectMany(name => name.Split(" "));
        }
    }
    #endregion


    #region Join

    public class PersonJoin
    {
        public PersonJoin(string firstName,string lastname)
        {
            this.Firstname=firstName;
            Lastname = lastname;
        }
        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }

    public class PetJoinClass
    {
        public string Name { get; set; }

        public PersonJoin Owner { get; set; }
    }

    public class JoinClass
    {
        PersonJoin magnus = new("Magnus", "Hedlund");
        PersonJoin terry = new ("Terry", "Adams");
        PersonJoin charlotte = new("Charlotte", "Weiss");
        PersonJoin arlene = new("Arlene", "Huff");
        PersonJoin rui = new("Rui", "Raposo");

        List<PersonJoin> people = new List<PersonJoin>();
        List<PetJoinClass> pets = new List<PetJoinClass>();
        public void IntoToModelJoin(List<PersonJoin> people, params PersonJoin[] personJoin)
        {
            people.AddRange(personJoin);
        }

        public void PreparePet()
        {
            pets.Add(new PetJoinClass() { Name="Barely",Owner= terry });
            pets.Add(new PetJoinClass() { Name= "Boots", Owner= terry });
            pets.Add(new PetJoinClass() { Name= "Whiskers", Owner= charlotte });
            pets.Add(new PetJoinClass() { Name = "Blue Moon", Owner = rui });
            pets.Add(new PetJoinClass() { Name="Barely",Owner= magnus });
        }



        public void Execute()
        {
            IntoToModelJoin(people, magnus, terry, charlotte, arlene, rui);

            PreparePet();


            var query = people.Join(pets, person => person, e => e.Owner, (person, pets) => new {OwnerName=person.Firstname,PetName=pets.Name });
        }

    }


    #endregion


    #region Concat Union UnionBy
    public class ConcatUnionUnionByClass
    {
        int[] seq1 = {1,2,3,4};
        int[] seq2 = {4,5,6,7};


        //concat
        //مقادیر 2 مجموعه را داخل یک مجموعه میریزد
        public void Concat()
        {
            var collection=seq1.Concat(seq2);
            //resutl : 1,2,3,4,4,5,6,7

        }

        public void Union()
        {
            var collection= seq1.Union(seq2);
            //result : 1,2,3,4,5,6,7
            //مقادیر تکراری را حدف می کند
        }
        
        public void UnionBy()
        {
            //بر اساس یک انتخابگر مقادیر را یونیون می کند

            string[] seq1 = { "A", "b", "C" };
            string[] seq2 = { "a", "B", "c" }; 
            var union = seq1.UnionBy(seq2, x => x.ToUpperInvariant());// union is { "A", "b", "C" }
        }


    }
    #endregion
}
