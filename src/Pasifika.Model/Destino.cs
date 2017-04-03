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
    public class Destino
    {
        public Destino()
        {
            DestinoTitulos = new HashSet<DestinoTitulo>();
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Url { get; set; }
        [MaxLength(300)]
        public string FotoGuia { get; set; }
        public string FotoHotel { get; set; }
        public string FotoExcursion { get; set; }
        public string PDFGuia { get; set; }
        public int Orden { get; set; }
        [MaxLength(100)]
        public string Alt { get; set; }
        public string Datos { get; set; }
        public string Resumen { get; set; }
        public bool Eliminado { get; set; }

        [NotMapped]
        public Stream StreamGuia { get; set; }
        [NotMapped]
        public Stream StreamHotel { get; set; }
        [NotMapped]
        public Stream StreamExcursion { get; set; }
        [NotMapped]
        public Stream StreamPDFGuia { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Ciudad> Ciudades { get; set; }
        public virtual ICollection<DestinoTitulo> DestinoTitulos { get; set; }
    }
}
