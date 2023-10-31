/*
 *Marco Balducci 3H 25/10/2023
 *Progetto a console che riceve in ingresso un hex con al massimo 2 cifre e restituisce in output le conversioni in hex ed in decimale
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConversioneHex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region autore

            Console.Title = "3H Balducci Marco";
            Console.WriteLine("3H Balducci Marco\n\n");

            #endregion

            string numeroHex, numeroBinario;
            bool InputOk = true;
            int numeroDecimale = 0;
            char firstDigit = ' ', secondDigit = ' ';

            #region controllo input

            do //lettura valore e controllo
            {
                Console.Write("Input valore Hex da convertire [max 2 cifre] -> ");
                numeroHex = Console.ReadLine().Trim(); //tolgo gli spazi

                if(numeroHex.Length > 2) //non può avere + di due cifre
                {
                    InputOk = false;
                    Console.WriteLine("Il numero deveavere al massimo 2 cifre, riprova");
                } else if(numeroHex.Length == 0) //non può essere vuoto
                {
                    InputOk = false;
                    Console.WriteLine("Non hai inserito alcun numero, riprova");
                } else if(numeroHex.Length == 1) //in questo caso numero hex ha 1 cifra
                {
                    numeroHex = numeroHex.ToUpper();
                    firstDigit = numeroHex[0];

                    if (!(firstDigit == 'A' || firstDigit == 'B' || firstDigit == 'C' || firstDigit == 'D' || firstDigit == 'E' || firstDigit == 'F' || int.TryParse(numeroHex, out numeroDecimale))) //controllo che sia veramente in hex
                    {
                        InputOk = false;
                        Console.WriteLine("Il numero che hai inserito non è in esadecimale, riprova");
                    }
                    else InputOk = true;
                }
                else // in questo caso il numero hex ha 2 cifre
                {
                    numeroHex = numeroHex.ToUpper();
                    firstDigit = numeroHex[1];
                    secondDigit = numeroHex[0];

                    if (!(firstDigit == 'A' || firstDigit == 'B' || firstDigit == 'C' || firstDigit == 'D' || firstDigit == 'E' || firstDigit == 'F' || int.TryParse(firstDigit.ToString(), out numeroDecimale))) //controllo che sia veramente in hex
                    {
                        InputOk = false;
                        Console.WriteLine("Il numero che hai inserito non è in esadecimale, riprova");
                    } else if (!(secondDigit == 'A' || secondDigit == 'B' || secondDigit == 'C' || secondDigit == 'D' || secondDigit == 'E' || secondDigit == 'F' || int.TryParse(secondDigit.ToString(), out numeroDecimale)))
                    {
                        InputOk = false;
                        Console.WriteLine("Il numero che hai inserito non è in esadecimale, riprova");
                    }
                }

            } while (!InputOk); //ricicla se input non valido

            #endregion

            #region conversione decimale

            switch (firstDigit) //la prima cifra c'è sempre
            {
                case 'A':
                    numeroDecimale += 10;
                    break;

                case 'B':
                    numeroDecimale += 11;
                    break;

                case 'C':
                    numeroDecimale += 12;
                    break;

                case 'D':
                    numeroDecimale += 13;
                    break;

                case 'E':
                    numeroDecimale += 14;
                    break;

                case 'F':
                    numeroDecimale += 15;
                    break;

                default:
                    numeroDecimale += int.Parse(firstDigit.ToString());
                    break;
            }

            if (secondDigit != ' ') //se ci sono 2 cifre
            {
                switch (secondDigit)
                {
                    case 'A':
                        numeroDecimale += 10*16;
                        break;

                    case 'B':
                        numeroDecimale += 11*16;
                        break;

                    case 'C':
                        numeroDecimale += 12*16;
                        break;

                    case 'D':
                        numeroDecimale += 13*16;
                        break;

                    case 'E':
                        numeroDecimale += 14*16;
                        break;

                    case 'F':
                        numeroDecimale += 15*16;
                        break;

                    default:
                        numeroDecimale += int.Parse(firstDigit.ToString()) * 16;
                        break;
                }
            }

            #endregion

            Console.WriteLine(numeroDecimale);
            Console.ReadKey();

        }
    }
}
