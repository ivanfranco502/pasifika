using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Model;

namespace Pasifika.WebUI.ViewModels
{
    public class Tipo2ListadoViewModel
    {
        public List<Viaje> Viajes { get; set; }
        public Destino Destino { get; set; }
        public object ViajesJson { get; set; }
    }
}