using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueChulosPerros.Shared.Model
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "El usuario debe ser válido")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "La contraseña debe ser válida")]
        public string? Password { get; set; }
        public Branch? Branch { get; set; }
    }
}
