using System.ComponentModel.DataAnnotations;

namespace sag.Models
{
    public class UsuariosLoginViewModel
    {
        [Required(ErrorMessage = "O campo Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
