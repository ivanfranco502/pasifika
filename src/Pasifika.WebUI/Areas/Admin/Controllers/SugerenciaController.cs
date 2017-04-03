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
    public class SugerenciaController : Controller
    {
        private readonly ISugerenciaBusiness _sugerencia;

        public SugerenciaController(ISugerenciaBusiness s)
        {
            this._sugerencia = s;
        }

        public ActionResult List()
        {
            var s = _sugerencia.Get();

            return View(new ViewModels.SugerenciaListViewModel
            {
                Sugrencias = s
            });
        }

        public ViewResult Create()
        {
            var s = new Sugerencia();

            return View("Edit", new ViewModels.SugerenciaEditViewModel
            {
                Sugerencia = s
            });
        }

        public ViewResult Edit(int id)
        {
            var s = _sugerencia.Get(id);

            return View(new ViewModels.SugerenciaEditViewModel
            {
                Sugerencia = s
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Sugerencia s, HttpPostedFileBase file1 = null)
        {
            if (file1 != null)
            {
                s.Foto = file1.FileName;
                s.Stream = file1.InputStream;
            }

            _sugerencia.Guardar(s, Server.MapPath("~/Content"));

            return RedirectToAction("List", new
            {

            });
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            _sugerencia.Delete(Id);

            return RedirectToAction("List");
        }    
    }
}