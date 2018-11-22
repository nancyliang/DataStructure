public class Search
{
    public int Target;
    public int[] SearchList;
    public Search(int target, int[] searchList)
    {
        Target=target;
        SearchList=searchList;
    }

    public int StraightSearch()
    {
        for(int i=0;i<SearchList.Length-1;i++)
        {
            if(Target==SearchList[i])
            {return i;}
        }
        return -1;
    }

    public int BinarySearch()
    {
        Sort s = new Sort(SearchList);
        int[] sortedList = s.StraightInsertSort();

        int low=0;
        int high = sortedList.Length-1;
       

        while(low<=high)
        {
             int mid =(low + high)/2;
            if(sortedList[mid]==Target)
            {
                return mid;
            }
            else if(sortedList[mid]>Target)
            {
                high=mid-1;
            }
            else low=mid+1;
        }
    

        return -1;
    }

    public int BSTSearch(TreeNode<int> root, int target)
    {
        if (root !=null)
        {
            if(root.data == target)
            {return root.data;}
            else if(target<root.data)
            {
                BSTSearch(root.LChild,target);
               
            }
            else
            {
                BSTSearch(root.LChild,target);
            }
        }
        return -1;
    }


}