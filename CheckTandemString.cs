using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TandemString
{
    internal class CheckTandemString
    {
        private readonly ICollection<string> StringsList;
        private ICollection<string> ResultStringList = new List<string>();
        
        public CheckTandemString(ICollection<string> ListOfStrings)
        {
            this.StringsList = ListOfStrings;
            CheckStrings(StringsList, 0, StringsList.Count-1);
        }

        private void CheckStrings(ICollection<string> List, Int32 indexStart, Int32 indexEnd)
        {
            // В теле пузырьковой сортировки перебери все строки
            // Можно применить Quick Sort тело с биссекцией коллекции, даст + время
            for (int i = 0; i < this.StringsList.Count; i++)
            {
                for (int j = i + 1; j < this.StringsList.Count - 1; j++)
                {
                    // Пристроили спереди одну строку к другой и проверили
                    string _concatString = string.Concat(StringsList.ElementAt(i) + StringsList.ElementAt(j));
                    if (IsStringTandemStyle(_concatString) == true)
                    {
                        Console.WriteLine($"{StringsList.ElementAt(i)}:{StringsList.ElementAt(j)}");
                        ResultStringList.Add($"{i + 1}:{j + 1}");
                    }
                    // Пристроили сзади одну строку к другой и проверили
                    _concatString = string.Concat(StringsList.ElementAt(j) + StringsList.ElementAt(i));
                    if (IsStringTandemStyle(_concatString) == true)
                    {
                        Console.WriteLine($"{StringsList.ElementAt(j)}:{StringsList.ElementAt(i)}");
                        ResultStringList.Add($"{j + 1}:{i + 1}");
                    }
                }
            }
        }

        public ICollection<string> GetEnumOfString()
        {
            return this.ResultStringList;
        }

        /// <summary>
        /// Метод проверки является ли строка тандемной
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsStringTandemStyle(string str)
        {
            if(str == null) return false;
            if (str.Length % 2 != 0) return false;
            else
            {
                string[] substrings = new string[2];

                substrings[0] = str[0..(str.Length / 2)];
                substrings[1] = str[(str.Length / 2)..str.Length];

                if (GetStringHash(substrings[0]) == GetStringHash(substrings[1])) 
                    return true;
            }
            return false;    

        }

        /// <summary>
        /// Способ сравнить две строки на включение символов в произвольном порядке без перебора
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int GetStringHash(string str)
        {
            int hash = 0;
            if (str == null) return hash;
            else
            {
               
                for (int i = 0; i < str.Length; i++)
                {
                    // Просто сложи биты всех символов. У одинаковых по символьно (но не по порядку) срок они должны быть одинаковы
                    hash = hash ^ str[i].GetHashCode();
                }
            }
            return hash;

        }
        

    }
}
