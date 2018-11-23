
using System.Collections.Generic;
//若n较小（数据规模较小），插入排序或选择排序较好
//若数据初始状态基本有序（正序），插入、冒泡或快速排序为宜
//若n较大，则采用时间复杂度为O(nlogn)的排序方法：快速排序或堆排序
//快速排序是目前基于比较的排序中被认为是最好的方法，当待排序的关键字是随机分布时，快速排序的平均时间最短；
//堆排序所需的辅助空间少于快速排序，并且不会出现快速排序可能出现的最坏情况。这两种排序都是不稳定的。

public class Sort
{
    int[] SortList;
    int SortedNum;
    public Sort(int[] sortList)
    {
        SortList = sortList;
        SortedNum = sortList.Length;
    }

#region 直接插入排序
//思路是每一步将一个带排序的记录，插入到前面已经排序好的有序序列中去，直到插完所有元素为止。
//时间复杂度分析 平均O(n2)，最好O(n)，最坏O(n^2)
//空间复杂度分析 算法所需的辅助储存空间不随待排序规模的变化二变化，是个常量，因此空间复杂度为O(1)
//稳定
//适合基本已经排好序的
    public int[] StraightInsertSort()
    {

        for (int i = 1; i < SortedNum; i++)
        {

            if (SortList[i] < SortList[i - 1])
            {
                int temp = SortList[i];//将代插入关键字暂存在temp中
                int j = 0;
                //循环从待排关键字之前的关键字开始扫描，如果大于待排关键字，则后移一位
                for (j = i - 1; j >= 0 && temp < SortList[j]; j--)
                {
                    SortList[j + 1] = SortList[j];
                }

                SortList[j + 1] = temp;
            }
        }
        return SortList;
    }

