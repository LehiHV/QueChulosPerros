using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueChulosPerros.Shared.Model
{
    public enum PetGender
    {
        Hembra,
        Macho,
        NoEspecificado
    }
    public enum Specie
    {
        Perro,
        Gato,
        Ave,
        Roedor
    }
    public class Mascota
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required(ErrorMessage = "El número de teléfono es obligatorio"), MaxLength(100), Phone]
        public string? Phone { get; set; }
        [Required]
        public bool? Alive { get; set; }
        [Required(ErrorMessage = "El género es obligatorio"), EnumDataType(typeof(PetGender))]
        public PetGender? Gender { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio"), EmailAddress]
        public string? Email { get; set; }
        [Required]
        public Specie? Specie { get; set; }
        [Required]
        public string? Breed { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria"), MaxLength(255), Description, DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        [ForeignKey("Cliente"), Required(ErrorMessage = "La identificación del cliente es obligatoria")]
        public int? ClientId { get; set; }
        public Cliente? Client { get; set; }
    }
}
