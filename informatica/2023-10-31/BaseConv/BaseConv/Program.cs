/*
 * Marco balducci 3H 31/10/2023 
 * programma che presenta 2 funzioni: una per convertire un numero intero in una data base ed un'altra in cui viene inserito un numero in una base che viene trasformato in base 10
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConv
{
    internal class Program
    {
        static char IntToChar(int valore)                   //conversione Int nel suo corrispettivo Char
        {
            if (valore < 10)                                //casi da 0 a 9
            {
                return (char)(valore + 48);
            }
            else                                            //casi da 10 a 36
            {
                return (char)(valore - 10 + 65);
            }

            return '?';
        }

        static int CharToInt(char digit)                    //conversione Char nel suo valore Int corrispettivo
        {
            string newDigit = digit.ToString();
            newDigit = newDigit.ToUpper();
            digit = newDigit[0];

            int valore;

            if (int.TryParse(digit.ToString(), out valore)); // se parsabile ritorno il valore parsato
            else                                             // se non parsabile ritorno il valore in int del char
            {
                valore = (int)digit - 65 + 10;
            }

            return valore;
        }
        static int BaseToInt(string valore, int b) //conversione da numero in base b a numero in base 10
        {
            int res = 0;

            if (b < 2 || b > 36) return -1; //se la base è fuori dal range ammesso

            for (int i = valore.Length - 1; i >= 0; i--)
            {
                res += CharToInt(valore[i]) * (int)Math.Pow(b, valore.Length - i - 1);
            }

            return res;
        }

        static string IntToBase(int valore, int b) //conversione numero in base 10 a numero in base b
        {
            if (valore < 0) return "value must be 0 or positive"; //se il numero è negativo
            
            if (b < 2 || b > 36) return "base must be between 2 and 36."; //se la base è fuori dal range ammesso

            string res = "";
            int resto;

            while(valore > 0) //conversione in base b
            {
                resto = valore % b;
                valore /= b;

                res = IntToChar(resto) + res;

            }

            return res;
        }

        static int ReadInt(string messaggio) //lettura intero per input
        {
            int res; //valore convertito

            while (true)
            {
                Console.Write("\n" + messaggio); //messaggio utente
                if (int.TryParse(Console.ReadLine(), out res)) return res; //se conversione ha successo restituisci, altrimenti ricicla
                else Console.WriteLine("Valore inserito non valido, riprova.");
            }
        }
        static void Main(string[] args)
        {
            /* test
            for (int b = 2; b <= 36; b++)
            {
                Console.WriteLine($"digit: {b}; base: {b}; {IntToBase(b, b)}");
            }
            
            Console.WriteLine(BaseToInt("1FE45", 16));
            */

            #region gestione input

            Console.WriteLine("BaseToInt [0] or IntToBase [1]");
            char response = Console.ReadKey().KeyChar;

            if(response == '0')
            {
                Console.Write("\n\ninserisci il numero in base: ");
                string numero = Console.ReadLine();

                
                int b = ReadInt("\ninserisci la base del numero: ");

                Console.WriteLine("\nNumero in base 10: " + BaseToInt(numero, b));
            } else
            {
                int numero = ReadInt("Inserisci il numero da convertire: ");
                int b = ReadInt("inserisci la base in cui convertire il numero: ");

                Console.WriteLine("\nNumero convertito: " + IntToBase(numero, b));
            }

            #endregion

            //termine programma
            Console.WriteLine("\n\nPremi un tasto per terminare il programma");
            Console.ReadKey();
        }
    }
}
