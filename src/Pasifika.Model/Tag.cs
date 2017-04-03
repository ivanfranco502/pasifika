using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Url { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
        public string Texto { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<ViajeTag> ViajesTag { get; set; }
    }
}
