using System;
using System.Collections.Generic;
using sag.Models;

namespace sag.Repositories
{
    public interface IGastosBrutosRepository
    {
        void Create(GastosBrutos model);
        List<GastosBrutos> ReadAll();
        GastosBrutos Read(int id);
        void Update(int id, GastosBrutos model);
        void Delete(int id);
    }
}