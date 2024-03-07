namespace quarto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> valori = new List<int>();
            List<int> frequenza = new List<int>();

            using (StreamReader sr = new StreamReader(@"..\..\..\..\dati.txt"))
            {
                while (!sr.EndOfStream) // la proprietà .EndOfStream è bool e diventa
                                        // true quando il file finisce
                {
                    string linea = sr.ReadLine(); // legge la prossima riga del file
                    int valore = int.Parse(linea);

                    if (!valori.Contains(valore))
                    {
                        valori.Add(valore);
                        frequenza.Add(1);
                    }
                    else
                    {
                        frequenza[valori.IndexOf(valore)]++;
                    }
                }
                sr.Close();
            }

            int num_values = valori.Count;

            using (StreamWriter sw = new StreamWriter(@"..\..\..\output.txt"))
            {
                for (int i = 0; i < num_values; ++i)
                    sw.WriteLine($"{valori[i]} {frequenza[i]}");
                sw.Close();
            }
        }
    }
}