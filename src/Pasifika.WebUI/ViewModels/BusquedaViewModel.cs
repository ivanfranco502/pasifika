using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Model;

namespace Pasifika.WebUI.ViewModels
{
    public class BusquedaViewModel
    {
        public List<Busqueda> Busquedas { get; set; }
        public int Pagina { get; set; }
        public string Texto { get; set; }

        public int CantidadPagina { get; set; }
    
    }
}