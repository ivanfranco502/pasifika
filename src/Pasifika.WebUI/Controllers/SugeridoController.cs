using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Pasifika.Business.Abstract;

namespace Pasifika.WebUI.Controllers
{
    public class SugeridoController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public SugeridoController(IPaginaBusiness p)
        {
            this._pagina = p;
        }

        [ChildActionOnly]
        public PartialViewResult Cargar(int? seccionId, int? viajeId, int? notaId, int? destinoId, int? tagId, int? regionId)
        {
            var p = _pagina.Get(seccionId, viajeId, notaId, destinoId, tagId, regionId);

            List<SugerenciaPagina> s = new List<SugerenciaPagina>();

            if (p != null)
                s = p.SugerenciasPagina.ToList();

            return PartialView(s);
        }
    }
}