using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Model;

namespace Pasifika.WebUI.ViewModels
{
    public class PrensaIndexViewModel
    {
        public List<Prensa> Prensas { get; set; }
        public List<Nota> Notas { get; set; }
    }
}