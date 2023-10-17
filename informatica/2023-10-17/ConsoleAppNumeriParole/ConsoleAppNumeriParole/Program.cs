/*
 * Marco Balducci 3H 17/10/2023
 * programma console che inserito un numero da 0 a 9999 stampa a video la sua traduzione in italiano
 * utilizzato l'operatore switch.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNumeriParole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Marco Balducci 3H"; //autore a video
            Console.WriteLine("Marco Balducci 3H\n");

            //dichiarazione dati
            int number;
            bool inputOk, teenCase = false; //controllo input e casi particolari (11-19)
            string strInput, result = "";

            #region input numero

            do
            {
                Console.Write("Inserisci il numero da tradurre [0 - 9999] -> ");
                strInput = Console.ReadLine();//lettura input
                inputOk = int.TryParse(strInput, out number); //conversione e controllo

                if (!inputOk) Console.WriteLine("il valore inserito non è valido, riprova");//valore non intero
                if (number < 0 || number > 9999)
                {
                    Console.WriteLine("Il valore inserito deve essere compreso tra 0 e 9999, riprova");//valore fuori range
                    inputOk = false;
                }
            } while (!inputOk);

            #endregion


            #region traduzione numero

            #region migliaia

            switch (number / 1000) //considero solo le migliaia
            {
                case 1:
                    result = "mille";
                    break;
                case 2:
                    result = "duemila";
                    break;
                case 3:
                    result = "tremila";
                    break;
                case 4:
                    result = "quattromila";
                    break;
                case 5:
                    result = "cinquemila";
                    break;
                case 6:
                    result = "seimila";
                    break;
                case 7:
                    result = "settemila";
                    break;
                case 8:
                    result = "ottomila";
                    break;
                case 9:
                    result = "novemila";
                    break;
            }

            number = number % 1000; //number diventa centinaia + decine + unità

            #endregion

            #region centinaia

            switch (number/100) //considero solo le centinaia
            {
                case 1:
                    result += "cento";
                    break;
                case 2:
                    result += "duecento";
                    break;
                case 3:
                    result += "trecento";
                    break;
                case 4:
                    result += "quattrocento";
                    break;
                case 5:
                    result += "cinquecento";
                    break;
                case 6:
                    result += "seicento";
                    break;
                case 7:
                    result += "settecento";
                    break;
                case 8:
                    result += "ottocento";
                    break;
                case 9:
                    result += "novecento";
                    break;
            }

            number = number % 100; //number diventa decine + unità

            #endregion

            #region decine

            switch (number/10) //considero solo le decine
            {
                case 1: //casi particolari tra 11 e 19
                    switch (number)
                    {
                        case 11:
                            result += "undici";
                            break;
                        case 12:
                            result += "undici";
                            break;
                        case 13:
                            result += "undici";
                            break;
                        case 14:
                            result += "undici";
                            break;
                        case 15:
                            result += "undici";
                            break;
                        case 16:
                            result += "undici";
                            break;
                        case 17:
                            result += "undici";
                            break;
                        case 18:
                            result += "undici";
                            break;
                        case 19:
                            result += "undici";
                            break;
                    }

                    teenCase = true; //se rientra in uno dei casi da 11 a 19 lo ricordo per quando dovrò considerare le unità
                    break;

                case 2:
                    result += "venti";
                    break;
                case 3:
                    result += "trenta";
                    break;
                case 4:
                    result += "quaranta";
                    break;
                case 5:
                    result += "cinquanta";
                    break;
                case 6:
                    result += "sessanta";
                    break;
                case 7:
                    result += "settanta";
                    break;
                case 8:
                    if(result != "") result = result.Substring(0, result.Length - 1);
                    result += "ottanta";
                    break;
                case 9:
                    result += "novanta";
                    break;
            }

            #endregion

            #region unità

            if (!teenCase) //se il numero rientra nei casi tra 11 e 19, allora non vengono considerate le unità nel tradurre.
            {
                switch (number % 10) //considero le unità
                {
                    case 0:
                        if (result == "") result = "zero";
                        break;
                    case 1:
                        if (number / 10 != 0) result = result.Substring(0, result.Length - 1);
                        result += "uno";
                        break;
                    case 2:
                        result += "due";
                        break;
                    case 3:
                        result += "tre";
                        break;
                    case 4:
                        result += "quattro";
                        break;
                    case 5:
                        result += "cinque";
                        break;
                    case 6:
                        result += "sei";
                        break;
                    case 7:
                        result += "sette";
                        break;
                    case 8:
                        if(number / 10 != 0) result = result.Substring(0, result.Length - 1);
                        result += "otto";
                        break;
                    case 9:
                        result += "nove";
                        break;
                }
            }

            #endregion

            #endregion

            Console.WriteLine("il numero da lei inserito è -> " + result); //output

            //fine programma
            Console.WriteLine("\n\nPremi un tasto per continuare");
            Console.ReadKey();
        }
    }
}
