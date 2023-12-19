using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QueChulosPerros.Shared.Model
{


    public class Cliente
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required(ErrorMessage = "El número de teléfono es obligatorio"), MaxLength(100), Phone]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "El género es obligatorio"), EnumDataType(typeof(Gender))]
        public Gender? Gender { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio"), EmailAddress]
        public string? Email { get; set; }
        [Required]
        public Branch? Branch { get; set; }
    }
}
