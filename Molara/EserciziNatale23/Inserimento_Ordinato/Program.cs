namespace Inserimento_Ordinato
{
    internal class Program
    {
        static int sp = 0;

        static int[] espandi(int[] vettore, int spaziAggiuntivi)
        {
            int[] nuovo_Vettore = new int[spaziAggiuntivi + vettore.Length];

            for (int i = 0; i < vettore.Length; i++)
                nuovo_Vettore[i] = vettore[i];

            return nuovo_Vettore;

        }

        static void ShiftRight(int[] vettore, int indice)
        {
            for(int i = vettore.Length - 2; i >= indice; i--)
                vettore[i+1] = vettore[i];
        }

        static void inserimentoOrdinato(int[] vettore)
        {
            while (true)
            {
                Console.Write("Inserisci un numero positivo da inserire nella lista oppure un numero negativo per terminare: ");

                if (int.TryParse(Console.ReadLine(), out int numero))
                    if (numero >= 0)
                    {
                        if (vettore.Length == sp) vettore = espandi(vettore, 1);

                        if (sp == 0) vettore[0] = numero;
                        else
                        {
                            //trovo l'indice del primo numero minore o uguale al numero inserito e sposto tutti i valori dopo a destra di una posizione
                            for (int i = 0; i < sp; i++)
                                if (numero <= vettore[i])
                                {
                                    ShiftRight(vettore, i);
                                    vettore[i] = numero; //il numero viene inserito
                                    break;
                                } else if(sp == i+1) vettore[sp] = numero; //se il numero inserito è maggiore di tutti gli altri allora viene aggiunto alla fine
                        }

                        sp++;
                    }
                    else { Console.WriteLine("Inserimento terminato."); break; }
                else Console.WriteLine("Numero inserito non intero, riprova.");

                Console.WriteLine("\nvettore ora:");
                for (int i = 0; i < vettore.Length; i++)
                    Console.Write(vettore[i] + " ");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int[] valori = new int[10]; //inizializzo il vettore a 10, ma se questi non bastassero ne aumenterò la capienza tramite la funzione espandi()
            inserimentoOrdinato(valori);
        }
    }
}