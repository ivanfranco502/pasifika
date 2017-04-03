using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class FormularioSesion
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Nombre { get; set; }
        public int Orden { get; set; }

        [NotMapped]
        public string Operacion { get; set; }
    }
}
