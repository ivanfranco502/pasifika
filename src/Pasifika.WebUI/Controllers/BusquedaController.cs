using Pasifika.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pasifika.WebUI.Controllers
{
    public class BusquedaController : Controller
    {

        private readonly IBusquedaBusiness _busqueda;
        // GET: Busqueda

        public BusquedaController(IBusquedaBusiness b)
        {
            this._busqueda = b;
        }

        public ActionResult Index(string texto)
        {
            return RedirectToAction("List", new  {texto = texto.Trim().Replace('/',' ')});
        }

        public ActionResult List(string texto, int? pagina)
        {
            int page = 1;
            if (pagina.HasValue)
                page = pagina.Value;

            var busqueda = _busqueda.GetDatos(texto, page, 5);

            int maxPage = 0;

            if (busqueda.Count > 0)
            { 
                int totalRows = busqueda.FirstOrDefault().TotalROWS;

                if (totalRows % 5 > 0)
                    maxPage = (totalRows / 5) + 1;
                else
                    maxPage = totalRows / 5;
                
            }

            return View(new ViewModels.BusquedaViewModel
            {
                Busquedas = busqueda,
                Pagina = page,
                Texto = texto,
                CantidadPagina = maxPage
            });
        }

    }
}