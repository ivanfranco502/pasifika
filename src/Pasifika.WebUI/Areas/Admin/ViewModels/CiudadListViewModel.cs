using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Model;

namespace Pasifika.WebUI.Areas.Admin.ViewModels
{
    public class CiudadListViewModel
    {
        public List<Ciudad> Ciudades { get; set; }
        public Destino Destino { get; set; }
    }
}