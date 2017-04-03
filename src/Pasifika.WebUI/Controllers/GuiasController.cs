using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Business.Abstract;
using MvcSiteMapProvider;

namespace Pasifika.WebUI.Controllers
{
    public class GuiasController : Controller
    {
        private readonly IRegionBusiness _region;
        private readonly IDestinoBusiness _destino;

        public GuiasController(IRegionBusiness r, IDestinoBusiness d)
        {
            this._region = r;
            this._destino = d;
        }

        [MvcSiteMapNodeAttribute(Title = "Guías de viaje", ParentKey = "Home", Key = "Guias")]
        public ActionResult Index()
        {
            var r = _region.Get();
            ViewBag.menusseleccionado = "Guias";
            return View(new ViewModels.GuiasIndexViewModel
            {
                Regiones = r
            });
        }

        [MvcSiteMapNodeAttribute(ParentKey = "Guias", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.GuiaDetailsDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult Detalle(string destino)
        {
            var d = _destino.GetByUrl(destino);

            ViewBag.menusseleccionado = "Guias";

            return View(new ViewModels.GuiasDetalleViewModel
            {
                Destino = d
            });
        }
    }
}