using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace terzo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> valori = new List<int>();
            using (StreamReader sr = new StreamReader(@"..\..\..\..\dati.txt"))
            {
                while (!sr.EndOfStream) // la proprietà .EndOfStream è bool e diventa
                                        // true quando il file finisce
                {
                    string linea = sr.ReadLine(); // legge la prossima riga del file
                    valori.Add(int.Parse(linea));
                }
                sr.Close();
            }

            //sorting della lista
            for(int i = 0; i < valori.Count; i++)
            {
                int min = i;
                for(int j = i+1; j < valori.Count; j++)
                {
                    if (valori[j] < valori[min]) min = j;
                }
                if(min != i)
                {
                    int temp = valori[min];
                    valori[min] = valori[i];
                    valori[i] = temp;
                }
            }

            int num_values = valori.Count;

            using (StreamWriter sw = new StreamWriter(@"..\..\..\output.txt"))
            {
                for (int i = 0; i < num_values; ++i)
                    sw.WriteLine(valori[i]);
                sw.Close();
            }
        }
    }
}