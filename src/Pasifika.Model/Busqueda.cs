using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class Busqueda
    {
        public int Indice { get; set; }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public short Tipo { get; set; }
        public decimal MatchPct { get; set; }
        public int TotalROWS { get; set; }
        public Viaje Viaje { get; set; }
        public Nota Nota { get; set; }
        public Destino Destino { get; set; }

    }
}
