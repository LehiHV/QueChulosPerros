﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueChulosPerros.Shared.Model
{
    public class Cita
    {
        public int Id { get; set; }
        public string? Subject { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [ForeignKey("Cliente"), Required(ErrorMessage = "La identificación del cliente es obligatoria")]
        public int? ClientId { get; set; }
        public Cliente? Client { get; set; }
        [ForeignKey("Mascota"), Required(ErrorMessage = "La identificación del cliente es obligatoria")]
        public int? PetId { get; set; }
        public Mascota? Pet { get; set; }
    }
}
