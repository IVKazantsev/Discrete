using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Calculation
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] mas = new BigInteger[102];
            mas[0] = 1;
            mas[1] = -7;
            Console.WriteLine($"Вычисление по формуле: {f(100)}");
            Console.WriteLine($"Вычисление с помощью программы: {g(100, mas)}");
        }

        static BigInteger f(int n)
        {
            return (BigInteger)((13 * Math.Pow(-1, n) - Math.Pow(6, n + 1)) / 7);
        }


        static BigInteger g(int n, BigInteger[] mas)
        {
            
            for (int i = 2; i < mas.Length; i++)
            {
                mas[i] = 5 * mas[i - 1] + 6 * mas[i - 2];
            }
            return mas[n];
        }
    }
}
