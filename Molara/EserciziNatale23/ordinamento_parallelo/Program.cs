namespace ordinamento_parallelo
{
    internal class Program
    {
        static int[] espandiInt(int[] vettore, int spaziAggiuntivi)
        {
            int[] nuovo_Vettore = new int[spaziAggiuntivi + vettore.Length];

            for (int i = 0; i < vettore.Length; i++)
                nuovo_Vettore[i] = vettore[i];

            return nuovo_Vettore;

        }
        static string[] espandiString(string[] vettore, int spaziAggiuntivi)
        {
            string[] nuovo_Vettore = new string[spaziAggiuntivi + vettore.Length];

            for (int i = 0; i < vettore.Length; i++)
                nuovo_Vettore[i] = vettore[i];

            return nuovo_Vettore;

        }
        static void ShiftRightInt(int[] vettore, int indice)
        {
            for (int i = vettore.Length - 2; i >= indice; i--)
                vettore[i+1] = vettore[i];
        }

        static void ShiftRightString(string[] vettore, int indice)
        {
            for (int i = vettore.Length - 2; i >= indice; i--)
                vettore[i + 1] = vettore[i];
        }

        static void Main(string[] args)
        {
            int[] età = new int[1];
            string[] nomi = new string[1];
            int sp = 0;

            while (true)
            {
                #region ottengo nome ed età

                Console.Write($"Inserire il nome della persona numero {sp+1}: ");
                string nome = Console.ReadLine();
                int anni = 0;

                while (true)
                {
                    Console.Write($"Inserire il nome della persona numero {sp+1}: ");
                    if (int.TryParse(Console.ReadLine(), out anni))
                        if (anni >= 0) break;
                        else Console.WriteLine(nome + " non può avere un'età negativa! riprova.");
                    else Console.WriteLine("Valore inserito non intero, riprova");
                }

                #endregion

                if(sp == nomi.Length) { età = espandiInt(età, 1); nomi = espandiString(nomi, 1); }
                if(sp == 0) { nomi[sp] = nome; età[sp] = anni; }
                else
                {
                    for (int j = 0; j < sp; j++)
                        if (anni <= età[j])
                        {
                            ShiftRightInt(età, j);
                            età[j] = anni;
                            ShiftRightString(nomi, j);
                            nomi[j] = nome;
                            break;
                        }
                        else if (sp == j + 1) { età[sp] = anni; nomi[sp] = nome; }
                }
                
                
                sp++;

                for (int i = 0; i < nomi.Length; i++)
                {
                    Console.Write(nomi[i] + ": " + età[i] + "\n");
                }
                    

                Console.WriteLine("\nVuole continuare con l'inserimento? [Y/n]\n");
                if (Console.ReadKey(true).KeyChar.ToString().ToUpper() == "N") break;
            }
        }
    }
}