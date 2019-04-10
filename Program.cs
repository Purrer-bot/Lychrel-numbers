using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Polyndrome
{
    class Program
    {
        static List<int> numbers = new List<int>();
        static Random rand = new Random();

        static void Generator(int NUM)
        {
            for (int i = 0; i < NUM; i++)
            {
                numbers.Add(i + 10);
            }
        }

        static void Count_Polyndrome(List<int> lis)
        {
            foreach (var n in lis)
            {

                char[] numb = Convert.ToString(n).ToCharArray();
                Array.Reverse(numb);
                Console.WriteLine(n + " перевернулось в " + (new string(numb)));

            }
        }

        static void Chech_Polyndrome(int dig, int iter)
        {
            bool is_palindrome = true;
            char[] numb = Convert.ToString(dig).ToCharArray();
            Array.Reverse(numb);
            Console.WriteLine(dig + " перевернулось в " + (new string(numb)));
            char[] digit = Convert.ToString(dig).ToCharArray();
            for (int j = 0; j < iter; j++)
            {
                for (int i = 0; i < numb.Length; i++)
                {
                    if (digit[i] != numb[i])
                    {
                        Console.WriteLine("Хуита");
                        is_palindrome = false;
                        break;
                    }
                }
                if (is_palindrome != false)
                {
                    Console.WriteLine("Це палиндром!");
                }

            }

        }


        //==============================================================
        static void Reverse(char[] str)
        {
            Array.Reverse(str);
        }

        static bool Is_Equal(char[] str1, char[] str2)
        {
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }
            return true;
        }

        static ulong Get_Numbers_Sum(ulong num)
        {
            ulong sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

        static List<ulong> Generate_Numbers(int beg, int n)
        {
            List<ulong> gen_list = new List<ulong>();
            for (ulong i = (ulong)beg; i < (ulong)n; i++)
            {
                gen_list.Add(i);
            }
            return gen_list;
        }


        static void Addiction(ulong number, int ITER)
        {
            char[] char_reverse = Convert.ToString(number).ToCharArray();
            List<ulong> y_str = new List<ulong>();
            char[] char_str = Convert.ToString(number).ToCharArray();

            using (StreamWriter sw = new StreamWriter("D:\\outsource.txt", true))
            {
                for (int i = 0; i < ITER; i++)
                {

                    Reverse(char_reverse);
                    sw.Write(i + " ");
                    y_str.Add((ulong)Convert.ToInt64(new string(char_str)) + (ulong)Convert.ToInt64(new string(char_reverse)));
                    Console.WriteLine("x = {0} | y = {1}", i + 1, (ulong)Convert.ToInt64(new string(char_str)) + (ulong)Convert.ToInt64(new string(char_reverse)));
                    Array.Resize(ref char_str, char_str.Length);

                    char_str = Convert.ToString((ulong)Convert.ToInt64(new string(char_str)) + (ulong)Convert.ToInt64(new string(char_reverse))).ToCharArray();
                    Array.Resize(ref char_reverse, char_str.Length);
                    Array.Copy(char_str, char_reverse, char_str.Length);

                }
                sw.WriteLine("");
                foreach(var y in y_str)
                {
                    sw.Write(y + " ");
                }

            }

        }


        static void Palindrome(List<ulong> list, int ITER)
        {
            foreach (var num in list)
            {
                Console.WriteLine("Исходное число: {0}", num);
                int k = 0;
                string number = Convert.ToString(num);
                char[] char_reverse = number.ToCharArray();
                //List<char> char_str = Convert.ToString(num).ToCharArray();
                char[] char_str = Convert.ToString(num).ToCharArray();

                while (!Is_Equal(char_str, char_reverse) || k <= ITER)
                {
                    Reverse(char_reverse);
                    k += 1;
                    Console.WriteLine("Промежуточный результат: {0} | Реверс: {1}", new string(char_str), new string(char_reverse));
                    Console.WriteLine("Сумма цифр числа = {0} | Сумма цифр реверса = {1} | Итерация №{2}\n", Get_Numbers_Sum((ulong)Convert.ToInt64(new string(char_str))), Get_Numbers_Sum((ulong)Convert.ToInt64(new string(char_reverse))), k);

                    if (Is_Equal(char_str, char_reverse))
                    {
                        Console.WriteLine("Палиндром для числа {0} = {1} | Число итераций = {2}", num, new string(char_str), k);
                        Console.WriteLine("Сумма цифр палииндрома = {0}", Get_Numbers_Sum((ulong)Convert.ToInt64(new string(char_reverse))));
                        Console.WriteLine("=============================================================");
                        break;
                    }
                    Array.Resize(ref char_str, char_str.Length);

                    char_str = Convert.ToString((ulong)Convert.ToInt64(new string(char_str)) + (ulong)Convert.ToInt64(new string(char_reverse))).ToCharArray();
                    Array.Resize(ref char_reverse, char_str.Length);
                    Array.Copy(char_str, char_reverse, char_str.Length);
                }

            }
        }

        static void Main(string[] args)
        {
            //List<ulong> list = Generate_Numbers(196, 250);
            //Palindrome(list, 10);
            Addiction(689, 20);
            //Generator(200);
            //Count_Polyndrome(numbers);
            //Chech_Polyndrome(22, 1000);
            Console.ReadLine();
        }
    }
}
