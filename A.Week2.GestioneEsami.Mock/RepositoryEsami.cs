using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A.Week2.GestioneEsami.Core.Entities;
using A.Week2.GestioneEsami.Core.RepositoryInterfaces;

namespace A.Week2.GestioneEsami.Mock
{
    public class RepositoryEsami : IRepositoryEsami
    {
        private readonly Esame esamiCtx;

        public static List<Esame> esami = new List<Esame>()
        {
            new Esame("Filologia", true, 1010),
            new Esame("Linguistica", false, 1010),

        };

        public bool Add(Esame esameDaSostenere)
        {
            if (esameDaSostenere == null)

                try
                {
                    var esami = esamiCtx.Nome
                        .FirstOrDefault(e => e.Id == esameDaSostenere.IdStudente);
                }
                catch (Exception)
                {
                    return false;
                }

            return true;
        }

        public List<Esame> Fetch()
        {
            return esami;
        }

        public void Insert(Esame Item)
        {
            throw new NotImplementedException();
        }
    }
}

    
