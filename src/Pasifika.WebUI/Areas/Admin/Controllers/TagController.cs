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
    public class TagController : Controller
    {
        private readonly ITagBusiness _tag;

        public TagController (ITagBusiness t)
        {
            this._tag = t;
        }

        public ActionResult List()
        {
            var t = _tag.Get();

            return View(new ViewModels.TagListViewModel
            {
                Tags = t
            });
        }

        public ViewResult Create()
        {
            var t = new Tag();

            return View("Edit", new ViewModels.TagEditViewModel
            {
                Tag = t
            });
        }

        public ViewResult Edit(int id)
        {
            var t = _tag.Get(id);

            return View(new ViewModels.TagEditViewModel
            {
                Tag = t
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Tag t)
        {
            _tag.Guardar(t);

            return RedirectToAction("List", new
            {

            });
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            _tag.Delete(Id);

            return RedirectToAction("List");
        }
    }
}