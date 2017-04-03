using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Model;

namespace Pasifika.WebUI.Areas.Admin.ViewModels
{
    public class SugerenciaPaginaEditViewModel
    {
        public Pagina Pagina { get; set; }
        public List<Sugerencia> Sugerencias { get; set; }
    }
}