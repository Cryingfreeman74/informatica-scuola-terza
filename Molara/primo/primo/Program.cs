namespace primo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double media;
            int somma = 0, counter = 0;

            using (StreamReader sr = new StreamReader(@"..\..\..\..\dati.txt"))
            {
                while (!sr.EndOfStream) // la proprietà .EndOfStream è bool e diventa
                                        // true quando il file finisce
                {
                    string linea = sr.ReadLine(); // legge la prossima riga del file
                    somma += int.Parse(linea);
                    counter++;
                }
                sr.Close();
            }

            media = somma / counter;

            Console.WriteLine(media);
            Console.ReadKey();
        }
    }
}