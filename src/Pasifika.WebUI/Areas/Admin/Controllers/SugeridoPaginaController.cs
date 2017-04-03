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
    public class SugeridoPaginaController : Controller
    {
        private readonly IPaginaBusiness _pagina;
        private readonly ISugerenciaBusiness _sugerencia;

        public SugeridoPaginaController(IPaginaBusiness p, ISugerenciaBusiness s)
        {
            this._pagina = p;
            this._sugerencia = s;
        }

        public ActionResult EditViaje(int idViaje, string returnUrl)
        {
            var p = _pagina.GetByViaje(idViaje);

            if (p == null)
            {
                p = new Pagina();
                p.ViajeId = idViaje;
                _pagina.Guardar(p);
            }

            return RedirectToAction("Edit", new
            {
                id = p.Id,
                returnUrl = returnUrl
            });
        }

        public ActionResult EditNota(int idNota, string returnUrl)
        {
            var p = _pagina.GetByNota(idNota);

            if (p == null)
            {
                p = new Pagina();
                p.NotaId = idNota;
                _pagina.Guardar(p);
            }

            return RedirectToAction("Edit", new
            {
                id = p.Id,
                returnUrl = returnUrl
            });
        }

        public ActionResult Edit(int id, string returnUrl)
        {
            var p = _pagina.Get(id);
            var s = _sugerencia.Get();

            ViewBag.returnUrl = returnUrl;

            return View(new ViewModels.SugerenciaPaginaEditViewModel
            {
                Pagina = p,
                Sugerencias = s
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int Id, string txtJsonSugerencias, string returnUrl)
        {
            _pagina.GuardarSugeridos(Id, txtJsonSugerencias);

            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("List", "Pagina", new
                {

                });
            }
        }
    }
}