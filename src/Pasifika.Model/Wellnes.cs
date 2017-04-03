using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class Wellnes : ViajeTipo1
    {
        [MaxLength(150)]
        public string NombreWellnes { get; set; }
    }
}
