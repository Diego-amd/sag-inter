using sag.Models;

namespace sag.Repositories
{
    public interface IUsuarioRepository
    {
        Usuarios Read(string email, string senha);
    }
}