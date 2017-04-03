using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Model;

namespace Pasifika.WebUI.Areas.Admin.ViewModels
{
    public class ViajeTipo1ListViewModel
    {
        public List<Viaje> Viajes { get; set; }
        public int TipoViaje { get; set; }
        public int SubTipoViaje { get; set; }
    }
}