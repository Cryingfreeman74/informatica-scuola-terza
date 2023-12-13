/* Marco Balducci 3H 2023-12-13
 * Programma di conversione Hex - Bin dato dal professore e di cui capire il funzionamento
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin_Dec_scopri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool inputOk;

            #region Lettura e validazione numero da convertire

            string numero;
            do
            {
                inputOk = true;
                Console.Write("Inserire il numero da converitre base 16 (Max due Cifre) -> ");
                numero = Console.ReadLine().ToUpper();

                if(numero.Length > 2)
                {
                    Console.WriteLine("l'input è fuori dal range consentito.");
                    inputOk = false;
                }
                foreach (char c in numero)
                    if(!(((c >= 48) && (c <= 57)) || ((c >= 65) && (c <= 70)))) //controllo che il carattere sia corretto tramite la sua codifica ascii
                    {
                        Console.WriteLine("Carattere non ammesso");
                        inputOk = false;
                    }
            } while (!inputOk);

            #endregion

            int numCar = numero.Length;
            for (int i = 0; i < 2 - numCar; i++) numero = "0" + numero; //aggiunge il carattere zero a sx del numero se non è lungo 2

            //tabella di conversione
            string[] binario = new string[] { "0000", /* 0 */
                                              "0001", /* 1 */
                                              "0010", /* 2 */
                                              "0011", /* 3 */
                                              "0100", /* 4 */
                                              "0101", /* 5 */
                                              "0110", /* 6 */
                                              "0111", /* 7 */
                                              "1000", /* 8 */
                                              "1001", /* 9 */
                                              "1010", /* A */
                                              "1011", /* B */
                                              "1100", /* C */
                                              "1101", /* D */
                                              "1110", /* E */
                                              "1111"};/* F */
            string numeroBinario = "";
            foreach (char c in numero)
                if ((c - 48) <= 9) numeroBinario = numeroBinario + binario[c - 48];         //se il char è compreso tra 0 e 9
                else               numeroBinario = numeroBinario + binario[c - 65 + 10];    //se il char è compreso tra A ed F

            Console.WriteLine("Numero a base 2 -> " + numeroBinario);
            Console.ReadKey();
        }       
    }
}
