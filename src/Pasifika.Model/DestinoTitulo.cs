using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class DestinoTitulo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int Orden { get; set; }

        public int DestinoId { get; set; }
        public virtual Destino Destino { get; set; }
    }
}
