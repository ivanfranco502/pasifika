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
    public class PaginaController : Controller
    {
        private readonly IPaginaBusiness _pagina;
        private readonly ITagBusiness _tag;
        private readonly ISeccionBusiness _seccion;
        private readonly IDestinoBusiness _destino;
        private readonly IRegionBusiness _region;

        public PaginaController(IPaginaBusiness p, ITagBusiness t, ISeccionBusiness s, IDestinoBusiness  d, IRegionBusiness r)
        {
            this._pagina = p;
            this._tag = t;
            this._seccion = s;
            this._destino = d;
            this._region = r;
        }

        public ActionResult List()
        {
            var p = _pagina.Get();

            return View(new ViewModels.PaginaListViewModel
            {
                Paginas = p                
            });
        }

        public ViewResult Create()
        {
            Pagina p = new Pagina();
            var t = _tag.Get();
            var s = _seccion.Get();
            var d = _destino.Get();
            var r = _region.Get();

            return View("Edit", new ViewModels.PaginaEditViewModel
            {
                Pagina = p,
                Tags = t,
                Secciones = s,
                Destinos = d,
                Regiones = r
            });
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            _pagina.Delete(Id);

            return RedirectToAction("List", new
            {
                
            });
        }

        public ViewResult Edit(int id)
        {
            Pagina p = _pagina.Get(id);
            var t = _tag.Get();
            var s = _seccion.Get();
            var d = _destino.Get();
            var r = _region.Get();

            return View(new ViewModels.PaginaEditViewModel
            {
                Pagina = p,
                Tags = t,
                Secciones = s,
                Destinos = d,
                Regiones = r
            });
        }

        [HttpPost]
        public ActionResult Edit(Pagina p)
        {
            _pagina.Guardar(p);

            return RedirectToAction("List", new
            {

            });
        }

        [HttpPost]
        public ActionResult Order(string txtJsonOrden)
        {
            _pagina.Order(txtJsonOrden);

            return RedirectToAction("List", new
            {
                
            });
        }
    }
}