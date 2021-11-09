using System.Collections.Generic;
using sag.Models;

namespace sag.Repositories
{
    public interface IProdutosRepository
    {
        void Create(int id, Produtos model);
        List<Produtos> ReadAll();
        Produtos Read(int id);
        void Update(int id, Produtos model);
        void Disable(int id);
    }
}