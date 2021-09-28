using A.Week2.GestioneEsami.Core.Entities;

namespace A.Week2.GestioneEsami.Core.RepositoryInterfaces
{
    public interface IRepositoryCorsiDiLaurea : IRepository<CorsoDiLaurea>
    {
        void Insert();
        void Add(Esame esameDaSostenere);
    }
} 