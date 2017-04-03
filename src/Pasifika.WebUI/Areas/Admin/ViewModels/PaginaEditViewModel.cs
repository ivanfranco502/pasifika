using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Model;

namespace Pasifika.WebUI.Areas.Admin.ViewModels
{
    public class PaginaEditViewModel
    {
        public Pagina Pagina { get; set; }
        public List<Seccion> Secciones { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Destino> Destinos { get; set; }
        public List<Viaje> Viajes { get; set; }
        public List<Region> Regiones { get; set; }
    }
}