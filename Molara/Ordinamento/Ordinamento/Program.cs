namespace Ordinamento
{
    internal class Program
    {
        enum Ordinamento
        {
            Crescente = -1,
            Decrescente = 1,
            Nessuno = 0
        }
        static Ordinamento crescita(int[] array)
        {
            bool Dec = false;
            bool Cre = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1]) Dec = true;
                else Cre = true;
            }

            if (Cre && Dec || !(Cre || Dec)) return Ordinamento.Nessuno;
            else if (Cre) return Ordinamento.Crescente;
            else return Ordinamento.Decrescente;
        }
    }
}