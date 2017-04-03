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
    public class InfoRelacion
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Titulo1 { get; set; }
        [MaxLength(300)]
        public string Foto1 { get; set; }
        [MaxLength(100)]
        public string Alt1 { get; set; }
        [MaxLength(100)]
        public string SubTitulo1 { get; set; }
        public string Texto1 { get; set; }
        [MaxLength(300)]
        public string Link1 { get; set; }
        [NotMapped]
        public Stream Stream1 { get; set; }
        
        [MaxLength(100)]
        public string Titulo2 { get; set; }
        [MaxLength(300)]
        public string Foto2 { get; set; }
        [MaxLength(100)]
        public string Alt2 { get; set; }
        public string SubTitulo2 { get; set; }
        public string Texto2 { get; set; }
        [MaxLength(300)]
        public string Link2 { get; set; }
        [NotMapped]
        public Stream Stream2 { get; set; }

        [MaxLength(100)]
        public string Titulo3 { get; set; }
        [MaxLength(300)]
        public string Foto3 { get; set; }
        [MaxLength(100)]
        public string Alt3 { get; set; }
        public string SubTitulo3 { get; set; }
        public string Texto3 { get; set; }
        [MaxLength(300)]
        public string Link3 { get; set; }
        [NotMapped]
        public Stream Stream3 { get; set; }

        [MaxLength(100)]
        public string Titulo4 { get; set; }
        [MaxLength(300)]
        public string Foto4 { get; set; }
        [MaxLength(100)]
        public string Alt4 { get; set; }
        public string SubTitulo4 { get; set; }
        public string Texto4 { get; set; }
        [MaxLength(300)]
        public string Link4 { get; set; }
        [NotMapped]
        public Stream Stream4 { get; set; }

        public int PaginaId { get; set; }
        public virtual Pagina Pagina { get; set; }
    }
}
