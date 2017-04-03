using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Business.Abstract;
using Pasifika.Model;

namespace Pasifika.WebUI.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagBusiness _tag;

        public TagController(ITagBusiness t)
        {
            this._tag = t;
        }

        public ActionResult Get(List<string> tags)
        {
            List<Tag> result = new List<Tag>();

            foreach (string tag in tags)
            {
                var t = _tag.GetByUrl(tag);
                if (t != null)
                    result.Add(t);
            }

            var r = new
                    {
                        tags = from t in result
                               select new
                               {
                                   t.Nombre,
                                   t.Url
                               }
                    };

            return Json(r);
        }
    }
}