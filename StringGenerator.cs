using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TandemString
{
    internal class StringGenerator
    {
        private readonly Int16 StringLength = 10;
        private readonly List<char> Alphabet = new List<char>();

        public StringGenerator()
        {
            AlphabetGenerate();
        }

        private void AlphabetGenerate()
        {
            char _begin = 'a';
            Alphabet.Add(_begin);
            for (int i = 1; i< 26; i++)
            {
                Alphabet.Add(_begin++);
            }
        }

        public List<char> GetAlphabet()
        {
            return Alphabet;
        }

        public List<string> GenerateStrings(Int32 NumberOfString, Int16 AmountOfAlphabetChar)
        {
            List<string> strings = new List<string>();
            Random rnd = new Random();
            

            while (strings.Count < NumberOfString) 
            {
                StringBuilder stringBuilder = new StringBuilder();
                do
                {
                    int _innerLength = rnd.Next(1, StringLength);
                    for (int i = 0; i < _innerLength; i++)
                    {
                        int index = rnd.Next(0, AmountOfAlphabetChar);
                        stringBuilder.Append(Alphabet[index]);
                    }
                    strings.Add(stringBuilder.ToString());
                }
                while(!strings.Contains(stringBuilder.ToString()));
                
            }
            return strings;
        }
    }
}
