using sag.Models;
using sag.Repositores;

namespace sag.Repositories
{
    public class UsuarioDatabaseRepository : BDContext, IUsuarioRepository
    {
        public void Read()
        {
            
        }
        public Usuarios Read(string email, string senha)
        {
            throw new System.NotImplementedException();
        }
    }
}