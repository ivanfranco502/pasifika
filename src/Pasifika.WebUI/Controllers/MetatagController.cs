using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Pasifika.Business.Abstract;

namespace Pasifika.WebUI.Controllers
{
    public class MetatagController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public MetatagController(IPaginaBusiness p)
        {
            this._pagina = p;
        }

        [ChildActionOnly]
        public PartialViewResult Cargar(int? seccionId, int? viajeId, int? notaId, int? destinoId, int? tagId, int? regionId)
        {
            var p = _pagina.Get(seccionId, viajeId, notaId, destinoId, tagId, regionId);

            if (p != null)
            {
                if (p.MetaTags.Count > 0)
                {
                    MetaTag mt = p.MetaTags.FirstOrDefault();
                    ViewBag.Title = mt.Title;
                    ViewBag.MetaDescription = mt.Description;
                    ViewBag.MetaKeywords = mt.Keywords;
                }
            }

            return PartialView();
        }
    }
}