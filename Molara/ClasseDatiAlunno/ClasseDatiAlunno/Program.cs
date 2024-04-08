using System.Diagnostics.CodeAnalysis;

namespace ClasseDatiAlunno
{
    class Alunno
    {
        private string nome, cognome;
        private int anno_di_nascita, numero_materie;
        private Dictionary<materie, List<int>> voti = new Dictionary<materie, List<int>>();
  
        public enum materie
        {
            Italiano,
            Matematica,
            Informatica,
            Inglese
        }

        public Alunno(string cognome, string nome, int anno_di_nascita)
        {
            this.anno_di_nascita = anno_di_nascita;
            this.nome = nome;
            this.cognome = cognome;
        }

        public void Aggiungi_Voto(materie materia, int voto)
        {
            if (voti.ContainsKey(materia)) voti[materia].Add(voto);
            else voti.Add(materia, new List<int> { voto });
        }

        public double media_Materia(materie materia)
        {
            if (voti.ContainsKey(materia)) return voti[materia].Average();
            else return 0;
        }

        public List<int> voti_materia(materie materia)
        {
            if (!voti.ContainsKey(materia)) return new List<int>();
            else return voti[materia];
        }

        public Dictionary<materie, List<int>> tutti_voti() 
        {
            return voti;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Alunno alunno = new Alunno("De Rosa", "Antonio", 2006);

            alunno.Aggiungi_Voto(Alunno.materie.Italiano, 2);
            alunno.Aggiungi_Voto(Alunno.materie.Italiano, 8);
            alunno.Aggiungi_Voto(Alunno.materie.Italiano, 7);
            alunno.Aggiungi_Voto(Alunno.materie.Italiano, 10);
            alunno.Aggiungi_Voto(Alunno.materie.Matematica, 10);
            alunno.Aggiungi_Voto(Alunno.materie.Matematica, 4);
            alunno.Aggiungi_Voto(Alunno.materie.Matematica, 6);

            Console.WriteLine($"Italiano: {alunno.media_Materia(Alunno.materie.Italiano)}, Matematica: {alunno.media_Materia(Alunno.materie.Matematica)}");
        }
    }
}