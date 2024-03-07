using System.Diagnostics.Metrics;

namespace secondo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserire il numero di cui cercare le occorrenze: ");
            int valore = int.Parse(Console.ReadLine());
            int counter = 0;

            using (StreamReader sr = new StreamReader(@"..\..\..\..\dati.txt"))
            {
                while (!sr.EndOfStream) // la proprietà .EndOfStream è bool e diventa
                                        // true quando il file finisce
                {
                    string linea = sr.ReadLine(); // legge la prossima riga del file
                    if(int.Parse(linea) == valore) counter++;
                }
                sr.Close();
            }

            if (counter == 0) Console.WriteLine("Non presente nel file");
            else Console.WriteLine($"Il valore {valore} è contenuto nel file {counter} volta/e.");
        }
    }
}