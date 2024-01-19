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

            for(int i = 0; i < Num_alunni; i++)
            {
                Console.WriteLine(alunni[i] + " ");
                for(int j = 0; j < Num_materie; j++)
                {
                    Console.Write(pagellaT1[i, j] + " ");
                }
            }

            for (int i = 0; i < Num_alunni; i++)
            {
                Console.WriteLine(alunni[i] + " ");
                for (int j = 0; j < Num_materie; j++)
                {
                    Console.WriteLine(pagellaT2[i, j] + " ");
                }
            }


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
                if (nomi[i] == alunno) { pos_alunno = i;  break; }
            }

            if(pos_alunno == -1) { Console.WriteLine(); return -1.1; }
            double media = 0.0;
            for(j = 0; j < pagella.GetLength(0); j++) media += pagella[pos_alunno,j];
            media /= j;

            return media;
        }

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

        static double MediaMateria(int[,] pagella, string[] materie, string materia)
        {
            int materia_pos = -1;
            for (int i = 0; i < materie.Length; i++) if (materie[i].ToUpper() == materia.ToUpper()) materia_pos = i;

            if (materia_pos == -1) { Console.WriteLine(materia + " non esiste, riprova."); return -1.1; }
            else //materia esiste
            {
                double media = 0.0;
                for (int i = 0; i < pagella.GetLength(1); i++) media += pagella[i, materia_pos];
                media /= pagella.GetLength(1);
                return media;
            }
        }

        static int[,] CreaPagella(string[] materie, string[] alunni)
        {
            int[,] pagella = new int[materie.Length, alunni.Length];

            for(int i = 0; i < materie.Length; i++)
            {
                for (int j = 0; j < alunni.Length; j++)
                    pagella[i, j] = getIntWithMinMax(0, 10, $"Inserisci il voto di {alunni[i]} in {materie[j]}");
            }

            return pagella;
        }
    }
}