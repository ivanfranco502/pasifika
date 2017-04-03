using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class ViajeTipo1 : Viaje
    {
        public int Duracion { get; set; }
        [MaxLength(200)]
        public string Paises { get; set; }
        [MaxLength(200)]
        public string Ciudades { get; set; }
        public string Itinerario { get; set; }
        public string Alojamiento { get; set; }
        public string Actividades { get; set; }
        public string Translados { get; set; }
        public string CuandoIr { get; set; }
        public string Presupuesto { get; set; }
        public string Comentarios { get; set; }

        public int DestinoId { get; set; }
        public virtual Destino Destino { get; set; }
    }
}
