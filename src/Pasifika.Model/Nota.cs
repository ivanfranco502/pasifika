using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Titulo { get; set; }
        [MaxLength(100)]
        public string SubTitulo { get; set; }
        [MaxLength(1000)]
        public string Resumen { get; set; }
        [MaxLength(300)]
        public string Url { get; set; }
        public DateTime Fecha { get; set; }
        public bool Visible { get; set; }
        public bool EnPrensa { get; set; }
        public bool Eliminado { get; set; }
    }
}
