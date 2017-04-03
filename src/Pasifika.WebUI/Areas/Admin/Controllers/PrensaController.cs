using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Pasifika.Business.Abstract;

namespace Pasifika.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class PrensaController : Controller
    {
        private readonly IPrensaBusiness _prensa;

        public PrensaController(IPrensaBusiness p)
        {
            this._prensa = p;
        }

        public ActionResult List()
        {
            var p = _prensa.Get();

            return View(new ViewModels.PrensaListViewModel
            {
                Prensas = p
            });
        }

        public ViewResult Create()
        {
            var p = new Prensa();

            p.Fecha = DateTime.Now;

            return View("Edit", new ViewModels.PrensaEditViewModel
            {
                Prensa = p
            });
        }

        public ViewResult Edit(int id)
        {
            var p = _prensa.Get(id);

            return View(new ViewModels.PrensaEditViewModel
            {
                Prensa = p
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Prensa p, HttpPostedFileBase file1 = null, HttpPostedFileBase file2 = null)
        {
            if (file1 != null)
            {
                p.Foto = file1.FileName;
                p.StreamFoto = file1.InputStream;
            }

            if (file2 != null)
            {
                p.PDF = file2.FileName;
                p.StreamPDF = file2.InputStream;
            }

            _prensa.Guardar(p, Server.MapPath("~/Content"));

            return RedirectToAction("List", new
            {

            });
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            _prensa.Delete(Id);

            return RedirectToAction("List");
        }            
    }
}