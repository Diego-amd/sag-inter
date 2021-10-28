using System.Collections.Generic;
using sag.Models;
using sag.Repositores;

namespace sag.Repositories
{
    public class GastosBrutosDatabaseRepository : BDContext, IGastosBrutosRepository
    {
        //TODO: Fazer a parte do banco dos gastos brutos
        public void Create(GastosBrutos model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<GastosBrutos> Read()
        {
            throw new System.NotImplementedException();
        }

        public GastosBrutos Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, GastosBrutos model)
        {
            throw new System.NotImplementedException();
        }
    }
}