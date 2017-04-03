using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Business.Abstract;
using Pasifika.Model;

namespace Pasifika.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class BannerContextualController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public BannerContextualController(IPaginaBusiness p)
        {
            this._pagina = p;
        }

        public ActionResult EditViaje(int idViaje, string returnUrl)
        {
            var p = _pagina.GetByViaje(idViaje);

            if (p == null)
            {
                p = new Pagina();
                p.ViajeId = idViaje;
                _pagina.Guardar(p);
            }

            return RedirectToAction("Edit", new
            {
                id = p.Id,
                returnUrl = returnUrl
            });
        }

        public ActionResult Delete(int id)
        {
            _pagina.RemoveBannerContextual(id);

            return RedirectToAction("List", "Pagina");
        }

        public ActionResult Edit(int id, string returnUrl)
        {
            var p = _pagina.Get(id);
            BannerContextual b;
            if (p.BannersContextual.Count > 0)
                b = p.BannersContextual.First();
            else
                b = new BannerContextual();

            ViewBag.returnUrl = returnUrl;

            return View(new ViewModels.BannerContextualEditViewModel
            {
                BannerContextual = b
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int Id, int infoId, BannerContextual b, string returnUrl, HttpPostedFileBase file = null)
        {
            b.Id = infoId;
            b.PaginaId = Id;

            if (file != null)
            {
                b.Foto = file.FileName;
                b.Stream = file.InputStream;
            }

            _pagina.GuardarBannersContextual(b, Server.MapPath("~/Content/"));

            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("List", "Pagina", new
                {

                });
            }
        }
    }
}