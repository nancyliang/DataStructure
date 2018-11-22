public class SeqStack<T>
{
    public int MaxSize{get;set;}
    
    private int top;

    private T[] data;

    public T this[int index]
    {
        get {return data[index];}
        set {data[index] = value;}
    }
    
    public int Top
    {
        get{return top;}
    }

    public SeqStack(int size)
    {
        data = new T[size];
        MaxSize = size;
        top=-1;
    }

    public bool IsFull()
    {
        if (top==MaxSize-1) return true;
        return false;
    }

    public bool IsEmpty()
    {
        if(top==-1) return true;
        return false;
    }

    public bool Push(T item)
    {
        if(IsFull())return false;
        data[++top]=item;
        return true;
    }
    

    public T Pop()
    {
        if(IsEmpty()) return default(T);
        T temp = data[top];
        --top;
        return temp;
    }

    public T Peek()
    {
        if(IsEmpty()) return default(T);
        return data[top];
    }

    
}
