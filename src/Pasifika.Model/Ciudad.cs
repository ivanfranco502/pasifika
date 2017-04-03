using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pasifika.Model
{
    public class Ciudad
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Url { get; set; }
        public bool Eliminado { get; set; }

        public int DestinoId { get; set; }

        public virtual Destino Destino { get; set; }
        public virtual ICollection<ViajeTipo2> Viajes { get; set; }
    }
}
