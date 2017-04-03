using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class Viaje
    {
        public Viaje()
        {
            Fotos = new HashSet<Foto>();
            TagsViaje = new HashSet<ViajeTag>();
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        [MaxLength(200)]
        public string InfoPrecio { get; set; }
        [MaxLength(100)]
        public string Referencia { get; set; }
        [MaxLength(300)]
        public string PDF { get; set; }
        [MaxLength(300)]
        public string ImagenListado { get; set; }
        [MaxLength(100)]
        public string AltImagenListado { get; set; }
        public int Orden { get; set; }
        public bool Eliminado { get; set; }
        [MaxLength(100)]
        public string TituloCuadro { get; set; }
        [MaxLength(300)]
        public string TextoCuadro { get; set; }

        public virtual ICollection<Foto> Fotos { get; set; }
        public virtual ICollection<ViajeTag> TagsViaje { get; set; }
    }
}
