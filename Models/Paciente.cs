using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Urgencias.Models
{
    public class Paciente
    {

        [Key]
        public int idPaciente { get; set; }
        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string? Apellido { get; set; }
        [Required]
        [StringLength(50)]

        public string? Genero { get; set; }

        
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [StringLength(50)]

        public string? Profesion { get; set; }

        public int Edad { get; set; }
        [Required]
        public Boolean Atendido { get; set; }

        //calculo de edad
        public void calculoEdad(DateTime FechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;
            this.Edad = fechaActual.Year - FechaNacimiento.Year;
            
        }
        
        
    }
}
