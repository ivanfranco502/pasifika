using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Business.Abstract;
using System.IO;
using MvcSiteMapProvider;

namespace Pasifika.WebUI.Controllers
{
    public class NotasController : Controller
    {
        private readonly INotaBusiness _nota;
        
        public NotasController(INotaBusiness n)
        {
            this._nota = n;
        }
        
        [MvcSiteMapNodeAttribute(Title = "Notas", ParentKey = "Home", Key = "Notas")]
        public ActionResult Index(int? pagina)
        {
            int page = 1;
            int cantidadPagina = 6;
            if (pagina.HasValue)
                page = pagina.Value;

            var n = _nota.GetPaginado(null, null, true, page, cantidadPagina);
            var nd = _nota.Get(null, null, true);

            int maxPage = 0;

            if (n.Count > 0)
            {
                int totalRows = nd.Count();

                if (totalRows % cantidadPagina > 0)
                    maxPage = (totalRows / cantidadPagina) + 1;
                else
                    maxPage = totalRows / cantidadPagina;

            }

            string linkAnterior = "";
            string linkSiguiente = "";

            if (page - 1 > 0)
                linkAnterior = Url.RouteUrl(new { controller = "Notas", action = "Index", Pagina = page - 1 });

            if (page + 1 <= maxPage)
                linkSiguiente = Url.RouteUrl(new { controller = "Notas", action = "Index", Pagina = page + 1 });

            ViewBag.menusseleccionado = "Notas";

            return View(new ViewModels.NotasIndexViewModel
            {
                Notas = n,
                NotasDirectorio = nd,
                Pagina = page,
                CantidadPagina = maxPage,
                linkAnterior = linkAnterior,
                linkSiguiente = linkSiguiente
            });
        }

        [MvcSiteMapNodeAttribute(Title = "Notas", ParentKey = "Home", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.NotaIndexDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult IndexAnoMes(int ano, int mes, int? pagina)
        {
            int page = 1;
            int cantidadPagina = 6;
            if (pagina.HasValue)
                page = pagina.Value;

            var n = _nota.GetPaginado(ano, mes, true, page, cantidadPagina);
            var notasTotal = _nota.Get(ano, mes, true);
            var nd = _nota.Get(null, null, true);

            int maxPage = 0;

            if (n.Count > 0)
            {
                int totalRows = notasTotal.Count();

                if (totalRows % cantidadPagina > 0)
                    maxPage = (totalRows / cantidadPagina) + 1;
                else
                    maxPage = totalRows / cantidadPagina;

            }

            string linkAnterior = "";
            string linkSiguiente = "";

            if (page - 1 > 0)
                linkAnterior = Url.RouteUrl("notasFecha", new { ano = ano, mes = mes, Pagina = page - 1 });

            if (page + 1 <= maxPage)
                linkSiguiente = Url.RouteUrl("notasFecha", new { ano = ano, mes = mes, Pagina = page + 1 });

            ViewBag.menusseleccionado = "Notas";

            return View("Index", new ViewModels.NotasIndexViewModel
            {
                Notas = n,
                NotasDirectorio = nd,
                Pagina = page,
                CantidadPagina = maxPage,
                linkAnterior = linkAnterior,
                linkSiguiente = linkSiguiente
            });
        }

        [MvcSiteMapNodeAttribute(Title = "Nota", ParentKey = "Notas", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.NotaDetailsDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult Detalle(string url)
        {
            var n = _nota.GetByUrl(url);

            if (url == "preguntas-frecuentes")
                ViewBag.menusseleccionado = "preguntas-frecuentes";
            else
            { 
                if(n.Visible)
                    ViewBag.menusseleccionado = "Notas";
            }
                

            string texto = "";


            if (System.IO.File.Exists(Server.MapPath("~/Content/images/nota") + "\\" + n.Id.ToString() + ".html"))
            {
                using (var tr = new StreamReader(Server.MapPath("~/Content/images/nota") + "\\" + n.Id.ToString() + ".html"))
                {
                    texto = tr.ReadToEnd();
                }
            }

            return View(new ViewModels.NotasDetalleViewModel
            {
                Nota = n,
                Texto = texto
            });
        }
    }
}