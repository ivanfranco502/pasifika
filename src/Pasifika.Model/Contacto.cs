using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; }
        [MaxLength(150)]
        public string Apellido { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        public DateTime Fecha { get; set; }
        [MaxLength(250)]
        public string Conocio { get; set; }
        public bool Europa { get; set; }
        [MaxLength(150)]
        public string Pais { get; set; }
        [MaxLength(150)]
        public string Provincia { get; set; }
        [MaxLength(1)]
        public string Sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [MaxLength(50)]
        public string Telefono { get; set; }
        [MaxLength(50)]
        public string HoraContacto { get; set; }
        [MaxLength(300)]
        public string Sesion { get; set; }
        [MaxLength(2000)]
        public string Mensaje { get; set; }
        public bool Newsletter { get; set; }
        [MaxLength(50)]
        public string Tipo { get; set; }
        [MaxLength(300)]
        public string Url { get; set; }
    }
}
