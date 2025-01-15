namespace Object_Pooling
{
    public class Class1
    {

    }

    public class PooledObject
    {
        public int Id { get; set; }

        public bool IsInUse { get; set; }

        public void Reset()
        {
            IsInUse = false;
        }
    }

    public class ObjectPool<T> where T : PooledObject, new()
    {
        private readonly Queue<T> _pool;
        private readonly int _capacity;

        public ObjectPool(int capacity)
        {
            _capacity=capacity;
            _pool = new Queue<T>();
        }

        public T Get()
        {
            if(_pool.Count > 0)
            {
                var obj= _pool.Dequeue();
                obj.IsInUse = true;
                return obj;
            }

            if (_pool.Count < _capacity)
            {
                var obj = new T { IsInUse = true };
                return obj;
            }

            throw new Exception("Pool is empty at maximom capacity");
        }

        public void Return(T obj)
        {
            obj.Reset();
            _pool.Enqueue(obj);
        }
    }
}
