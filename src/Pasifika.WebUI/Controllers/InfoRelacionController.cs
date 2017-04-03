using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Pasifika.Business.Abstract;

namespace Pasifika.WebUI.Controllers
{
    public class InfoRelacionController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public InfoRelacionController(IPaginaBusiness p)
        {
            this._pagina = p;
        }

        [ChildActionOnly]
        public PartialViewResult Cargar(int? seccionId, int? viajeId, int? notaId, int? destinoId, int? tagId, int? regionId)
        {
            var p = _pagina.Get(seccionId, viajeId, notaId, destinoId, tagId, regionId);

            InfoRelacion i = new InfoRelacion();

            if (p != null)
                if (p.InfoRelaciones.Count > 0)
                {
                    i = p.InfoRelaciones.ToList()[0];
                    return PartialView(i);
                }

            return PartialView(null);
        }
    }
}