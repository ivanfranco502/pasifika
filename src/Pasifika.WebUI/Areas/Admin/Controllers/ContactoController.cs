using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Pasifika.Business.Abstract;

namespace Pasifika.WebUI.Areas.Admin.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IContactoBusiness _contacto;
        private readonly IExcelExportBusiness _exportExcel;
        public ContactoController(IContactoBusiness c, IExcelExportBusiness e)
        {
            this._contacto = c;
            this._exportExcel = e;
        }

        public ActionResult Index()
        {
            var c = _contacto.Get();

            return View(c);
        }

        public ActionResult Delete(int id)
        {
            _contacto.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Exportar()
        {
            // 1: CSV
            // 2: Excel
            //if (tipoExportacion == "1")
            //return GetCSV(cupon, concesionario, modelo, categoriamodelo, fechadesde, fechahasta);
            //else
            return GetExcel();
        }

        public ActionResult GetExcel()
        {
            var encuestas = _contacto.GetDataExport();
            Byte[] result = _exportExcel.GetExcel(encuestas);

            Response.Clear();
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=Mails.xlsx");
            Response.BinaryWrite(result);
            Response.End();

            return RedirectToAction("Index");
        }
    }
}