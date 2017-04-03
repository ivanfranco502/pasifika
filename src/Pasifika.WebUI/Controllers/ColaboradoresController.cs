using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Business.Abstract;
using MvcSiteMapProvider;

namespace Pasifika.WebUI.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly IPartnerBusiness _partner;
        public ColaboradoresController(IPartnerBusiness p)
        {
            this._partner = p;
        }

        [MvcSiteMapNodeAttribute(Title = "Colaboradores", ParentKey = "Home", Key = "Colaboradores")]
        public ActionResult Index()
        {
            ViewBag.menusseleccionado = "Colaboradores";
            var p = _partner.Get();

            return View(new ViewModels.ColaboradoresIndexViewModel
            {
                Partners = p
            });
        }
    }
}