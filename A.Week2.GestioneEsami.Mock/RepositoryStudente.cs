using A.Week2.GestioneEsami.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2.GestioneEsami.Mock
{

    public class RepositoryStudente : IRepositoryStudente
    {
        public static List<Studente> studenti = new List<Studente>();

        public List<Studente> Fetch()
        {
            return studenti;        }


        public void Aggiungi(Studente s)
        {
            if (studenti.Count() == 0)
            {
                s.Id = 1;
            }
            else
            {
                s.Id = studenti.Max(i => i.Id) + 1;
            }
            studenti.Add(s);
        }

        public void Insert(Studente Item)
        {
            throw new NotImplementedException();
        }
    }
}