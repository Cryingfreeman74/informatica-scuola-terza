using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sottoprogrammi
{
    internal class Program
    {

        static int LeggiValoreIntero(string messaggio, int valore_minimo, int valore_massimo) //prendono valore al momento della chiamata
        {

            int valore;

            while (true)
            {
                Console.WriteLine(messaggio);
                if (!int.TryParse(Console.ReadLine(), out valore)) //errore nella conversione intera
                {
                    continue;
                }
                if (valore < valore_minimo || valore_massimo < valore)
                    continue;

                break; //tutto ok!
            }

            return valore;
        }
        static void Main(string[] args)
        {

            int valore = LeggiValoreIntero("Inserisci un valore intero: ", 0, 23);
            LeggiValoreIntero("Inserisci i minuti del primo valore: ", 0, 59);
            LeggiValoreIntero("Inserisci i secondi del primo valore: ", 0, 59);

        }
    }
}
