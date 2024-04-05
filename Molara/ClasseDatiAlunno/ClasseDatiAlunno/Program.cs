using System.Diagnostics.CodeAnalysis;

namespace ClasseDatiAlunno
{
    class Alunno
    {
        private string nome, cognome;
        private int anno_di_nascita, numero_materie;
        private List<List<int>> voti; //dove voti[materia] = lista dei voti in quella materia
  
        public enum materie
        {
            Italiano,
            Matematica,
            Informatica,
            Inglese
        }

        public Alunno()
        {
            this.voti = new List<List<int>>();

            for(int i = 0; i < numero_materie; i++)
                this.voti.Add(new List<int>());
        }

        public void Aggiungi_Voto(materie materia, int voto)
        {
            voti[(int)materia].Add(voto);
        }

        public double media(materie materia)
        {
            int sum = 0;

            foreach (int i in voti[(int)materia])
                sum += i;

            return sum / voti[(int)materia].Count;
        }

        public List<int> voti_materia(materie materia)
        {
            return voti[(int)materia];
        }

        public List<List<int>> tutti_voti() 
        {
            return voti;
        }
    }
}