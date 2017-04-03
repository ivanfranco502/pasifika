using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Business.Abstract;
using Pasifika.Model;

namespace Pasifika.WebUI.Areas.Admin.Controllers
{
    public class FormularioSesionController : Controller
    {
        private readonly IFormularioSesionBusiness _formulario;
        public FormularioSesionController(IFormularioSesionBusiness f)
        {
            this._formulario = f;
        }

        public ActionResult Edit()
        {
            var f = _formulario.Get();

            return View(new ViewModels.FormularioSesionEditViewModel
            {
                FormularioSesiones = f
            });
        }

        [HttpPost]
        public ActionResult Edit(string txtSesionesJson)
        {
            _formulario.Guardar(txtSesionesJson);

            return RedirectToAction("Edit");
        }
    }
}