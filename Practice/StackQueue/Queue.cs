
using System;

public class SeqQueue<T>
{
    public int MaxSize { get; set; }
    public int Front { get; set; }
    public int Rear { get; set; }

    private T[] data;
    public T this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }


    public SeqQueue(int size)
    {
        data = new T[size];
        MaxSize = size;
        Front = Rear = -1;
    }

    public int getSize()
    {
        return (Rear - Front + MaxSize) % MaxSize;
    }

    public bool IsFull()
    {
        if ((Rear + 1) % MaxSize == Front) return true;
        return false;
    }

    public bool IsEmpty()
    {
        if (Rear == Front) return true;
        return false;
    }

    public bool In(T item)
    {
        if (IsFull()) return false;
        data[++Rear] = item;
        return true;
    }

    public T Out()
    {
        if (IsEmpty()) return default(T);
        T temp = data[++Front];
        return temp;
    }

    internal T Peek()
    {
        if (IsEmpty()) return default(T);
        return data[Rear];
    }
}

public class LinkQueue<T>
{
    private SingleListNode<T> _head;
    private SingleListNode<T> _tail;
    private int _count = 0;
    public LinkQueue() { }
    public void Enqueue(T data)
    {
        SingleListNode<T> _newNode = new SingleListNode<T>(data,null);
        if (_head == null)
        {
            _head = _newNode;
            _tail = _head;
        }
        else
        {
            _tail.Next = _newNode;
            _tail = _tail.Next;
        }
        _count++;
    }
    public  T Dequeue()
    {
        if (_head == null)
        {
            throw new Exception("Queue is Empty");
        }
        T _result = _head.data;
        _head = _head.Next;
        return _result;
    }
    public int Count
    {
        get
        {
            return this._count;
        }
    }
}

