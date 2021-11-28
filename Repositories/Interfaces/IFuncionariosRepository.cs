using System.Collections.Generic;
using sag.Models;

namespace sag.Repositories
{
    public interface IFuncionariosRepository
    {
        Funcionarios Read(int id);
    }
}