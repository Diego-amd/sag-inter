using System.ComponentModel.DataAnnotations;

namespace sag.Models
{
    public class UsuariosLoginViewModel
    {
        [Required(ErrorMessage = "O campo Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [MinLength(2, ErrorMessage = "O campo Senha deve ter pelo menos 2 caracteres")]
        public string Senha { get; set; }
    }
}
