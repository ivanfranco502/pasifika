using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class PaginaTexto
    {
        [Key]
        public int Id { get; set; }
        public string Texto { get; set; }

        public int PaginaId { get; set; }
        public virtual Pagina Pagina { get; set; }
    }
}
