using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseDatiAlunno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Alunno alunno = new Alunno("De Rosa", "Antonio", 2006);

            alunno.Aggiungi_Voto(Alunno.Materie.Italiano, 2);
            alunno.Aggiungi_Voto(Alunno.Materie.Italiano, 8);
            alunno.Aggiungi_Voto(Alunno.Materie.Italiano, 7);
            alunno.Aggiungi_Voto(Alunno.Materie.Italiano, 10);
            alunno.Aggiungi_Voto(Alunno.Materie.Matematica, 10);
            alunno.Aggiungi_Voto(Alunno.Materie.Matematica, 4);
            alunno.Aggiungi_Voto(Alunno.Materie.Matematica, 6);

            Console.WriteLine($"Italiano: {alunno.media_Materia(Alunno.Materie.Italiano)}, Matematica: {alunno.media_Materia(Alunno.Materie.Matematica)}");
        }
    }
}
