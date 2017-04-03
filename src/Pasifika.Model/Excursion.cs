using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class Excursion : ViajeTipo2
    {
        [MaxLength(500)]
        public string Horarios { get; set; }
    }
}
