using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Model;

namespace Pasifika.WebUI.ViewModels
{
    public class NotasIndexViewModel
    {
        public List<Nota> Notas { get; set; }
        public List<Nota> NotasDirectorio { get; set; }
        public int Pagina { get; set; }
        public int CantidadPagina { get; set; }
        public string linkSiguiente { get; set; }
        public string linkAnterior { get; set; }
    }
}