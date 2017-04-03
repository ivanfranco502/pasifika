using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Model;

namespace Pasifika.WebUI.Areas.Admin.ViewModels
{
    public class DestinoListViewModel
    {
        public List<Destino> Destinos { get; set; }
        public Region Region { get; set; }
    }
}