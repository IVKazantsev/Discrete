using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 17;
            int n = 12;
            Console.WriteLine($"В прямоугольнике {m} на {n} клеток {CountOFPaths(m, n)} кратчайших путей из девого нижнего угла в правый верхний");
            Console.WriteLine($"Если два вертикальных участка не могут идти подряд, то {CountOfPathsWithoutVerticalRepeats(m, n)} путей");
        }

        static BigInteger Factorial(int n)
        {
            BigInteger factorial = new BigInteger(1);
            for (int i = 1; i <= n; i++)
                factorial *= i;
            return factorial;
        }

        static BigInteger CountOFPaths(int m, int n)
        {
            return Factorial(m + n)/(Factorial(m)*Factorial(n));
        }

        static BigInteger CountOfPathsWithoutVerticalRepeats(int m, int n)
        {
            return Factorial(m + 1) / (Factorial(n) * Factorial((m + 1) - n));
        }
    }
}
