using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Pasifika.Business.Abstract;

namespace Pasifika.WebUI.Controllers
{
    public class TextoController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public TextoController(IPaginaBusiness p)
        {
            this._pagina = p;
        }

        [ChildActionOnly]
        public PartialViewResult Cargar(int? seccionId, int? viajeId, int? notaId, int? destinoId, int? tagId, int? regionId)
        {
            var p = _pagina.Get(seccionId, viajeId, notaId, destinoId, tagId, regionId);

            string texto = "";

            if (p != null)
            {
                var t = p.PaginaTextos.FirstOrDefault();
                if (t != null)
                    texto = t.Texto;
            }

            
            return PartialView(model: texto);
        }
    }
}