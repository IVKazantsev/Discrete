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
            /*    string word = "КОМБИНАТОРИКА";
                int len = 6;
                Console.WriteLine($"Из {len} букв слова {word} можно составить {comb(word, len)} различных слов"); */

            string word = "КОМБИНАТОРИКА";
            List<string> list = new List<string>();

            string str = "";
            for (int i = 0; i < word.Length; i++)
            {
                str = "";
                str += word[i];
                for (int j = 0; j < word.Length; j++)
                {
                    if (i != j)
                    {
                        str += word[j];
                    }
                    else
                        continue;
                    for (int k = 0; k < word.Length; k++)
                    {
                        if ((i != j) && (i != k)
                            && (j != k))
                        {
                            str += word[k];
                        }
                        else
                            continue;
                        for (int l = 0; l < word.Length; l++)
                        {
                            if ((i != j) && (i != k) && (i != l)
                                && (j != k) && (j != l)
                                && (k != l))
                            {
                                str += word[l];
                            }
                            else
                                continue;
                            for (int d = 0; d < word.Length; d++)
                            {
                                if ((i != j) && (i != k) && (i != l) && (i != d)
                                    && (j != k) && (j != l) && (j != d)
                                    && (k != l) && (k != d)
                                    && (l != d))
                                {
                                    str += word[d];
                                }
                                else
                                    continue;
                                for (int m = 0; m < word.Length; m++)
                                {
                                    if ((i != j) && (i != k) && (i != l) && (i != d) && (i != m)
                                        && (j != k) && (j != l) && (j != d) && (j != m)
                                        && (k != l) && (k != d) && (k != m)
                                        && (l != d) && (l != m)
                                        && (d != m))
                                    {
                                        if (str.Length >= 6)
                                            str = str.Remove(5);
                                        str += word[m];
                                    }
                                    else
                                        continue;
                                    if (!list.Contains(str))
                                        list.Add(str);
                                }
                                str = str.Remove(4);
                            }
                            str = str.Remove(3);
                        }
                        str = str.Remove(2);
                    }
                    str = str.Remove(1);
                }
            }

            Console.WriteLine(list.Count);
        }

        /*static BigInteger Factorial(int n)
        {
            BigInteger factorial = new BigInteger(1);
            for (int i = 1; i <= n; i++)
                factorial *= i;
            return factorial;
        }

        static BigInteger comb(string word, int lenOfWords)
        {
            List<Symbol> Symbols = new List<Symbol>();
            BigInteger comb = new BigInteger(1);
            for (int i = 0; i < word.Length; i++)
            {
                if (i == 0)
                {
                    Symbol fisrtSymbol = new Symbol(word[i]);
                    Symbols.Add(fisrtSymbol);
                }
                else
                    foreach (var symbol in Symbols)
                    {
                        if (symbol.symbol == word[i])
                        {
                            symbol.countOfRepeat++;
                            break;
                        }
                        if (symbol == Symbols.Last<Symbol>())
                        {
                            Symbol symbol1 = new Symbol(word[i]);
                            Symbols.Add(symbol1);
                            break;
                        }
                    }
            }

            comb = Factorial(word.Length) / Factorial(word.Length - lenOfWords);

            foreach (var symbol in Symbols)
            {
                if (symbol.countOfRepeat > 1)
                    comb /= symbol.countOfRepeat;
            }

            return comb;
        }
        }
        */
    }
}
