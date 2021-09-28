using A.Week2.GestioneEsami.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2.GestioneEsami.Core.RepositoryInterfaces
{
    public interface IRepositoryEsami : IRepository<Esame>
    {
        new bool Add(Esame esameDaSostenere);
    }
}
