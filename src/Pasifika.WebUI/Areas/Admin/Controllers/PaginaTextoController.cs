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
    public class PaginaTextoController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public PaginaTextoController(IPaginaBusiness p)
        {
            this._pagina = p;
        }

        public ActionResult Edit(int id)
        {
            var p = _pagina.Get(id);
            PaginaTexto m;
            if (p.PaginaTextos.Count > 0)
                m = p.PaginaTextos.First();
            else
                m = new PaginaTexto();

            return View(new ViewModels.PaginaTextoEditViewModel
            {
                PaginaTexto = m
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int Id, int paginaTextoId, PaginaTexto m)
        {
            m.Id = paginaTextoId;
            m.PaginaId = Id;

            _pagina.GuardarPaginaTexto(m);

            return RedirectToAction("List", "Pagina", new
            {

            });
        }
    }
}