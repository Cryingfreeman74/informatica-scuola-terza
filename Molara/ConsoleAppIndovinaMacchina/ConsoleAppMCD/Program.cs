using System;

namespace Esercizio1Cicli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stInput;
            int firstNumber;
            bool inputOk;
            int secondNumber;

            do
            {
                Console.Write("Inserire il primo numero da desidera calcolare -> ");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out firstNumber);

                if (!inputOk) Console.WriteLine("Input non valido, riprova");
                else if (firstNumber < 0)
                {
                    inputOk = false;
                    Console.WriteLine("Input non valido, il numero deve essere positivo");
                }

            } while (!inputOk);

            do
            {
                Console.Write("Inserire il secondo numero da desidera calcolare -> ");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out secondNumber);
                if (!inputOk) Console.WriteLine("Input non valido, riprova");
                else if (secondNumber < 0)
                {
                    inputOk = false;
                    Console.WriteLine("Input non valido, il numero deve essere positivo");
                }

            } while (!inputOk);

            

            while (secondNumber != 0)
            {
                int temp = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = temp;
            }

            Console.Write($"Il Massimo Comune Divisore tra {firstNumber} e {secondNumber} è {firstNumber}");

            Console.WriteLine("Premi un tasto per continuare");
            Console.ReadKey();
        }
    }
}