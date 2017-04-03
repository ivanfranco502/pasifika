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
    public class BannerInferiorController : Controller
    {
        private readonly IPaginaBusiness _pagina;

        public BannerInferiorController(IPaginaBusiness p)
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

            ViewBag.returnUrl = returnUrl;

            return View(new ViewModels.BannerInferiorEditViewModel
            {
                Pagina = p
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int Id, string txtJsonBanners, string returnUrl, IEnumerable<HttpPostedFileBase> fileBanners = null)
        {
            List<BannerInferior> b = JsonConvert.DeserializeObject<List<BannerInferior>>(txtJsonBanners);

            int posFileBanner = 0;
            foreach (BannerInferior banner in b)
            {
                if (banner.Operacion == null || (banner.Operacion != null && banner.Operacion != "B"))
                {
                    if (banner.Id < 0)
                    {
                        if (fileBanners.ElementAt(posFileBanner) != null)
                        {
                            banner.Foto = fileBanners.ElementAt(posFileBanner).FileName;
                            banner.Stream = fileBanners.ElementAt(posFileBanner).InputStream;
                        }
                        else
                            banner.Operacion = "B";
                    }
                    else
                    {
                        if (fileBanners.ElementAt(posFileBanner) != null)
                        {
                            banner.Foto = fileBanners.ElementAt(posFileBanner).FileName;
                            banner.Stream = fileBanners.ElementAt(posFileBanner).InputStream;
                        }
                    }
                }

                posFileBanner++;
            }

            _pagina.GuardarBannersInferiores(Id, b, Server.MapPath("~/Content/"));

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