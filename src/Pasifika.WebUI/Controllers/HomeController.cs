using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Business.Abstract;
using Pasifika.Model;
using MvcSiteMapProvider;

namespace Pasifika.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBannerHomeBusiness _banner;
        public readonly IContactoBusiness _contacto;

        public HomeController(IBannerHomeBusiness b, IContactoBusiness c)
        {
            this._banner = b;
            this._contacto = c;
        }

        [MvcSiteMapNode(Title = "Home", Key = "Home")] 
        public ActionResult Index()
        {
            var b = _banner.GetMostrar();
            return View(new ViewModels.HomeViewModel
            {
                BannerHome = b
            });
        }

        public ActionResult Newsletter(string email)
        {
            try
            {
                Contacto c = new Contacto();
                c.Email = email;
                c.Newsletter = true;
                c.Fecha = DateTime.Now;
                c.Tipo = "NEWSLETTER";

                _contacto.Guardar(c);

                string subject = "Inscripción a la newsletter";
                string to = "news@pasifika.es";
                string body = "";
                body += "Email:" + c.Email + Environment.NewLine;

                _contacto.SendMail(to, subject, body);

                return Content("0");
            }
            catch(Exception ex)
            {
                return Content("-1");
            }
            
        }
    }
}