using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pasifika.WebUI.Controllers
{
    public class QuienesSomosController : Controller
    {
        // GET: QuienesSomos
        [MvcSiteMapNode(Title = "Quiénes somos", ParentKey = "Home", Key = "QuienesSomos")] 
        public ActionResult Index()
        {
            ViewBag.menusseleccionado = "QuienesSomos";
            return View();
        }
    }
}