using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Esercizi_Matrici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Num_materie = getIntWithMinMax(1, 1000, "Inserisci il numero delle materie: ");
            int Num_alunni = getIntWithMinMax(1, 1000, "Inserisci il numero degli alunni: ");

            string[] materie = new string[Num_materie];
            string[] alunni = new string[Num_alunni];
            for (int i = 0; i < Num_materie; i++) { Console.Write($"Inserisci il nome della materia numero {i + 1}: "); materie[i] = Console.ReadLine(); }
            for (int i = 0; i < Num_alunni; i++) { Console.Write($"Inserisci il nome dell'alunno numero {i + 1}: "); alunni[i] = Console.ReadLine(); }

            Console.WriteLine("Inserisci ora i voti riferiti al primo quadrimestre: ");
            int[,] pagellaT1 = CreaPagella(materie, alunni);
            Console.WriteLine("Inserisci ora i voti riferiti al secondo quadrimestre: ");
            int[,] pagellaT2 = CreaPagella(materie, alunni);

#if false //stampa contenuto pagelle

            Console.WriteLine("Primo Quadrimestre");
            for(int i = 0; i < Num_alunni; i++)
            {
                Console.WriteLine("\n" + alunni[i] + " ");
                for(int j = 0; j < Num_materie; j++)
                {
                    Console.Write(pagellaT1[i, j] + " ");
                }
            }

            Console.WriteLine("\nSecondo Quadrimestre");
            for (int i = 0; i < Num_alunni; i++)
            {
                Console.WriteLine("\n" + alunni[i] + " ");
                for (int j = 0; j < Num_materie; j++)
                {
                    Console.Write(pagellaT2[i, j] + " ");
                }
            }

#endif

            //stampa media della classe
            MediaClasse(pagellaT1, pagellaT2, alunni);
            Console.WriteLine("Alunno con la media più alta nel primo quadrimestre: " + MediaMassima(pagellaT1, alunni));
            Console.WriteLine("Alunno con la media più alta nel secondo quadrimestre: " + MediaMassima(pagellaT2, alunni));

            Console.Write("Inserisci il nome dell'alunno di cui stampare le insufficienze: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Primo quadrimestre:");
            trovaInsufficienze(pagellaT1, alunni, materie, nome);
            Console.WriteLine("Secondo quadrimestre:");
            trovaInsufficienze(pagellaT2, alunni, materie, nome);
            Console.WriteLine("Inserisci il nome della materia di cui stampare le medie: ");
            MediaMateria(pagellaT1, pagellaT2, materie, Console.ReadLine());
        }

        static int getIntWithMinMax(int minimum, int max, string message)
        {
            while(true) 
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    if (num >= minimum && num <= max) return num;
                    else Console.WriteLine($"Numero inserito deve essere minore (compreso) di {max} e maggiore (compreso) di {minimum}, riprova");
                }
                else Console.WriteLine("Numero inserito non intero, riprova");
            }
        }

        static double Media(int[,] pagella, string[] nomi, string alunno)
        {
            int pos_alunno = -1, j;
            for(int i = 0; i < nomi.Length; i++)
            {
                if (nomi[i].ToUpper() == alunno.ToUpper()) { pos_alunno = i;  break; }
            }

            if(pos_alunno == -1) { Console.WriteLine(); return -1.1; }
            double media = 0.0;
            for(j = 0; j < pagella.GetLength(0); j++) media += pagella[pos_alunno,j];
            media /= j;

            return media;
        }

        #region funzioni compito

        static string MediaMassima(int[,] pagella, string[] nomi)
        {
            double mediaMax = 0.0;
            int alunnoMax = -1;
            for(int i = 0; i < pagella.GetLength(0); i++)
            {
                double mediaCorrente = Media(pagella, nomi, nomi[i]);
                if (mediaCorrente > mediaMax) { mediaMax = mediaCorrente; alunnoMax = i; };
            }
            return nomi[alunnoMax];
        }

        static void MediaMateria(int[,] pagellaT1, int[,] pagellaT2, string[] materie, string materia)
        {
            int materia_pos = -1;
            for (int i = 0; i < materie.Length; i++) if (materie[i].ToUpper() == materia.ToUpper()) materia_pos = i;

            if (materia_pos == -1) { Console.WriteLine(materia + " non esiste.");}
            else //materia esiste
            {
                double mediaT1 = 0.0;
                double mediaT2 = 0.0;
                for (int i = 0; i < pagellaT1.GetLength(1); i++)
                {
                    mediaT1 += pagellaT1[i, materia_pos];
                    mediaT2 += pagellaT2[i, materia_pos];
                }

                mediaT1 /= pagellaT1.GetLength(1);
                mediaT2 /= pagellaT2.GetLength(1);

                Console.WriteLine($"Media di {materia} nel primo quadrimestre: {mediaT1:0.00}; secondo quadrimestre: {mediaT2:0.00}");
            }
        }

        static void MediaClasse(int[,] pagellaT1, int[,] pagellaT2, string[] nomi)
        {
            double media = 0.0;
            for(int i = 0; i < pagellaT1.GetLength(1); i++)
                media += Media(pagellaT1, nomi, nomi[i]);
            media/= pagellaT1.GetLength(1);

            Console.WriteLine($"Media della classe nel primo quadrimestre: {media:0.00}");
            media = 0.0;
            for (int i = 0; i < pagellaT2.GetLength(1); i++)
                media += Media(pagellaT2, nomi, nomi[i]);
            media /= pagellaT2.GetLength(1);
            Console.WriteLine($"Media della classe nel secondo quadrimestre: {media:0.00}");
        }

        static void trovaInsufficienze(int[,] pagella, string[] nomi, string[] materie, string alunno)
        {
            int pos_alunno = -1;
            for (int i = 0; i < nomi.Length; i++)
            {
                if (nomi[i].ToUpper() == alunno.ToUpper()) { pos_alunno = i; break; }
            }

            if (pos_alunno == -1) Console.WriteLine("non trovato.");
            else
            {
                for (int i = 0; i < pagella.GetLength(0); i++)
                    if (pagella[pos_alunno, i] < 6)
                        Console.WriteLine($"{materie[i]}: {pagella[pos_alunno, i]}");
            }
        }
        #endregion
        static int[,] CreaPagella(string[] materie, string[] alunni)
        {
            int[,] pagella = new int[materie.Length, alunni.Length];

            for(int i = 0; i < materie.Length; i++)
            {
                for (int j = 0; j < alunni.Length; j++)
                    pagella[i, j] = getIntWithMinMax(0, 10, $"Inserisci il voto di {alunni[i]} in {materie[j]}: ");
            }

            return pagella;
        }

        
    }
}