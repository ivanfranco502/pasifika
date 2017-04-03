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
    public class DestinoController : Controller
    {
        private readonly IDestinoBusiness _destino;
        private readonly IRegionBusiness _region;

        public DestinoController(IDestinoBusiness d, IRegionBusiness r)
        {
            this._destino = d;
            this._region = r;
        }

        public ActionResult List(int regionId)
        {
            var d = _destino.GetByRegion(regionId);
            var r = _region.Get(regionId);

            return View(new ViewModels.DestinoListViewModel
            {
                Destinos = d,
                Region = r
            });
        }

        public ViewResult Create(int regionId)
        {
            var d = new Destino();
            d.RegionId = regionId;

            return View("Edit", new ViewModels.DestinoEditViewModel
            {
                Destino = d
            });
        }

        public ViewResult Edit(int id)
        {
            var d = _destino.Get(id);

            return View(new ViewModels.DestinoEditViewModel
            {
                Destino = d
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Destino d, HttpPostedFileBase file1 = null, HttpPostedFileBase file2 = null, HttpPostedFileBase file3 = null, HttpPostedFileBase filePDFGuia = null, IEnumerable<string> Titulo = null, IEnumerable<string> Texto = null)
        {
            if (file1 != null)
            {
                d.FotoGuia = file1.FileName;
                d.StreamGuia = file1.InputStream;
            }

            if (file2 != null)
            {
                d.FotoHotel = file2.FileName;
                d.StreamHotel = file2.InputStream;
            }

            if (file3 != null)
            {
                d.FotoExcursion = file3.FileName;
                d.StreamExcursion = file3.InputStream;
            }

            if (filePDFGuia != null)
            {
                d.PDFGuia = filePDFGuia.FileName;
                d.StreamPDFGuia = filePDFGuia.InputStream;
            }

            _destino.Guardar(d, Server.MapPath("~/Content"), Titulo, Texto);

            return RedirectToAction("List", new
            {
                regionId = d.RegionId
            });
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            int regionId = _destino.Get(Id).RegionId;
            _destino.Delete(Id);

            return RedirectToAction("List", new
            {
                regionId = regionId
            });
        }

        [HttpPost]
        public ActionResult Order(string txtJsonOrden, int regionId)
        {
            _destino.Order(txtJsonOrden);

            return RedirectToAction("List", new
            {
                regionId = regionId
            });
        }
    }
}