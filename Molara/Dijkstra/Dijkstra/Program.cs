namespace Dijkstra
{
    internal class Program
    {
        static int[,] matrice;
        static HashSet<int> v;
        static int[] p;
        static int[] d;
        
        static void LeggiFile()
        {    
            using (StreamReader sr = new StreamReader(@"..\..\..\grafi\grafo-100.txt"))
            {
                int N = int.Parse(sr.ReadLine());
                matrice = new int[N,N];
                v = new HashSet<int>(N);
                p = new int[N];
                d = new int[N];

                while (!sr.EndOfStream) 
                {
                    string[] linea = sr.ReadLine().Split(',');
                    matrice[int.Parse(linea[0]), int.Parse(linea[1])] = int.Parse(linea[2]);
                    matrice[int.Parse(linea[1]), int.Parse(linea[0])] = int.Parse(linea[2]);

                }
                sr.Close();
            }
        }

        static int findMin()
        {
            int min = int.MaxValue;
            for(int i = 0; i < d.Length; i++)
            {
                if (d[i] < min && !v.Contains(d[i])) min = d[i];
            }
            return min;
        }

        static int dijkstra(int source, int target)
        {
            for (int i = 0; i < p.Length; i++) p[i] = -1;
            for (int i = 0; i < d.Length; i++) d[i] = int.MaxValue;

            d[source] = 0;

            while (true)
            {
                int min = findMin();
            }

        }
        static void Main(string[] args)
        {
            LeggiFile();
            for(int ir = 0; ir < matrice.GetLength(0); ir++)
            {
                for(int ic = 0; ic < matrice.GetLength(1); ic++)
                    Console.Write(matrice[ir, ic] + " ");
                Console.WriteLine();
            }
        }
    }
}