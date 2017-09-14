using System;
using System.Collections.Generic;

public sealed class ObjectPool<T> where T : new()
{
    private readonly Queue<T> _pool;
    private readonly Func<T> _createFunction;
    private readonly Action<T> _resetFunction;

    public ObjectPool(int capacity, Func<T> createFunction, Action<T> resetFunction)
    {
        _createFunction = createFunction;
        _resetFunction = resetFunction;
        _pool = new Queue<T>(capacity);
    }

    public ObjectPool(int capacity, Func<T> createFunction): this(capacity, createFunction, null)
    {
    }

    public ObjectPool(int capacity) : this(capacity, null, null)
    {
    }

    public int Count
    {
        get { return _pool.Count; }
    }

    public void Push(T item)
    {
        if (item == null)
        {
            Console.WriteLine("Push-ing null item. ERROR");
            throw new ArgumentNullException();
        }
        if (_resetFunction != null)
        {
            _resetFunction(item);
        }
        lock (_pool)
        {
            _pool.Enqueue(item);
        }
    }

    public T Pop()
    {
        T item;
        lock (_pool)
        {
            item = _pool.Count == 0 ? 
                (_createFunction != null ? _createFunction() : new T()) : 
                _pool.Dequeue();
        }
        return item;
    }
}