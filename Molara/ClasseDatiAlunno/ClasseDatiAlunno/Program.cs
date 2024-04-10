using System.Diagnostics.CodeAnalysis;

namespace ClasseDatiAlunno
{
    class Alunno
    {
        private string nome, cognome;
        private int anno_di_nascita, numero_materie;
        private Dictionary<Materie, List<int>> voti = new Dictionary<Materie, List<int>>();
  
        public enum Materie
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

        public void Aggiungi_Voto(Materie materia, int voto)
        {
            if (voti.ContainsKey(materia)) voti[materia].Add(voto);
            else voti.Add(materia, new List<int> { voto });
        }

        public double media_Materia(Materie materia)
        {
            if (voti.ContainsKey(materia)) return voti[materia].Average();
            else return 0;
        }

        public List<int> voti_materia(Materie materia)
        {
            if (!voti.ContainsKey(materia)) return new List<int>();
            else return voti[materia];
        }

        public Dictionary<Materie, List<int>> tutti_voti() 
        {
            return voti;
        }
    }

}