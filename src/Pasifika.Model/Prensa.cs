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
    public class Prensa
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Titulo { get; set; }
        [MaxLength(100)]
        public string Revista { get; set; }
        public DateTime Fecha { get; set; }
        public string Resumen { get; set; }
        [MaxLength(300)]
        public string Foto { get; set; }
        [MaxLength(100)]
        public string Alt { get; set; }
        [MaxLength(300)]
        public string PDF { get; set; }
        [MaxLength(300)]
        public string Link { get; set; }
        public bool Eliminado { get; set; }

        [NotMapped]
        public Stream StreamFoto { get; set; }
        [NotMapped]
        public Stream StreamPDF { get; set; }
    }
}
