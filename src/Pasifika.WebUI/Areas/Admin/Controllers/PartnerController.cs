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
    public class PartnerController : Controller
    {
        private readonly IPartnerBusiness _partner;

        public PartnerController(IPartnerBusiness p)
        {
            this._partner = p;
        }

        public ActionResult List()
        {
            var p = _partner.Get();

            return View(new ViewModels.PartnerListViewModel
            {
                Partners = p
            });
        }

        public ViewResult Create()
        {
            var p = new Partner();

            return View("Edit", new ViewModels.PartnerEditViewModel
            {
                Partner = p
            });
        }

        public ViewResult Edit(int id)
        {
            var p = _partner.Get(id);

            return View(new ViewModels.PartnerEditViewModel
            {
                Partner = p
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Partner p, HttpPostedFileBase file1 = null)
        {
            if (file1 != null)
            {
                p.Foto = file1.FileName;
                p.Stream = file1.InputStream;
            }

            _partner.Guardar(p, Server.MapPath("~/Content"));

            return RedirectToAction("List", new
            {

            });
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            _partner.Delete(Id);

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Order(string txtJsonOrden)
        {
            _partner.Order(txtJsonOrden);

            return RedirectToAction("List");
        }
    }
}