using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class QueueSample
    {
        Queue<string> _queue=new Queue<string>();

        public static void Start()
        {
            var queuSample = new QueueSample();
            queuSample.Enqueue("1");
            queuSample.Enqueue("2");
            queuSample.Enqueue("3");
            queuSample.Enqueue("3");
            queuSample.Enqueue("4");

            //Console.WriteLine(queuSample.Dequeue());

            //queuSample.QueueCapacity();
            Console.ReadLine();

        }


        public void Enqueue(string input)
        {
            _queue.Enqueue(input);
        }

        public string Dequeue()
        {
           return _queue.Dequeue();

        }

        public void QueueCapacity()
        {
            Console.WriteLine(_queue.Count);
        }

  


    }
}
