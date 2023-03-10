using System.ComponentModel.DataAnnotations;

namespace Control_Ingreso_Gasto.Models
{
    public class Estudiantes
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        public string Direccion { get; set; }

        public string Departamento { get; set; }



    }
}


