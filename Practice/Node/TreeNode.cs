public class TreeNode<T>
{
    public TreeNode(T val, TreeNode<T> lchild, TreeNode<T> rchild)
    {
        data = val;
        lchild = LChild;
        rchild = RChild;
    }

    public T data{get; set;}
    public TreeNode<T> LChild{get;set;}
    public TreeNode<T> RChild{get; set;}
}