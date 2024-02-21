using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeTable
{
    internal class Program
    {
        static string getString(int i)
        {
            string result = "";

            if (char.IsControl((char)i))
            {
                result = "Controllo";
            }
            else
            {
                if (char.IsWhiteSpace((char)i))
                {
                    result = "Spazio";
                }
                else
                {
                    result += (char)i;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int padlength = 10;
            for (int i = 0; i < 8192; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int number = i + (j * 8192);

                    Console.Write($"{number.ToString().PadRight(5)} <--> {getString(i + (j * 8192)).PadRight(padlength)} | ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
