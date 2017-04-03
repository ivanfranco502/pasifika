using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Pasifika.Business.Abstract;

namespace Pasifika.WebUI.Controllers
{
    public class BannerController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public BannerController(IPaginaBusiness p)
        {
            this._pagina = p;
        }

        [ChildActionOnly]
        //tipo: 1 -> grande; 2 -> chico
        public PartialViewResult Cargar(int? seccionId, int? viajeId, int? notaId, int? destinoId, int? tagId, int? regionId, int tipo)
        {
            var p = _pagina.Get(seccionId, viajeId, notaId, destinoId, tagId, regionId);

            List<Banner> b = new List<Banner>();

            if (p != null)
                b = p.Banners.ToList();

            if (tipo == 1)
                return PartialView("Cargar", b);
            else
                if (tipo == 2)
                    return PartialView("CargarChico", b);
                else
                    return PartialView("Cargar", b);
        }
    }
}