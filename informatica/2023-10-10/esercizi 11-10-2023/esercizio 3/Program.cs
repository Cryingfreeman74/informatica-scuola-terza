using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stInput;
            int firstHour = 0, secondHour = 0, intInput, difference, secondsOutput = 0, minutesOutput = 0, hoursOutput = 0;
            bool inputOk;

            #region lettura primo orario

            Console.WriteLine("\nInserisci il primo orario");

            do
            {
                Console.Write("ore ->");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out intInput);

                if (!inputOk) Console.WriteLine("Il valore inserito non è un numero intero, riprova\n");
                if(intInput < 0 || intInput > 23)
                {
                    inputOk = false;
                    Console.WriteLine("l'ora inserita non è valida, gli orari possibili vanno da 0 a 23, Riprova\n");
                }
            } while (!inputOk);

            firstHour += intInput * 60 * 60;

            do
            {
                Console.Write("minuti ->");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out intInput);

                if (!inputOk) Console.WriteLine("Il valore inserito non è un numero intero, riprova\n");
                if (intInput < 0 || intInput > 59)
                {
                    inputOk = false;
                    Console.WriteLine("I minuti inseriti non sono validi, i minuti possibili vanno da 0 a 59, Riprova\n");
                }
            } while (!inputOk);
            
            firstHour += intInput * 60;

            do
            {
                Console.Write("secondi ->");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out intInput);

                if (!inputOk) Console.WriteLine("Il valore inserito non è un numero intero, riprova\n");
                if (intInput < 0 || intInput > 59)
                {
                    inputOk = false;
                    Console.WriteLine("I secondi inseriti non sono validi, i secondi possibili vanno da 0 a 59, Riprova\n");
                }
            } while (!inputOk);

            firstHour += intInput;



            #endregion


            #region lettura secondo orario



            Console.WriteLine("\nInserisci il secondo orario");

            do
            {
                Console.Write("ore ->");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out intInput);

                if (!inputOk) Console.WriteLine("Il valore inserito non è un numero intero, riprova\n");
                if (intInput < 0 || intInput > 23)
                {
                    inputOk = false;
                    Console.WriteLine("l'ora inserita non è valida, gli orari possibili vanno da 0 a 23, Riprova\n");
                }
            } while (!inputOk);

            secondHour += intInput * 60 * 60;

            do
            {
                Console.Write("minuti ->");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out intInput);

                if (!inputOk) Console.WriteLine("Il valore inserito non è un numero intero, riprova\n");
                if (intInput < 0 || intInput > 59)
                {
                    inputOk = false;
                    Console.WriteLine("I minuti inseriti non sono validi, i minuti possibili vanno da 0 a 59, Riprova\n");
                }
            } while (!inputOk);

            secondHour += intInput * 60;

            do
            {
                Console.Write("secondi ->");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out intInput);

                if (!inputOk) Console.WriteLine("Il valore inserito non è un numero intero, riprova\n");
                if (intInput < 0 || intInput > 59)
                {
                    inputOk = false;
                    Console.WriteLine("I secondi inseriti non sono validi, i secondi possibili vanno da 0 a 59, Riprova\n");
                }
            } while (!inputOk);

            secondHour += intInput;




            #endregion


            #region differenza

            difference = secondHour - firstHour;

            if (difference < 0) difference *= -1;

            if (difference > 12*60*60) difference = 24*60*60 - difference;

            #endregion


            #region calcolo ore, minuti e secondi in output

            secondsOutput = difference % 60;
            difference = (difference - secondsOutput) / 60;

            minutesOutput = difference % 60;
            hoursOutput = (difference - secondsOutput) / 60;

            #endregion


            Console.WriteLine("\n\nLa differenza tra i due orari è di {0} ore, {1} minuti, {2} secondi.\n\npremi un tasto per terminare il programma.", hoursOutput, minutesOutput, secondsOutput);
            Console.ReadKey();
        }
    }
}
