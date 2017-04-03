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
    public class DestacadoController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public DestacadoController(IPaginaBusiness p)
        {
            this._pagina = p;
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

        public ActionResult Edit(int id, string returnUrl)
        {
            var p = _pagina.Get(id);

            ViewBag.returnUrl = returnUrl;

            return View(new ViewModels.DestacadoEditViewModel
            {
                Pagina = p
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int Id, string txtJsonSugerencias, string returnUrl, IEnumerable<HttpPostedFileBase> fileSugerencias = null)
        {
            List<Destacado> s = JsonConvert.DeserializeObject<List<Destacado>>(txtJsonSugerencias);

            int posFileSugerencia = 0;
            foreach (Destacado sugerencia in s)
            {
                if (sugerencia.Operacion == null || (sugerencia.Operacion != null && sugerencia.Operacion != "B"))
                {
                    if (sugerencia.Id < 0)
                    {
                        if (fileSugerencias.ElementAt(posFileSugerencia) != null)
                        {
                            sugerencia.Foto = fileSugerencias.ElementAt(posFileSugerencia).FileName;
                            sugerencia.Stream = fileSugerencias.ElementAt(posFileSugerencia).InputStream;
                        }
                        else
                            sugerencia.Operacion = "B";
                    }
                    else
                    {
                        if (fileSugerencias.ElementAt(posFileSugerencia) != null)
                        {
                            sugerencia.Foto = fileSugerencias.ElementAt(posFileSugerencia).FileName;
                            sugerencia.Stream = fileSugerencias.ElementAt(posFileSugerencia).InputStream;
                        }
                    }
                }

                posFileSugerencia++;
            }

            _pagina.GuardarDestacados(Id, s, Server.MapPath("~/Content/"));

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