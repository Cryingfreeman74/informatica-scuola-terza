/*
* Marco Balducci 3H 17/10/2023
* programma console che inserito un numero da 0 a 9 stampa a video la sua traduzione in italiano
* utilizzato l'operatore switch ed if.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNumeriParoleDa0_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Marco Balducci 3H"; //autore a video
            Console.WriteLine("Marco Balducci 3H\n");

            //dichiarazione dati
            int number;
            string strInput, output = "";
            bool inputOk; //controllo input

            #region lettura Input

            do
            {
                Console.Write("Inserisci il numero da tradurre [0 - 9] -> ");
                strInput = Console.ReadLine();//lettura input
                inputOk = int.TryParse(strInput, out number); //conversione e controllo

                if (!inputOk) Console.WriteLine("il valore inserito non è valido, riprova");//valore non intero
                if (number < 0 || number > 9)
                {
                    Console.WriteLine("Il valore inserito deve essere compreso tra 0 e 9, riprova");//valore fuori range
                    inputOk = false;
                }
            } while (!inputOk);

            #endregion


            #region conversione con switch

            switch (number) //controllo numero e assegnazione output
            {
                case 1:
                    output = "uno";
                    break;
                case 2:
                    output = "due";
                    break;
                case 3:
                    output = "tre";
                    break;
                case 4:
                    output = "quattro";
                    break;
                case 5:
                    output = "cinque";
                    break;
                case 6:
                    output = "sei";
                    break;
                case 7:
                    output = "sette";
                    break;
                case 8:
                    output = "otto";
                    break;
                case 9:
                    output = "nove";
                    break;
                case 0:
                    output = "zero";
                    break;
            }

            Console.WriteLine("Il numero inserito, elaborato con switch(), è -> " + output); //stampa output

            #endregion

            #region conversione con if

            if (number == 0) output = "zero"; //se numero = cifra -> output = cifra in italiano
            else if (number == 1) output = "uno";
            else if (number == 2) output = "due";
            else if (number == 3) output = "tre";
            else if (number == 4) output = "quattro";
            else if (number == 5) output = "cinque";
            else if (number == 6) output = "sei";
            else if (number == 7) output = "sette";
            else if (number == 8) output = "otto";
            else if (number == 9) output = "nove";

            Console.WriteLine("Il numero inserito, elaborato con if, è -> " + output); //stampa output

            #endregion

            //termine programma
            Console.WriteLine("Premi un tasto per continuare");
            Console.ReadKey();
        }
    }
}
