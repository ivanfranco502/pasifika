using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Business.Abstract;
using Pasifika.Model;
using Newtonsoft.Json;

namespace Pasifika.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class CiudadController : Controller
    {
        private readonly IDestinoBusiness _destino;
        private readonly ICiudadBusiness _ciudad;

        public CiudadController(IDestinoBusiness d, ICiudadBusiness c)
        {
            this._destino = d;
            this._ciudad = c;
        }

        public ActionResult List(int destinoId)
        {
            var c = _ciudad.GetByDestino(destinoId);
            var d = _destino.Get(destinoId);

            return View(new ViewModels.CiudadListViewModel
            {
                Destino = d,
                Ciudades = c
            });
        }

        public ViewResult Create(int destinoId)
        {
            var c = new Ciudad();
            c.DestinoId = destinoId;

            return View("Edit", new ViewModels.CiudadEditViewModel
            {
                Ciudad = c
            });
        }

        public ViewResult Edit(int id)
        {
            var c = _ciudad.Get(id);

            return View(new ViewModels.CiudadEditViewModel
            {
                Ciudad = c
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Ciudad c)
        {
            _ciudad.Guardar(c);

            return RedirectToAction("List", new
            {
                destinoId = c.DestinoId
            });
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            int destinoId = _ciudad.Get(Id).DestinoId;
            _ciudad.Delete(Id);

            return RedirectToAction("List", new
            {
                destinoId = destinoId
            });
        }

        public ActionResult GetCiudades(int DestinoId)
        {
            var sc = _ciudad.GetByDestino(DestinoId);

            var l = from c in sc
                    select new { c.Id, c.Nombre};

            return Content(JsonConvert.SerializeObject(l));
        }
    }
}