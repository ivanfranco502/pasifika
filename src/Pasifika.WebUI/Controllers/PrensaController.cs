using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Business.Abstract;
using MvcSiteMapProvider;

namespace Pasifika.WebUI.Controllers
{
    public class PrensaController : Controller
    {
        private readonly IPrensaBusiness _prensa;
        private readonly INotaBusiness _nota;

        public PrensaController(IPrensaBusiness p, INotaBusiness n)
        {
            this._prensa = p;
            this._nota = n;
        }

        [MvcSiteMapNodeAttribute(Title = "Prensa", ParentKey = "Home", Key = "Prensa")]
        public ActionResult Index()
        {
            ViewBag.menusseleccionado = "Prensa";

            var p = _prensa.Get();
            var n = _nota.GetPrensa();

            return View(new ViewModels.PrensaIndexViewModel
            {
                Prensas = p,
                Notas = n
            });
        }
    }
}