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
    public class RegionController : Controller
    {
        private readonly IRegionBusiness _region;

        public RegionController(IRegionBusiness r)
        {
            this._region = r;
        }

        public ActionResult List()
        {
            var r = _region.Get().OrderBy(x => x.Orden).ToList();

            return View(new ViewModels.RegionListViewModel
            {
                Regiones = r
            });
        }

        public ViewResult Create()
        {
            var r = new Region();

            return View("Edit", new ViewModels.RegionEditViewModel
            {
                Region = r
            });
        }

        public ViewResult Edit(int id)
        {
            var r = _region.Get(id);

            return View(new ViewModels.RegionEditViewModel
            {
                Region = r
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Region r, HttpPostedFileBase file1 = null)
        {
            if (file1 != null)
            {
                r.Foto = file1.FileName;
                r.Stream = file1.InputStream;
            }

            _region.Guardar(r, Server.MapPath("~/Content"));

            return RedirectToAction("List", new
            {

            });
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            _region.Delete(Id);

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Order(string txtJsonOrden)
        {
            _region.Order(txtJsonOrden);

            return RedirectToAction("List", new
            {
                
            });
        }
    }
}