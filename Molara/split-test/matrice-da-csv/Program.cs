namespace matrice_da_csv
{
    internal class Program
    {
        static int[,] getmatrix(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                int righe = int.Parse(sr.ReadLine());
                int colonne = int.Parse(sr.ReadLine());

                int[,] matrix = new int[righe, colonne];

                for(int i = 0; !sr.EndOfStream && i < righe; i++)
                {
                    string[] parti = sr.ReadLine().Split('|');
                    for(int j = 0; j < parti.Length; j++)
                    {
                        matrix[i,j] = int.Parse(parti[j]);
                    }
                }
                sr.Close();
                return matrix;
            }
        }

        static void Main(string[] args)
        {
            string path = @"..\..\..\matrice.txt";
            int[,] matrix = getmatrix(path);
            foreach(int i in matrix) Console.WriteLine(i);
        }
    }
}