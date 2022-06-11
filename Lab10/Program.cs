using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = Console.ReadLine(); //расскоментировать эту строку и закоментировать следующую, если требуется ввести другой текст
            string text = "У меня 10 долларов и 3 яблока. У ме990ня81 9 долларов и 2 яблока.";
            string result = "";

            Console.WriteLine("Исходная строка:");
            Console.WriteLine(text);

            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                //уменьшение числовых значений на 1, если числа представляют собой отдельностоящие слова
                if (words[i].Any() && words[i].All(Char.IsDigit))
                {
                    int number;
                    if (int.TryParse(words[i], out number))
                    {
                        number--;
                        words[i] = number.ToString();
                    }  
                }
                //уменьшение числовых значений на 1, если числа находятся внутри слова
                else if(IsContainDigits(words[i])!=0)
                {
                    string temp = "";
                    var start = -1;
                    for (int q = 0; q < words[i].Length; q++)
                    {
                        string temp1 = "";
                        if (start < 0 && Char.IsDigit(words[i][q]))
                        {
                            start = q;
                        }
                        else if (start >= 0 && !Char.IsDigit(words[i][q]))
                        {
                            temp1 = "";
                            int temp_num1 = int.Parse(words[i].Substring(start, q - start));
                            temp_num1--;
                            temp1 += temp_num1.ToString();
                            temp += temp1;
                            temp += words[i][q];
                            start = -1;
                        }
                        else if(!Char.IsDigit(words[i][q]))
                        {
                            temp += words[i][q];
                        }
                    }
                    int last = int.Parse(words[i].Substring(start, words[i].Length - start));
                    last--;
                    temp += last.ToString();
                    words[i] = temp;
                }
                result += words[i] + " ";
            }
            result = result.Remove(result.Length - 1);

            Console.WriteLine("\nИскомая строка:");
            Console.WriteLine(result);
            Console.ReadLine();
        }

        static int IsContainDigits(string substr)
        {
            int count = 0;
            if (substr.Contains('0')) { count++; }
            if (substr.Contains('1')) { count++; }
            if (substr.Contains('2')) { count++; }
            if (substr.Contains('3')) { count++; }
            if (substr.Contains('4')) { count++; }
            if (substr.Contains('5')) { count++; }
            if (substr.Contains('6')) { count++; }
            if (substr.Contains('7')) { count++; }
            if (substr.Contains('8')) { count++; }
            if (substr.Contains('9')) { count++; }
            return count;
        }
    }
}
