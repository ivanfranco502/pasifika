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
    public class PromocionController : Controller
    {
        private readonly IPromocionBusiness _promocion;

        public PromocionController(IPromocionBusiness p)
        {
            this._promocion = p;
        }

        public ActionResult List()
        {
            var p = _promocion.Get();

            return View(new ViewModels.PromocionListViewModel
            {
                Promociones = p
            });
        }

        public ViewResult Create()
        {
            var p = new Promocion();

            return View("Edit", new ViewModels.PromocionEditViewModel
            {
                Promocion = p
            });
        }

        public ViewResult Edit(int id)
        {
            var p = _promocion.Get(id);

            return View(new ViewModels.PromocionEditViewModel
            {
                Promocion = p
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Promocion p, HttpPostedFileBase file1 = null)
        {
            if (file1 != null)
            {
                p.Foto = file1.FileName;
                p.Stream = file1.InputStream;
            }

            _promocion.Guardar(p, Server.MapPath("~/Content"));

            return RedirectToAction("List", new
            {

            });
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            _promocion.Delete(Id);

            return RedirectToAction("List");
        }    
    }
}