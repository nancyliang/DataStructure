//构造一个二叉树，使得带权外部路径长度最小，这个二叉树叫做哈夫曼树。
//内部结点，外部结点
//路径，内部路径，外部路径
//外部结点权值
using System.Collections.Generic;
using System.Data;
public class Node
{
 public int Weight{get;set;}
 public int LChild{get;set;}
 public int RChild{get;set;}
 public int Parent{get;set;}

 public  Node(int w, int lchild, int rchild, int parent)
 {
     Weight=w;
     LChild=lchild;
     RChild =rchild;
     Parent=parent;

 }
}

public class HuffmanTree
{
        private Node[] data;
        public int leafNum;

    

    public Node this[int index]
        {
            get{return data[index];}
            set{data[index]=value;}
        }
    public HuffmanTree(List<int> weightList)
    {
        data = new Node[2*weightList.Count -1];
        leafNum = weightList.Count;
        for(int i=0;i<leafNum;++i)
        {
            data[i].Weight=weightList[i];
        }
    }

    public void makeHuffmanTree()
    {
        for(int i =0; i<leafNum-1;i++)
        {
            int min1 = int.MaxValue;
            int min2= int.MaxValue;
            int temp1=0;
            int temp2 =0;
            
            for(int j =0;j<=leafNum+i;++j)
            {
                if((data[i].Weight<min1) && data[i].Parent==-1)
                {
                    min2=min1;
                    temp2=temp1;
                    temp1 =j;
                    min1=data[j].Weight;
                }
                else if((data[i].Weight<min2) && data[i].Parent==-1)
                {
                    min2 = data[j].Weight;
                    temp2 =j;
                }
            }

            data[temp1].Parent = data[temp2].Parent = leafNum +1;
            data[leafNum +i].Weight = data[temp1].Weight + data[temp2].Weight;
            data[leafNum+i].LChild = temp1;
            data[leafNum+i].RChild=temp2;
        }
    }
        
}