using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Queue
    {
        //فرایند نوشتن در آخر صف را 
        //Enqueue  می گوییم

        //فرآیند خواندن و همزمان حذف کردن مقدار از اول صف را 
        //Dequeue می گوییم
        private readonly Queue<object> _queue;
        private readonly Type _typeClass;
        private readonly object _value;
        public Queue(object inputQueue)
        {
            _value = inputQueue;
            var queue = new Queue<object>();
            _queue = queue;
            _typeClass = inputQueue.GetType();
        }

        public void Enqueue()//Insert Into Queue
        {
            _queue.Enqueue(_value);
        }

        public string? Dequeue() // Read And Remve On Queue
        {
          return _queue.Dequeue()?.ToString();
        }

        public void CountQueue()// Count Queue
        {

        }


        public ObjectDetail TypeClassDetails()
        {
           // Print some properties of the Type formal parameter.
                //Console.WriteLine("IsArray: {0}", _typeClass.IsArray);
                //Console.WriteLine("Name: {0}", _typeClass.Name);
                //Console.WriteLine("IsSealed: {0}", _typeClass.IsSealed);
                //Console.WriteLine("BaseType.Name: {0}", _typeClass.BaseType?.Name);
                //Console.WriteLine();

            return new ObjectDetail
            {
                BaseTypeName = _typeClass.BaseType?.Name,
                IsArray = _typeClass.IsArray,
                IsSealed= _typeClass.IsSealed,
                Name= _typeClass.Name,
            };
        }

    }

    public class ObjectDetail
    {
        public bool IsArray { get; set; }
        public string Name { get; set; }

        public bool IsSealed { get; set; }

        public string? BaseTypeName { get; set; }
    }
}
