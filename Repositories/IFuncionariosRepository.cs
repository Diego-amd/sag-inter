using System.Collections.Generic;
using sag.Models;

namespace sag.Repositories
{
    public interface IFuncionariosRepository
    {
        List<Funcionarios> ReadAll();
    }
}