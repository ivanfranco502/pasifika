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
    public class Destacado
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
        [MaxLength(100)]
        public string SubTitulo2 { get; set; }
        [MaxLength(300)]
        public string Link { get; set; }
        public int Orden { get; set; }

        [NotMapped]
        public string Operacion { get; set; }
        [NotMapped]
        public Stream Stream { get; set; }

        public int PaginaId { get; set; }
        public virtual Pagina Pagina { get; set; }
    }
}
