using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class SugerenciaPagina
    {
        [Key, Column(Order = 0)]
        public int PaginaId { get; set; }
        [Key, Column(Order = 1)]
        public int SugerenciaId { get; set; }
        public int Orden { get; set; }

        public virtual Pagina Pagina { get; set; }
        public virtual Sugerencia Sugerencia { get; set; }


    }
}
