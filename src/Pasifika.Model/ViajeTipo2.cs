using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class ViajeTipo2 : Viaje
    {
        public string InformacionGeneral { get; set; }
        public string Importante { get; set; }
        public string Condicion { get; set; }
        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }
    }
}
