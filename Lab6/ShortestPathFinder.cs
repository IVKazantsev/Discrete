using System;

namespace Lab6
{
    public class ShortestPathFinder
    {
        public ShortestPathFinder(int[,] matrix, int matrixSize) //Конструктор (передаем все внешние даннные в класс ShortestPathFinder)
        {
            Matrix = matrix;
            MatrixSize = matrixSize;
        }

        private int[,] Matrix { get; }
        private int MatrixSize { get; }

        private int MinDistance(int[] dist, bool[] sptSet)
        {
            var min = int.MaxValue;
            var minIndex = -1;

            for (int i = 0; i < MatrixSize; i++)
            {
                if (sptSet[i] == false && dist[i] <= min)
                {
                    min = dist[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
        public int[] Dijkstra(int[,] matrix, int root)
        {
            var dist = new int[MatrixSize];

            var checkPoint = new bool[MatrixSize];

            for (int i = 0; i < MatrixSize; i++) //Заполняем масив кратчайших путей и посещенных точек
            {
                dist[i] = int.MaxValue;
                checkPoint[i] = false;
            }

            dist[root] = 0;

            for (int i = 0; i < MatrixSize - 1; i++)
            {

                var minDist = MinDistance(dist, checkPoint);

                checkPoint[minDist] = true;

                for (int j = 0; j < MatrixSize; j++)

                    if (!checkPoint[j] && matrix[minDist, j] != 0 && dist[minDist] != int.MaxValue && dist[minDist] + matrix[minDist, j] < dist[j])
                        dist[j] = dist[minDist] + matrix[minDist, j];
            }

            return dist;

        }

        
    }
}