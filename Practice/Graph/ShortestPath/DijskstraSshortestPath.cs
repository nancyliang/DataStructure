//1
//G为有向图邻接矩阵，v为结点，dist[i]为当前找到的从原点v0到i的最短路径长度, path[i]表示在最短路径上该顶点的前一个顶点
//DijkstraShortestPath(G,v,dist[],path[]) 时间复杂度o(n*n*n)

//2.
//先把起点V0的下标0加到集合S，然后标记Isfor[0]=true;把起点的下标标记为把V1,V2,V3,V4,V5，V6的下标123456放到U中，
//遍历集合U，把0到各个顶点的距离添加到distance中（没有直接相连的边，就用2048这个大数表示）；

//3. 
//遍历distance，找到最小的距离，把顶点的下标添加到S中，然后设置该下标对应的Isfor的值为true，
//找到该下标为起点到各边的距离，
//如果这个新起点到其余在U集合的顶点的距离和上一个起点到新起点的距离之和<distance数据的距离，
//就把该位置的distance值设为（这个新起点到其余在U集合的顶点的距离和上一个起点到新起点的距离之和）；
//然后更改该顶点的对应pre的参考下标，为上一个起点的下标；然后重复3；


using System;
using System.Collections;
using System.Text;
namespace DijskstraSshortestPath
{
    class Program
    {
        //V1到V7的邻接矩阵
        static int[,] Metro = new int[7, 7] {
            { 0, 3, 7, 5,2048,2048,2048},
            { 3, 0, 2,2048, 6,2048,2048},
            { 7, 2, 0, 3, 3,2048,2048},
            { 5,2048, 3, 0,2048, 2, 8},
            {2048, 6, 3,2048, 0,2048, 2},
            {2048,2048,2048, 2,2048, 0, 2},
            {2048,2048,2048, 8, 2, 2, 0}};
        static int row = 7;
        ArrayList S = new ArrayList(row);//S储存确定最短路径的顶点的下标
        ArrayList U = new ArrayList(row);//U中存储尚未确定路径的顶点的下标
        int[] distance = new int[7];//用以每次查询存放数据
        int[] prev = new int[7];//用以存储前一个最近顶点的下标
        bool[] Isfor = new bool[7] { false, false, false, false, false, false, false };
        /// <summary>
        /// dijkstra算法的实现部分
        /// </summary>
        /// <param name="Start"></param>
        void FindWay(int Start)
        {
            S.Add(Start);
            Isfor[Start] = true;
            for (int i = 0; i < row; i++)
            {
                if (i != Start)
                    U.Add(i);
            }
            for (int i = 0; i < row; i++)
            {
                distance[i] = Metro[Start, i];
                prev[i] = 0;
            }
            int Count = U.Count;
            while (Count > 0)
            {
                int min_index = (int)U[0];//假设U中第一个数存储的是最小的数的下标
                foreach (int r in U)
                {
                    if (distance[r] < distance[min_index] && !Isfor[r])
                        min_index = r;
                }
                S.Add(min_index);//S加入这个最近的点
                Isfor[min_index] = true;
                U.Remove(min_index);//U中移除这个点；
                foreach (int r in U)
                {
                    //查找下一行邻接矩阵，如何距离和上一个起点的距离和与数组存储的相比比较小，就更改新的距离和起始点,再比对新的起点到各边的距离
                    if (distance[r] > distance[min_index] + Metro[min_index, r])
                    {
                        distance[r] = distance[min_index] + Metro[min_index, r];
                        prev[r] = min_index;
                    }
                    else
                    {
                        distance[r] = distance[r];
                    }
                }
                Count = U.Count;
            }
        }
        /// <summary>
        /// 把生成数据显示出来
        /// </summary>
        void display()
        {
            for (int i = 0; i < row; i++)
            {
                Console.Write("V1到V{0}的最短路径为→V1", i);
                int prePoint = prev[i];
                string s = "";
                StringBuilder sb = new StringBuilder(10);
                while (prePoint > 0)
                {
                    s = (prePoint + 1) + s;
                    prePoint = prev[prePoint];
                }
                for (int j = 0; j < s.Length; j++)
                {
                    sb.Append("-V").Append(s[j]);
                }
                Console.Write(sb.ToString());
                Console.Write("-V{0}", i);
                Console.WriteLine(":{0}", distance[i]);

            }
        }
    }
}
// static void Main(string[] args)
// {
// Program p = new Program();
// p.FindWay(0);
// p.display();
// Console.ReadKey();
// }
