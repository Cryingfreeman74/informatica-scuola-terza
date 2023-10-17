/*Marco Balducci 3H 2023-10-11
 * Programma console che riceve in input un numero e lo converte in base 2 e 16.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolApp_conversione_base_2_16
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Autore
            Console.Title = "3H Balducci Marco";
            Console.WriteLine("3H Balducci Marco\n\n");

            //titolo programma   
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n~~~~~~~~~~~~~~~~~~ Conversione numero in binario ed Hex ~~~~~~~~~~~~~~~~~~\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");

            bool inputOk;
            int intNumber, input;
            string stInput, outputBase2 = "", outputBase16 = "", resto;

            #region lettura numero intero

            do
            {
                Console.Write("Inserisci il numero intero da convertire in base 2 e 16 -> ");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out input);

                if (!inputOk) Console.WriteLine("Il valore inserito non è intero, riprova");
                if (input < 0)
                {
                    inputOk = false;
                    Console.WriteLine("Il valore inserito deve essere positivo");
                }

            } while (!inputOk);

            #endregion

            #region Conversione in base 2

            intNumber = input; //inizializzazione variabile che cambia nel ciclo

            do
            {
                outputBase2 = (intNumber % 2).ToString() + outputBase2; //aggiunta resto prima degli altri resti
                intNumber /= 2;                               //divisione per 2 con approsimazione per difetto

            } while (intNumber > 0); //quando il numero arriva a 0 uscita dal ciclo

            #endregion

            #region Conversione in base 16

            intNumber = input; //inizializzazione variabile che cambia nel ciclo

            do
            {
                resto = (intNumber % 16).ToString(); 

                //controllo che il resto sia superiore a 9, in quel caso viene cambiato nella rispettiva cifra Hex
                if (resto == "10") resto = "a";
                else if (resto == "11") resto = "b";
                else if (resto == "12") resto = "c";
                else if (resto == "13") resto = "d";
                else if (resto == "14") resto = "e";
                else if (resto == "15") resto = "f";

                outputBase16 = resto + outputBase16; //aggiunta resto prima degli altri resti
                intNumber /= 16;                     //divisione per 16 con approsimazione per difetto

            } while (intNumber > 0); //quando il numero arriva a 0 uscita dal ciclo

            #endregion

            Console.WriteLine(outputBase2);
            Console.WriteLine(outputBase16);

            //termine programma
            Console.WriteLine("\n\nPremi un tasto per terminare il programma");
            Console.ReadKey();
        }
    }
}
