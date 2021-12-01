using System.Collections.Generic;
using sag.Models;

namespace sag.Repositories
{
    public interface IPedidosRepository
    {
        int Create(int id, Pedidos model);
        List<Pedidos> ReadAll();
        Pedidos Read(int id);
        void Update(int id, Pedidos model);
    }
}