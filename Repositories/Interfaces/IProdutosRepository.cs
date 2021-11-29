using System.Collections.Generic;
using sag.Models;

namespace sag.Repositories
{
    public interface IProdutosRepository
    {
        bool Create(int id, Produtos model);
        List<Produtos> ReadAll();
        Produtos Read(int id);
        bool Update(int id, Produtos model);
        bool Disable(int id);
    }
}