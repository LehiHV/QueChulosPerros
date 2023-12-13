using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueChulosPerros.Shared.Model
{
    public class Cita
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La fecha y hora de la cita son obligatorias"), DataType(DataType.DateTime)]
        public DateTime? Appointment { get; set; }
        [ForeignKey("Cliente"), Required(ErrorMessage = "La identificación del cliente es obligatoria")]
        public int? IdClient { get; set; }
        public Cliente? Client { get; set; }
        [ForeignKey("Mascota"), Required(ErrorMessage = "La identificación del cliente es obligatoria")]
        public int? IdPet { get; set; }
        public Mascota? Pet { get; set; }
    }
}
