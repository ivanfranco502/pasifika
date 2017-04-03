using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Business.Abstract;
using Pasifika.Model;

namespace Pasifika.WebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IRegionBusiness _region;

        public MenuController(IRegionBusiness r)
        {
            this._region = r;
        }

        [ChildActionOnly]
        public PartialViewResult IzquierdaDestinos(string url)
        {

            var r = _region.Get();

            ViewBag.menusseleccionado = url;

            return PartialView(new ViewModels.MenuIzquierdaDestinosViewModel
            {
                Regiones = r
            });
        }
    }
}