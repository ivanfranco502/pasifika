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
    public class InfoRelacionController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public InfoRelacionController(IPaginaBusiness p)
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

        public ActionResult Edit(int id, string returnUrl)
        {
            var p = _pagina.Get(id);
            InfoRelacion i;
            if (p.InfoRelaciones.Count > 0)
                i = p.InfoRelaciones.First();
            else
                i = new InfoRelacion();

            ViewBag.returnUrl = returnUrl;

            return View(new ViewModels.InfoRelacionEditViewModel
            {
                InfoRelacion = i
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int Id, int infoId, InfoRelacion i, string returnUrl, HttpPostedFileBase file1 = null, HttpPostedFileBase file2 = null, HttpPostedFileBase file3 = null, HttpPostedFileBase file4 = null)
        {
            i.Id = infoId;
            i.PaginaId = Id;

            if (file1 != null)
            {
                i.Foto1 = file1.FileName;
                i.Stream1 = file1.InputStream;
            }

            if (file2 != null)
            {
                i.Foto2 = file2.FileName;
                i.Stream2 = file2.InputStream;
            }

            if (file3 != null)
            {
                i.Foto3 = file3.FileName;
                i.Stream3 = file3.InputStream;
            }

            if (file4 != null)
            {
                i.Foto4 = file4.FileName;
                i.Stream4 = file4.InputStream;
            }

            _pagina.GuardarInfoRelacion(i, Server.MapPath("~/Content/"));

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