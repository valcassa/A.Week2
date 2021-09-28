using A.Week2.GestioneEsami.Core;
using A.Week2.GestioneEsami.Core.RepositoryInterfaces;

namespace A.Week2.GestioneEsami.Mock
{
    public interface IRepositoryImmatricolazione : IRepository<Immatricolazione>
    {
        Immatricolazione GetByDate(Immatricolazione imm);
    }
}
