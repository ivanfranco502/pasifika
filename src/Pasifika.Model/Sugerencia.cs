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
    public class Sugerencia
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
        public bool Eliminado { get; set; }

        [NotMapped]
        public Stream Stream { get; set; }

        public virtual ICollection<SugerenciaPagina> PaginasSugerenia { get; set; }
    }
}
