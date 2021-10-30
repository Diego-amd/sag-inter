using System.ComponentModel.DataAnnotations;

namespace sag.Models
{
    public class UsuariosLoginViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [MinLength(2)]
        public string Senha { get; set; }
    }
}
