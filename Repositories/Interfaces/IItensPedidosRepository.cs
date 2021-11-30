using System.Collections.Generic;
using sag.Models;

namespace sag.Repositories
{
    public interface IItensPedidosRepository
    {
        List<ItensPedidos> Read(int id);
    }
}