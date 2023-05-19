using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Edge
    {
        private int[] Vertexes = new int[2];
        private int weight;
        public int first;
        public int second;

        public Edge(int Vertex1, int Vertex2, int Weight)
        {
            Vertexes[0] = Vertex1;
            first = Vertex1;
            Vertexes[1] = Vertex2;
            second = Vertex2;
            weight = Weight;
        }
        public int[] GetVertexes()
        {
            return Vertexes;
        }
        public int GetWeight()
        {
            return weight;
        }
    }
}
