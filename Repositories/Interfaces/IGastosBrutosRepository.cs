using System.Collections.Generic;
using sag.Models;

namespace sag.Repositories
{
    public interface IGastosBrutosRepository
    {
        bool Create(int id, GastosBrutos model);
        List<GastosBrutos> ReadAll();
        GastosBrutos Read(int id);
        bool Update(int id, GastosBrutos model);
        bool Delete(int id);
    }
}