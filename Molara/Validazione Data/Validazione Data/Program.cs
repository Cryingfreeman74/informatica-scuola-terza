namespace Validazione_Data
{
    internal class Program
    {
        static bool IsBisestile(int anno)
        {
            if (anno % 4 == 0)
            {
                if (anno % 100 == 0)
                {
                    if (anno % 1000 == 0) return true;
                    else return false;
                }

                return true;

            }
            else return false;

        }
        static bool ControllaData(int giorno, int mese, int anno)
        {

            if (anno < 0) return false;

            if (mese < 0 || mese > 12) return false;

            switch (mese)
            {
                case 11 or 9 or 6 or 4:

                    if (giorno < 0 || giorno > 30) return false;

                    break;

                case 2:

                    if (IsBisestile(anno))
                    {
                        if (giorno < 0 || giorno > 29) return false;
                    }
                    else if (giorno < 0 || giorno > 28) return false;

                    break;

                default:

                    if (giorno < 0 || giorno > 31) return false;

                    break;
            }

            return true;
        }

        static int readInt(string messaggio)
        {
            int valore;

            while (true)
            {
                Console.Write(messaggio);

                if (int.TryParse(Console.ReadLine(), out valore)) return valore;
                else Console.WriteLine("Valore inserito non valido, riprova\n");
            }
        }

        static void letturaData(out int anno, out int mese, out int giorno)
        {
            anno = readInt("Inserisci l'anno: ");
            mese = readInt("Inserisci il mese: ");
            giorno = readInt("Inserisci il giorno: ");
        }

        static void Main(string[] args)
        {
            int anno, mese, giorno;

            letturaData(out anno, out mese, out giorno);

            if (ControllaData(giorno, mese, anno)) Console.WriteLine("La data è valida.");
            else Console.WriteLine("La data non è valida.");

            Console.WriteLine("premi un tasto per terminare il programma");
            Console.ReadKey();
        }
    }
}