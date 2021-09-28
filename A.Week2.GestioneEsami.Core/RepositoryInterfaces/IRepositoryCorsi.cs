using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2.GestioneEsami.Core.RepositoryInterfaces
{
    public interface IRepositoryCorsi : IRepository<Corso>
    {
        List<Corso> GetCorsiByCorsoDiLaurea(CorsoDiLaurea cdl);
    }
}