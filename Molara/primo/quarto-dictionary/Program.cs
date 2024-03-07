namespace quarto_dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> valori = new Dictionary<int, int>();

            using (StreamReader sr = new StreamReader(@"..\..\..\..\dati.txt"))
            {
                while (!sr.EndOfStream) // la proprietà .EndOfStream è bool e diventa
                                        // true quando il file finisce
                {
                    string linea = sr.ReadLine(); // legge la prossima riga del file
                    int valore = int.Parse(linea);

                    if(valori.ContainsKey(valore)) valori[valore]++;
                    else valori.Add(valore, 1);
                }
                sr.Close();
            }

            int num_values = valori.Count;

            using (StreamWriter sw = new StreamWriter(@"..\..\..\output.txt"))
            {
                foreach( var i in valori) 
                {
                    sw.WriteLine($"{i.Key} {i.Value}");
                }
                sw.Close();
            }
        }
    }
}