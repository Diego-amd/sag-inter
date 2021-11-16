using System.Collections.Generic;
using sag.Models;

namespace sag.Repositories
{
    public interface IRelatoriosRepository
    {
        void VendasDoDia();
        List<ProdutosMaisVendidos> ReadAll();
    }
}