namespace EserciziNatale23
{
    internal class Program
    {
        static int Sottostringa(string principale, string sottostringa)
        {
            int indice = 0;
            bool found = false;

            for (int i = 0; i < principale.Length - sottostringa.Length && found == false; i++)
            {
                found = true;
                indice = i;
                for(int j = 0; j < sottostringa.Length && found == true; j++)
                {
                    if (principale[i + j] != sottostringa[j]) found = false; 
                }
            }

            if (found) return indice;
            else return -1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Sottostringa("Supercalifragilistichespiralidoso", "fragili"));
        }
    }
}