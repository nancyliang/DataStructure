public class ThreadedTree<T>
{
    public ThreadedTree(T val, ThreadedTree<T> lChild, ThreadedTree<T> rChild)
    {
        Data=val;
        LChild=lChild;
        RChild=rChild;
    }

    public T Data{get;set;}
    public ThreadedTree<T> LChild{get;set;}
    public ThreadedTree<T> RChild{get;set;}
     public int LTag{get;set;}
    public int RTag{get;set;}
}