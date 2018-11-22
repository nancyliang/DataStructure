public class BineryTree<T>
{
    
    private T Visit(TreeNode<T> node)
    {
        return node.data;
    }
    public void PreOrder(TreeNode<T> root)
    {
        if(root != null) 
        Visit(root);
        PreOrder(root.LChild);
        PreOrder(root.RChild);
    }

    public void InOrder(TreeNode<T> root)
    {
        if(root != null) 
        InOrder(root.LChild);
        Visit(root);
        InOrder(root.RChild);
    }

    public void PostOrder(TreeNode<T> root)
    {
        if(root != null) 
        PostOrder(root.LChild);
        PostOrder(root.RChild);
        Visit(root);
    }

    public void TraversByLayers(TreeNode<T> root)
    {
        if (root == null) return;
        SeqQueue<TreeNode<T>> queue = new SeqQueue<TreeNode<T>>(100);
        queue.In(root);
        while (!queue.IsEmpty())
        {
            TreeNode<T> tNote = queue.Out();
            Visit(tNote);
            if(tNote.LChild !=null)queue.In(tNote.LChild);
            if(tNote.LChild !=null)queue.In(tNote.RChild);
        }
    }

    public int getTreeDepth(TreeNode<T> BT,int depth)
    {
        
        if (BT != null)
        {
            int lchildDepth = getTreeDepth(BT.LChild,depth) +1 ;
            int rchildDepth = getTreeDepth(BT.RChild,depth) +1 ;
            depth = lchildDepth>=rchildDepth?lchildDepth:rchildDepth;
        }
        return depth;
    }

    public void PreOrderNomal(TreeNode<T> root)
    {
        if (root == null) return;
        
        SeqStack<TreeNode<T>> stack = new SeqStack<TreeNode<T>>(100);
        stack.Push(root);
        while (!stack.IsEmpty())
        {
            TreeNode<T> tNote = stack.Pop();
            Visit(tNote);
            if(tNote.RChild != null) stack.Push(tNote.RChild);
            if(tNote.LChild !=null) stack.Push(tNote.LChild);
        }

    }

    public void InOrderNomal(TreeNode<T> root)
    {
        if (root == null) return;
        SeqStack<TreeNode<T>> stack = new SeqStack<TreeNode<T>>(100);
        TreeNode<T> tNote = root;
        while (!stack.IsEmpty() || tNote !=null)
        {
            if(tNote!=null)
            {
                stack.Push(tNote);
                tNote = tNote.LChild;
            }
            else
            {
                tNote = stack.Pop();
                Visit(tNote);
                tNote = tNote.RChild;
            }
        }

    }

    public void PostOrderNomal(TreeNode<T> root)
    {
        if (root == null) return;
        SeqStack<TreeNode<T>> stack = new SeqStack<TreeNode<T>>(100);
        SeqStack<int> flagStack= new SeqStack<int>(100);
        int flag = 0;
        TreeNode<T> tNote = root;
        while (!stack.IsEmpty() || tNote !=null)
        {
            if(tNote!=null)
            {
                stack.Push(tNote);
                flagStack.Push(1);
                tNote = tNote.LChild;
            }
            else
            {
                tNote = stack.Pop();
                flag=flagStack.Pop();
                if(flag==1)
                {
                        stack.Push(tNote);
                        flagStack.Push(1);
                        tNote= tNote.RChild;
                } 
                else
                {
                    Visit(tNote);
                }
               
            }
        }

    }


} 