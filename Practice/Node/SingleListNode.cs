public class SingleListNode<T>
{
    public T data{get;set;}
    public SingleListNode<T> Next{get;set;}
    public SingleListNode(T val, SingleListNode<T> p)
    {
        data=val;
        Next=p;
    }
}