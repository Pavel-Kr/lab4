using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class RomanNumberExtend : RomanNumber
    {
        private ushort LetterToNum(char letter)
        {
            ushort result = 0;
            switch (letter)
            {
                case 'I':
                    result = 1;
                    break;
                case 'V':
                    result = 5;
                    break;
                case 'X':
                    result = 10;
                    break;
                case 'L':
                    result = 50;
                    break;
                case 'C':
                    result = 100;
                    break;
                case 'D':
                    result = 500;
                    break;
                case 'M':
                    result = 1000;
                    break;
            }
            return result;
        }
        public RomanNumberExtend(string str)
        {
            int sameCount = 1;
            for(int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1]) sameCount++;
                else sameCount = 1;
                if (sameCount > 3) throw new RomanNumberException("Больше 3 одинаковых букв подряд");
            }
            bool lesser = false;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (LetterToNum(str[i]) < LetterToNum(str[i + 1]) && !lesser) lesser = true;
                else if (LetterToNum(str[i]) < LetterToNum(str[i + 1]) && lesser) throw new RomanNumberException("2 и более меньших цифры подряд");
                else lesser = false;
                if (LetterToNum(str[i + 1]) / LetterToNum(str[i]) > 10) throw new RomanNumberException("Уменьшающая цифра слишком мала");
                
            }
            roman = str;
            for(int i = 0; i < str.Length-1; i++)
            {
                if (LetterToNum(str[i]) < LetterToNum(str[i + 1])) arabic -= LetterToNum(str[i]);
                else arabic += LetterToNum(str[i]);
            }
            arabic += LetterToNum(str[str.Length - 1]);
        }
        public int ToInt()
        {
            return arabic;
        }
    }
}
