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
    public class Region
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [MaxLength(100)]
        public string Url { get; set; }
        [MaxLength(300)]
        public string Foto { get; set; }
        public int Orden { get; set; }
        public bool Eliminado { get; set; }

        [NotMapped]
        public Stream Stream { get; set; }

        public virtual ICollection<Destino> Destinos { get; set; }
    }
}
