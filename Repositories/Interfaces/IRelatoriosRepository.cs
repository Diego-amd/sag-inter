using System.Collections.Generic;
using sag.Models;

namespace sag.Repositories
{
    public interface IRelatoriosRepository
    {
        List<ProdutosMaisVendidos> ReadAll();
        decimal Read();
        List<Dashboard> Dashboard();
        List<Dashboard> MediaReceitaMes();
        List<Dashboard> MediaPedidoDia();
    }
}