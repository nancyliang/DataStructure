using System;
using System.Collections;
public class Vertex<T>
{
    public T Data{get;set;}
    public bool isVisited;

    public Vertex(T data)
    {
        Data = data;
    }
}

public class Graph
{
    public int maxNum;
    public Vertex<int>[] vertexs;
    public int[,] adjVertex;
    public int numVertex ;

    public Graph()
    {
        vertexs= new Vertex<int>[maxNum];
        adjVertex = new int[maxNum,maxNum];
        numVertex=0;
        for (int i =0; i<maxNum;i++)
        {
            for (int j =0; j<maxNum;j++)
            {
                adjVertex[i,j]=0;
            }
        }
    }

    public void AddVertex(int v)
    {
        vertexs[numVertex]=new Vertex<int>(v);
        numVertex ++;
    }

    public void AddEdge(int vertex1, int vertex2)
    {
        adjVertex[vertex1,vertex2]=1;
    }
    private Vertex<int> GetAdjUnvisitedVertex(Vertex<int> v){
	for (int j = 0; j < numVertex; j++){
        
		if (adjVertex[v.Data,j]==1 && vertexs[j].isVisited == false){
			return vertexs[j];
		}
	}
	    return null;
    }

    public void DisplayVertex(Vertex<int> v)
    {
        Console.WriteLine(v+" ");
    }

    public void DepthFirstTravers()
    {
        SeqStack<Vertex<int>> s= new SeqStack<Vertex<int>>(numVertex);
        vertexs[0].isVisited = true;
        s.Push(vertexs[0]);//访问第一个结点
        DisplayVertex(vertexs[0]);
        Vertex<int> adjv;

        while(!s.IsEmpty())
        {
            adjv=  GetAdjUnvisitedVertex(s.Peek()); //获取未访问过的相邻结点
            if(adjv is null)
            {
                s.Pop();
            }
            else
            {
                adjv.isVisited = true; //深度寻找下一个结点
                DisplayVertex(adjv);
                s.Push(adjv);
            }
        }

        for(int i=0;i<numVertex;i++)
        {vertexs[i].isVisited=false;}

    }

    public void BreadFirstTravers()
    {
        SeqQueue<Vertex<int>> q= new SeqQueue<Vertex<int>>(numVertex);
        vertexs[0].isVisited=true;
        q.In(vertexs[0]);//第一个结点进队列
        DisplayVertex(vertexs[0]);
       

        while(!q.IsEmpty())
        {
            Vertex<int> temp= q.Peek();//队尾
            while(GetAdjUnvisitedVertex(temp) !=null) //找出所有的相邻结点
            {
                Vertex<int>  adjv = GetAdjUnvisitedVertex(temp);
                adjv.isVisited=true;
                q.In(adjv);
                DisplayVertex(adjv);
            }

            q.Out();//找出次结点的所有相邻结点后从队列移除
            
        }

         for(int i=0;i<numVertex;i++)
        {vertexs[i].isVisited=false;}
    }
}
