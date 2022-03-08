using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        protected ushort arabic;
        protected string roman;
        public RomanNumber() { }
        //Конструктор получает представление числа n в римской записи
        public RomanNumber(ushort n)
        {
            if (n <= 0) throw new RomanNumberException("Число должно быть больше 0");
            arabic = n;
            roman = "";
            while (n > 0)
            {
                if (n >= 1000)
                {
                    roman += "M";
                    n -= 1000;
                }
                else if (n >= 900)
                {
                    roman += "CM";
                    n -= 900;
                }
                else if (n >= 500)
                {
                    roman += "D";
                    n -= 500;
                }
                else if (n >= 400)
                {
                    roman += "CD";
                    n -= 400;
                }
                else if (n >= 100)
                {
                    roman += "C";
                    n -= 100;
                }
                else if (n >= 90)
                {
                    roman += "XC";
                    n -= 90;
                }
                else if (n >= 50)
                {
                    roman += "L";
                    n -= 50;
                }
                else if (n >= 40)
                {
                    roman += "XL";
                    n -= 40;
                }
                else if (n >= 10)
                {
                    roman += "X";
                    n -= 10;
                }
                else if (n >= 9)
                {
                    roman += "IX";
                    n -= 9;
                }
                else if (n >= 5)
                {
                    roman += "V";
                    n -= 5;
                }
                else if (n >= 4)
                {
                    roman += "IV";
                    n -= 4;
                }
                else if (n >= 1)
                {
                    roman += "I";
                    n -= 1;
                }
            }
        }
        //Сложение римских чисел
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException();
            RomanNumber n3 = new RomanNumber(Convert.ToUInt16(n1.arabic + n2.arabic));
            return n3;
        }
        //Вычитание римских чисел
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException();
            if (n1.arabic - n2.arabic <= 0) throw new RomanNumberException("Разность меньше 0");
            ushort x = Convert.ToUInt16(n1.arabic - n2.arabic);
            RomanNumber n3 = new RomanNumber(x);
            return n3;
        }
        //Умножение римских чисел
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException();
            RomanNumber n3 = new RomanNumber(Convert.ToUInt16(n1.arabic * n2.arabic));
            return n3;
        }
        //Целочисленное деление римских чисел
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException();
            if (n1.arabic - n2.arabic <= 0) throw new RomanNumberException("Делитель должен быть меньше делимого");
            ushort x = Convert.ToUInt16(n1.arabic / n2.arabic);
            RomanNumber n3 = new RomanNumber(x);
            return n3;
        }
        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            return roman;
        }
        public object Clone()
        {
            return new RomanNumber(arabic);
        }
        public int CompareTo(object? o)
        {
            if (o is RomanNumber number) return arabic.CompareTo(Convert.ToUInt16(number.arabic));
            else throw new ArgumentException("Некорректное значение параметра");
        }
    }
}
