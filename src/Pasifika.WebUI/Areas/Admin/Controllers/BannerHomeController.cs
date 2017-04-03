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
    public class BannerHomeController : Controller
    {
        private readonly IBannerHomeBusiness _banner;
        public BannerHomeController(IBannerHomeBusiness b)
        {
            this._banner = b;
        }

        public ActionResult List()
        {
            var b = _banner.Get();

            return View(new ViewModels.BannerHomeListViewModel
            {
                BannersHome = b
            });
        }

        public ViewResult Create()
        {
            var b = new BannerHome();

            return View("Edit", new ViewModels.BannerHomeEditViewModel
            {
                BannerHome = b
            });
        }

        public ViewResult Edit(int id)
        {
            var b = _banner.Get(id);

            return View(new ViewModels.BannerHomeEditViewModel
            {
                BannerHome = b
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(BannerHome b, HttpPostedFileBase file1 = null)
        {
            if (file1 != null)
            {
                b.Foto = file1.FileName;
                b.Stream = file1.InputStream;
            }

            _banner.Guardar(b, Server.MapPath("~/Content"));

            return RedirectToAction("List", new
            {

            });
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            _banner.Delete(Id);

            return RedirectToAction("List");
        }
    }
}