using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Model;

namespace Pasifika.WebUI.ViewModels
{
    public class FormularioIndexViewModel
    {
        public string Titulo { get; set; }
        public string TituloModalGracias { get; set; }
        public int Tipo { get; set; }
        public List<FormularioSesion> Sesiones { get; set; }
        public bool Cartel { get; set; }
        public CRM.Model.Destinos Destinos { get; set; }
        public CRM.Model.TiposViajes TiposViajes { get; set; }
        public CRM.Model.Provincias Provincias { get; set; }
    }
}