 #endregion

#region 希尔排序
//希尔排序实质上是一种分组插入方法。
//它的基本思想是：
//1. 对于n个待排序的数列，取一个小于n的整数gap(gap被称为步长)将待排序元素分成若干个组子序列，所有距离为gap的倍数的记录放在同一个组中；
//2. 然后，对各组内的元素进行直接插入排序。 这一趟排序完成之后，每一个组的元素都是有序的。
//3. 然后减小gap的值，并重复执行上述的分组和排序。
//4. 重复这样的操作，当gap=1时，整个数列就是有序的。
//时间复杂度分析 平均O(n^1.5)，最好O(n)，最坏O(n^2)
//空间复杂度分析 O(1)
//不稳定稳定
    public int[] ShellSort()
    {

        int gap = SortedNum / 2;

        while (gap >= 1)
        {


            for (int i = gap; i < SortedNum; i++)
            {
                if (SortList[i] < SortList[i - gap])
                {
                    int temp = SortList[i];
                    int j;
                    for (j = i - gap; j >= 0 && temp < SortList[j]; j = j - gap)
                    {
                        SortList[j + gap] = SortList[j];
                    }

                    SortList[j + gap] = temp;
                }

            }

            gap = gap / 2;
        }
        return SortList;
    }
#endregion

#region 冒泡排序
//思想: 
//1. 它会遍历若干次要排序的数列，每次遍历时，它都会从前往后依次的比较相邻两个数的大小；如果前者比后者大，则交换它们的位置。
//2. 一次遍历之后，最大的元素就在数列的末尾！ 采用相同的方法再次遍历时，第二大的元素就被排列在最大元素之前。
//3. 重复此操作，直到整个数列都有序为止！

//时间复杂度分析 平均O(n^2)，最好O(n)，最坏O(n^2)
//空间复杂度分析 O(1)
//稳定
public int[] BubbleSort()
{

    int length = SortedNum;
    while(length>1)
    {
        for(int i = 0;i<length-1;i++)
        {
            if(SortList[i]>SortList[i+1])
            {
                int temp = SortList[i];
                SortList[i]=SortList[i+1];
                SortList[i+1]=temp;
            }
        }
        length--;
    }
    return SortList;
}
#endregion

#region 快速排序
//它的基本思想是：
//1. 选择一个基准数，通过一趟排序将要排序的数据分割成独立的两部分；其中一部分的所有数据都比另外一部分的所有数据都要小。
//2. 然后，再按此方法对这两部分数据分别进行快速排序，整个排序过程可以递归进行，以此达到整个数据变成有序序列。

//时间复杂度分析 平均O(nlog2n)，最好O(nlog2n)，最坏O(n^2)
//空间复杂度分析 O(nlog2n)
//不稳定
public int[] QuickSort(int[] sortList,int low, int high)
{
    if(low<high)
    {
    
        int temp = sortList[low];
        int i = low;
        int j = high;
        while(i<j )
        {
            while(i<j && sortList[j]>=temp)
            {
                j--;
            }
            sortList[i]=sortList[j];

            while(i<j && sortList[i]<=temp)
            {i++;}
            sortList[j]=sortList[i];
        }

        sortList[i]=temp;
        QuickSort(sortList,low,i-1);
        QuickSort(sortList,i+1,high);
    }
    return sortList;
}
#endregion

#region 直接选择排序
//思想：
//1. 从头到尾顺序扫描序列，找出一个最小的一个关键字和第一个关键字交换，
//2. 接着从剩下的关键字中继续这种选择和交换，最终使序列有序。

//时间复杂度分析 平均O(n^2)，最好O(n^2)，最坏O(n^2)
//空间复杂度分析 O(1)
//不稳定
public int[] StraightSelectionSort()
{
    for(int i=0;i<SortedNum-1;i++)
    {
        int k=i;
        for(int j=i;j<SortedNum-1;j++)
        {
            if(SortList[j]<SortList[k])
            {k=j;}
        }
        int temp = SortList[k];
        SortList[k]=SortList[i];
        SortList[i]=temp;


    }
    return SortList;
}

#endregion 

#region 堆排序
//思想:
//1. 初始化堆：将数列a[1…n]构造成最大堆。
//2.  交换数据：将a[1]和a[n]交换，使a[n]是a[1…n]中的最大值；然后将a[1…n-1]重新调整为最大堆。 
//3. 接着，将a[1]和a[n-1]交换，使a[n-1]是a[1…n-1]中的最大值；然后将a[1…n-2]重新调整为最大值。 
//4. 依次类推，直到整个数列都是有序的。

//时间复杂度分析 平均O(nlog2n)，最好O(nlog2n)，最坏O(n^2)
//空间复杂度分析 O(n)
//不稳定
public int[] HeapSort()
{
    
    return SortList;
}

public int[] GenerateHeap(int[] sortList,int start, int end)
{

return sortList;
}
#endregion

#region 二路归并排序
//从上往下归并思路:
//分解 – 将当前区间一分为二，即求分裂点 mid = (low + high)/2;
//求解 – 递归地对两个子区间a[low…mid] 和 a[mid+1…high]进行归并排序。递归的终结条件是子区间长度为1。
//合并 – 将已排序的两个子区间a[low…mid]和 a[mid+1…high]归并为一个有序的区间a[low…high]。

////时间复杂度分析 平均O(nlog2n)，最好O(nlog2n)，最坏O(n^2)
//空间复杂度分析 O(n)
//稳定

//n大时较好
public int[] MergeSort(int low , int high)
{
    if(low<high && (high-low)>=2)
    {
        int mid= (low+high)/2;
        MergeSort(low,mid);
        MergeSort(mid+1,high);
        Merge(low,mid,high);
    }
    return SortList;
}

public void Merge(int low, int mid, int high)
{
    int i = low;
    int j = mid + 1;
    List<int> tempList = new List<int>();

    while (i <= mid && j <= high)
    {
        if (SortList[i] < SortList[j])
        {
            tempList.Add(SortList[i]);
            i++;
        }
        else
        {
            tempList.Add(SortList[j]);
            j++;
        }
    }

    while (i <= mid)
    {
        tempList.Add(SortList[i]);
        i++;
    }
    while (j <= high)
    {
        tempList.Add(SortList[j]);
        j++;
    }

    for (int a = low; a <= high; a++)
    {
        SortList[a] = tempList[a];
    }

}
#endregion
}