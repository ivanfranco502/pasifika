using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class Foto
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(300)]
        public string Archivo { get; set; }
        [MaxLength(100)]
        public string Alt { get; set; }
        public int Orden { get; set; }

        public int ViajeId { get; set; }
        public virtual Viaje Viaje { get; set; }

        [NotMapped]
        public string Operacion { get; set; }
        [NotMapped]
        public Stream Stream { get; set; }
    }
}
