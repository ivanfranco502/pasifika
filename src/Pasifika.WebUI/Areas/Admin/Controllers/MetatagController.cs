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
    public class MetatagController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public MetatagController(IPaginaBusiness p)
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

        public ActionResult EditNota(int idNota, string returnUrl)
        {
            var p = _pagina.GetByNota(idNota);

            if (p == null)
            {
                p = new Pagina();
                p.NotaId = idNota;
                _pagina.Guardar(p);
            }

            return RedirectToAction("Edit", new
            {
                id = p.Id,
                returnUrl = returnUrl
            });
        }

        public ActionResult Edit(int id, string returnUrl)
        {
            var p = _pagina.Get(id);
            MetaTag m;
            if (p.MetaTags.Count > 0)
                m = p.MetaTags.First();
            else
                m = new MetaTag();

            ViewBag.returnUrl = returnUrl;

            return View(new ViewModels.MetatagEditViewModel
            {
                MetaTag = m
            });
        }

        [HttpPost]
        public ActionResult Edit(int Id, int metaId, MetaTag m, string returnUrl)
        {
            m.Id = metaId;
            m.PaginaId = Id;

            _pagina.GuardarMetaTag(m);

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