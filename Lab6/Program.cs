using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {

            // Чтение Файла //////////////////////////////////////////
            StreamReader file = new StreamReader("Edges.txt");
            List<string> linesOfFile = new List<string>();
            List<Edge> Edges = new List<Edge>();
            while (file.Peek() > -1)
                linesOfFile.Add(file.ReadLine());
            file.Close();
            // Создание списка рёбер /////////////////////////////////
            int countOfVertexes = 0;
            foreach (var line in linesOfFile)
            {
                Edge edge = new Edge(line[0] - 48, line[2] - 48, (line[4] - 48) * 10 + line[5] - 48);
                if (line[0] - 48 > countOfVertexes) countOfVertexes = line[0] - 48 + 1;
                if (line[2] - 48 > countOfVertexes) countOfVertexes = line[2] - 48 + 1;
                Edges.Add(edge);
            }
            linesOfFile.Clear();

            // Матрица инцидентности /////////////////////////////
            int[,] Incidence = new int[countOfVertexes,Edges.Count];
            StreamWriter incidenceFile = new StreamWriter("Incidence.txt");
        
            Console.WriteLine("Матрица инцидентности:");
            for (int i = 0; i < countOfVertexes; i++)
            {
                for (int j = 0; j < Edges.Count; j++)
                    if (Edges[j].GetVertexes().Contains(i))
                    {
                        Incidence[i, j] = Edges[j].GetWeight();
                        Console.Write(Edges[j].GetWeight() + "\t");
                        incidenceFile.Write(Edges[j].GetWeight() + "\t");
                    }
                    else
                    {
                        Incidence[i, j] = 0;
                        incidenceFile.Write(0 + "\t");
                        Console.Write(0 + "\t");
                    }
                incidenceFile.WriteLine();
                Console.WriteLine();
            }
            
            incidenceFile.Close();
            Console.WriteLine();
            // Матрица смежности    /////////////////////
            int[,] Adjacency = new int[countOfVertexes, countOfVertexes];
            
            Console.WriteLine("Матрица cмежности:");
            for (int i = 0; i < countOfVertexes - 1; i++)
                for (int j = 0; j < Edges.Count; j++)
                    if(Incidence[i,j] != 0)
                        for (int k = i + 1; k < countOfVertexes; k++)
                            if(Incidence[k, j] != 0)
                            {
                                Adjacency[i, k] = Incidence[i, j];
                                Adjacency[k, i] = Incidence[k, j];
                            }
            StreamWriter adjacencyFile = new StreamWriter("Adjacency.txt");

            for (int i = 0; i < countOfVertexes; i++)
            {
                for (int j = 0; j < countOfVertexes; j++)
                {
                    Console.Write(Adjacency[i,j] + "\t");
                    adjacencyFile.Write(Adjacency[i, j] + "\t");
                }
                Console.WriteLine();
                adjacencyFile.WriteLine();
            }
            adjacencyFile.Close();
            Console.WriteLine();
            
            /// Кратчайшие пути /////////////////////////////////////////
            
            var findSpt = new ShortestPathFinder(Adjacency, countOfVertexes);
            
            Console.WriteLine("Кратчайшие пути:");
            for (int i = 0; i < countOfVertexes; i++)
                Console.WriteLine(String.Join(" ", findSpt.Dijkstra(Adjacency, i)));
        }
    }
}

