using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Model;

namespace Pasifika.WebUI.Areas.Admin.ViewModels
{
    public class ViajeTipo1EditViewModel
    {
        public Object Viaje { get; set; }
        public List<Tag> Tags { get; set; }
        public int TipoViaje { get; set; }
        public int SubTipoViaje { get; set; }
        public List<Destino> Destinos { get; set; }
    }
}