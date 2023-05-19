﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Vertex
    {
        public List<Vertex> ConnectedVertexes = new List<Vertex>();
        public List<int> Weight = new List<int>();
        private int number;

        public Vertex(int Number)
        {
            number = Number;
        }


        public int GetNumber()
        {
            return number;
        }
        public void AddVertex(Vertex vertex, int weight)
        {
            if (!ConnectedVertexes.Contains(vertex))
            {
                ConnectedVertexes.Add(vertex);
                Weight.Add(weight);
            }

        }
    }
}
