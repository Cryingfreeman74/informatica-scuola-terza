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
                Console.Write("Inserisci il numero da tradurre [0 - 9999] -> "); //messaggio a video
                strInput = Console.ReadLine();//lettura input
                inputOk = int.TryParse(strInput, out number); //conversione e controllo

                if (!inputOk) Console.WriteLine("il valore inserito non è valido, riprova");//valore non intero
                if (number < 0 || number > 9999) //controllo range
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
                    result = "mille"; //aggiunta migliaia
                    break;
                case 2:
                    result = "duemila";//aggiunta migliaia
                    break;
                case 3:
                    result = "tremila"; //aggiunta migliaia
                    break;
                case 4:
                    result = "quattromila"; //aggiunta migliaia
                    break;
                case 5:
                    result = "cinquemila"; //aggiunta migliaia
                    break;
                case 6:
                    result = "seimila"; //aggiunta migliaia
                    break;
                case 7:
                    result = "settemila";//aggiunta migliaia
                    break;
                case 8:
                    result = "ottomila"; //aggiunta migliaia
                    break;
                case 9:
                    result = "novemila"; //aggiunta migliaia
                    break;
            }

            number = number % 1000; //number diventa centinaia + decine + unità

            #endregion

            #region centinaia

            switch (number/100) //considero solo le centinaia
            {
                case 1:
                    result += "cento"; //aggiunta centinaia
                    break;
                case 2:
                    result += "duecento"; //aggiunta centinaia
                    break;
                case 3:
                    result += "trecento"; //aggiunta centinaia
                    break;
                case 4:
                    result += "quattrocento"; //aggiunta centinaia
                    break;
                case 5:
                    result += "cinquecento"; //aggiunta centinaia
                    break;
                case 6:
                    result += "seicento"; //aggiunta centinaia
                    break;
                case 7:
                    result += "settecento"; //aggiunta centinaia
                    break;
                case 8:
                    result += "ottocento"; //aggiunta centinaia
                    break;
                case 9:
                    result += "novecento"; //aggiunta centinaia
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
                            result += "dodici";
                            break;
                        case 13:
                            result += "tredici";
                            break;
                        case 14:
                            result += "quattordici";
                            break;
                        case 15:
                            result += "quindici";
                            break;
                        case 16:
                            result += "sedici";
                            break;
                        case 17:
                            result += "diciassette";
                            break;
                        case 18:
                            result += "diciotto";
                            break;
                        case 19:
                            result += "diciannove";
                            break;
                    }

                    teenCase = true; //se rientra in uno dei casi da 11 a 19 lo ricordo per quando dovrò considerare le unità
                    break;

                case 2:
                    result += "venti"; //aggiunta decina
                    break;
                case 3:
                    result += "trenta";//aggiunta decina
                    break;
                case 4:
                    result += "quaranta";//aggiunta decina
                    break;
                case 5:
                    result += "cinquanta";//aggiunta decina
                    break;
                case 6:
                    result += "sessanta";//aggiunta decina
                    break;
                case 7:
                    result += "settanta";//aggiunta decina
                    break;
                case 8:
                    if (result != "")
                    {
                        if(!result.EndsWith("A")) result = result.Substring(0, result.Length - 1); //se finisce con A non può essere troncato
                    }
                        result += "ottanta"; //aggiunta decina
                    break;
                case 9:
                    result += "novanta"; //aggiunta decina
                    break;
            }

            #endregion

            #region unità

            if (!teenCase) //se il numero rientra nei casi tra 11 e 19, allora non vengono considerate le unità nel tradurre.
            {
                switch (number % 10) //considero le unità, il numero contiene ancora sia decine che unità
                {
                    case 0:
                        if (result == "") result = "zero"; //lo zero viene aggiunto solo se il numero è 0.
                        break;
                    case 1:
                        if (number / 10 != 0) result = result.Substring(0, result.Length - 1); //se il numero ha una decina diversa da 0, allora avviene il troncamento
                        result += "uno"; //aggiunta unità
                        break;
                    case 2:
                        result += "due"; //aggiunta unità
                        break;
                    case 3:
                        result += "tre"; //aggiunta unità
                        break;
                    case 4:
                        result += "quattro"; //aggiunta unità
                        break;
                    case 5:
                        result += "cinque";//aggiunta unità
                        break;
                    case 6:
                        result += "sei"; //aggiunta unità
                        break;
                    case 7:
                        result += "sette"; //aggiunta unità
                        break;
                    case 8:
                        if(number / 10 != 0) result = result.Substring(0, result.Length - 1); //se il numero ha una decina diversa da 0 aviene il troncamento
                        result += "otto"; //aggiunta unità
                        break;
                    case 9:
                        result += "nove"; //aggiunta unità
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
