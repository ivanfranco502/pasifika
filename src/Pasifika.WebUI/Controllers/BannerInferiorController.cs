using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Pasifika.Business.Abstract;

namespace Pasifika.WebUI.Controllers
{
    public class BannerInferiorController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public BannerInferiorController(IPaginaBusiness p)
        {
            this._pagina = p;
        }

        [ChildActionOnly]
        public ActionResult Cargar(int? seccionId, int? viajeId, int? notaId, int? destinoId, int? tagId, int? regionId)
        {
            var p = _pagina.Get(seccionId, viajeId, notaId, destinoId, tagId, regionId);

            List<BannerInferior> b = new List<BannerInferior>();

            if (p != null)
                b = p.BannersInferiores.ToList();

            return PartialView("Cargar", b);
        }
    }
}