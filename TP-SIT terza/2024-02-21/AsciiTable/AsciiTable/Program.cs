using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiTable
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
            int padlength = 10;
            for (int i = 0; i < 32; i++)
            {
                    for(int j = 0; j < 4; j++)
                    {
                        int number = i + (j * 32);

                        Console.Write($"{number.ToString().PadRight(3)} <--> {getString(i+(j*32)).PadRight(padlength)} | ");
                    }
                    Console.WriteLine();
            }
                Console.ReadKey();
        }
    }
}
