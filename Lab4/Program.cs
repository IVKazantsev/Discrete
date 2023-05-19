using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            int[] charArr = new int[52];                    // массив символов
            int[,] pairArr = new int[52, 52];               // массив для пар символов
            int count = 0;                                  // число символов в тексте
            char prev = ' ';                                // предыдущий символ
            char cur;                                       // текущий символ

            StreamReader file = new StreamReader("input.txt");
            while (file.Peek() > -1)                        // считываем входной файл
            {
                cur = (char)file.Read();
                text += cur;
                count++;
                if (cur >= 97 && cur <= 122)                // если текущий символ - строчная буква
                {
                    charArr[cur - 71]++;                    // увеличивем счётчик для букв
                    if (prev >= 97 && prev <= 122)          // если предыдущий символ - строчная буква
                        pairArr[prev - 71, cur - 71]++;     // увеличивем счётчик для пар букв
                    if (prev >= 65 && prev <= 90)           // если предыдущий символ - заглавная буква
                        pairArr[prev - 65, cur - 71]++;     //увеличивем счётчик для пар букв
                }
                if (cur >= 65 && cur <= 90)                 // если текущий символ - заглавная буква
                {
                    charArr[cur - 65]++;                    // увеличивем счётчик для букв
                    if (prev >= 97 && prev <= 122)          // если предыдущий символ - строчная буква
                        pairArr[prev - 71, cur - 65]++;     // увеличивем счётчик для пар букв
                    if (prev >= 65 && prev <= 90)           // если предыдущий символ - заглавная буква
                        pairArr[prev - 65, cur - 65]++;     // увеличивем счётчик для пар букв
                }
                prev = cur;
            }
            file.Close();

            double sumShennon = 0;
            for (int i = 0; i < 52; i++)
                if (charArr[i] != 0)
                {
                    double chance = (float)charArr[i] / count;
                    if(i < 26)
                        Console.WriteLine($"Количество букв {(char)(i + 65)} в тексте: {charArr[i]} - {chance}%"); 
                    else
                        Console.WriteLine($"Количество букв {(char)(i + 71)} в тексте: {charArr[i]} - {chance}%");
                    sumShennon -= chance * Math.Log(chance, 2);
                }
            
            for (int i = 0; i < 52; i++)
                for (int j = 0; j < 52; j++)
                    if (pairArr[i, j] != 0)
                    {
                        double chance = (float)pairArr[i, j] / count;
                        if(i < 26)
                            if(j < 26)
                                Console.WriteLine($"Количество пар {(char)(i + 65)}{(char)(j + 65)} в тексте: {pairArr[i,j]} - {chance}%");
                            else
                                Console.WriteLine($"Количество пар {(char)(i + 65)}{(char)(j + 71)} в тексте: {pairArr[i, j]} - {chance}%");
                        else
                            if(j < 26)
                                Console.WriteLine($"Количество пар {(char)(i + 71)}{(char)(j + 65)} в тексте: {pairArr[i, j]} - {chance}%");
                            else
                            Console.WriteLine($"Количество пар {(char)(i + 71)}{(char)(j + 71)} в тексте: {pairArr[i, j]} - {chance}%");
                    }

//            int HuffmanSize = buildHuffmanTree(text, count);
            int uniformCoding = count * 6;
//            Console.WriteLine($"Коэффициент сжатия Хаффман - равномерные коды:\t{(float)HuffmanSize / (uniformCoding)}");
            Console.WriteLine($"Формула Шеннона: {sumShennon}");
//            Console.WriteLine($"LZW: {LZW(text)} \nХаффман: {HuffmanSize} \nРавномерные коды: {uniformCoding}");
        }
    }
}
