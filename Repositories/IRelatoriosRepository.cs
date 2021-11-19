using System.Collections.Generic;
using sag.Models;

namespace sag.Repositories
{
    public interface IRelatoriosRepository
    {
        List<ProdutosMaisVendidos> ReadAll();
        ProdutosMaisVendidos Read();
    }
}