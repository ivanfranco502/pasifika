using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Business.Abstract;
using MvcSiteMapProvider;

namespace Pasifika.WebUI.Controllers
{
    public class PromocionesController : Controller
    {
        private readonly IPromocionBusiness _promociones;

        public PromocionesController(IPromocionBusiness p)
        {
            this._promociones = p;
        }

        [MvcSiteMapNodeAttribute(Title = "Promociones", ParentKey = "Home", Key = "Promociones")]
        public ActionResult Index()
        {
            var p = _promociones.Get();
            ViewBag.menusseleccionado = "Promociones";

            return View(new ViewModels.PromocionesIndexViewModel
            {
                Promociones = p
            });
        }
    }
}