using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Pasifika.Business.Abstract;

namespace Pasifika.WebUI.Controllers
{
    public class DestacadoController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public DestacadoController(IPaginaBusiness p)
        {
            this._pagina = p;
        }

        [ChildActionOnly]
        public PartialViewResult Cargar(int? seccionId, int? viajeId, int? notaId, int? destinoId, int? tagId, int? regionId)
        {
            var p = _pagina.Get(seccionId, viajeId, notaId, destinoId, tagId, regionId);

            List<Destacado> d = new List<Destacado>();

            if (p != null)
                d = p.Destacados.ToList();

            return PartialView(d);
        }
    }
}