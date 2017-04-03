using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Model;

namespace Pasifika.WebUI.ViewModels
{
    public class Tipo1ListadoViewModel
    {
        public List<Viaje> Viajes { get; set; }
        public Tag Tag { get; set; }

        public BannerContextual BannerContextual { get; set; }
        public object ViajesJson { get; set; }
    }
}