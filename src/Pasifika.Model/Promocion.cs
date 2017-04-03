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
    public class Promocion
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Titulo { get; set; }
        [MaxLength(300)]
        public string Foto { get; set; }
        [MaxLength(100)]
        public string Alt { get; set; }
        [MaxLength(100)]
        public string SubTitulo { get; set; }
        [MaxLength(300)]
        public string Link { get; set; }
        [MaxLength(100)]
        public string Promo { get; set; }
        public bool Eliminado { get; set; }

        [NotMapped]
        public Stream Stream { get; set; }
    }
}
