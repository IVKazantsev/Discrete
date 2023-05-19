using System;

namespace First
{
    class Symbol
    {
        public char symbol;
        public int countOfRepeat;

        public Symbol(char Sym, int CountOfRepeat = 1)
        {
            symbol = Sym;
            countOfRepeat = CountOfRepeat;
        }
    }
}
