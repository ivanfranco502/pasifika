using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Pasifika.Business.Abstract;
using System.IO;

namespace Pasifika.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class NotaController : Controller
    {
        private readonly INotaBusiness _nota;
        public NotaController(INotaBusiness n)
        {
            this._nota = n;
        }

        public ActionResult List()
        {
            var n = _nota.Get(null, null, null);

            return View(new ViewModels.NotaListViewModel
            {
                Notas = n
            });
        }

        public ViewResult Create()
        {
            var n = new Nota();
            n.Fecha = DateTime.Now;

            return View("Edit", new ViewModels.NotaEditViewModel
            {
                Nota = n
            });
        }

        public ViewResult Edit(int id)
        {
            var n = _nota.Get(id);

            string texto = "";

            if (System.IO.File.Exists(Server.MapPath("~/Content/images/nota") + "\\" + n.Id.ToString() + ".html"))
            {
                using (var tr = new StreamReader(Server.MapPath("~/Content/images/nota") + "\\" + n.Id.ToString() + ".html"))
                {
                    texto = tr.ReadToEnd();
                }
            }

            return View(new ViewModels.NotaEditViewModel
            {
                Nota = n,
                Texto = texto
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Nota n, string Texto)
        {
            _nota.Guardar(n, Texto, Server.MapPath("~/Content"));

            return RedirectToAction("List", new
            {

            });
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            _nota.Delete(Id);

            return RedirectToAction("List");
        }   
    }
}