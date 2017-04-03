using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Pasifika.Business.Abstract;
using Newtonsoft.Json;
using MvcSiteMapProvider;

namespace Pasifika.WebUI.Controllers
{
    public class Tipo2Controller : Controller
    {
        private readonly IPaginaBusiness _pagina;
        private readonly ITagBusiness _tag;
        private readonly IRegionBusiness _region;
        private readonly IViajeBusiness _viaje;
        private readonly IDestinoBusiness _destino;

        public Tipo2Controller(IPaginaBusiness p, ITagBusiness t, IRegionBusiness r, IViajeBusiness v, IDestinoBusiness d)
        {
            this._pagina = p;
            this._tag = t;
            this._region = r;
            this._viaje = v;
            this._destino = d;
        }

        [MvcSiteMapNodeAttribute(ParentKey = "Home", Key = "PortadaHotel", Title = "Hoteles de lujo")]
        public ActionResult HotelPortada()
        {
            var r = _region.Get().OrderBy(x => x.Orden).ToList();

            ViewBag.seccionId = 12;
            ViewBag.action = "HotelListado";
            ViewBag.menusseleccionado = "Hotel";

            ViewBag.palabra1 = "COLECCIÓN DE HOTELES DE LUJO & BOUTIQUE";
            ViewBag.palabra2 = "HOTELES BOUTIQUE Y DE LUJO EN";
            ViewBag.palabra3 = "HOTELES EN";
            ViewBag.palabra4 = "VER MÁS HOTELES EN";

            return View("Portada", new ViewModels.Tipo2PortadaViewModel
            {
                Regiones = r
            });
        }

        public ActionResult HotelListadoRedirect(string url)
        {
            return RedirectToActionPermanent("HotelListado", "Tipo2", new { url = url });
        }

        [MvcSiteMapNodeAttribute(ParentKey = "PortadaHotel", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.HotelListadoDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult HotelListado(string url)
        {
            var d = _destino.GetByUrl(url);

            ViewBag.seccionId = 13;
            ViewBag.action = "HotelDetalle";

            ViewBag.palabra1 = "COLECCIÓN DE HOTELES DE LUJO Y BOUTIQUE EN";
            ViewBag.palabra2 = "HOTEL";
            ViewBag.palabra3 = "HOTELES ENCONTRADOS EN " + d.Nombre;
            ViewBag.palabra4 = "HOTEL";

            ViewBag.menusseleccionado = "Hotel";

            var v = _viaje.Get(2, 1, null, null, null, null, null, d.Id, null);
            var vjson = from a in v
                        select new
                        {
                            a.Id,
                            a.Nombre,
                            a.Url,
                            Descripcion = this.achicar(HttpUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(a.Descripcion, @"<[^>]*>", String.Empty).Replace(Environment.NewLine, " "))),
                            a.Precio,
                            a.InfoPrecio,
                            DestinoNombre = ((ViajeTipo2)a).Ciudad.Destino.Nombre,
                            CiudadNombre = ((ViajeTipo2)a).Ciudad.Nombre,
                            CiudadId = ((ViajeTipo2)a).Ciudad.Id,
                            CiudadUrl = ((ViajeTipo2)a).Ciudad.Url,
                            Link = Url.RouteUrl(new { controller = "Tipo2", action = ViewBag.action, urlDestino = ((ViajeTipo2)a).Ciudad.Destino.Url, urlCiudad = ((ViajeTipo2)a).Ciudad.Url, url = a.Url }),
                            Fotos = from f in a.Fotos.OrderBy(x => x.Orden)
                                    select new
                                    {
                                        f.Archivo,
                                        f.Alt
                                    },
                            Tags = from t in a.TagsViaje
                                   where
                                      t.Tag.Eliminado == false
                                   orderby
                                       t.Orden
                                   select new
                                   {
                                       t.TagId,
                                       t.Tag.Nombre,
                                       t.Tag.Url
                                   }

                        };

            return View("Listado", new ViewModels.Tipo2ListadoViewModel
            {
                Viajes = v,
                Destino = d,
                ViajesJson = vjson
            });
        }

        public ActionResult HotelDetalleRedirect(string urlDestino, string urlCiudad, string url)
        {
            return RedirectToActionPermanent("HotelDetalle", "Tipo2", new { urlDestino = urlDestino, urlCiudad = urlCiudad, url = url });
        }

        [MvcSiteMapNodeAttribute(DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.HotelDetalleDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult HotelDetalle(string urlDestino, string urlCiudad, string url)
        {
            var v = _viaje.GetByUrl(url);

            if (v.Eliminado)
            {
                return RedirectPermanent(Url.RouteUrl(new
                                                        {
                                                            controller = "Tipo2",
                                                            action = "HotelListado",
                                                            url = ((ViajeTipo2)v).Ciudad.Destino.Url
                                                        }));
            }

            ViewBag.palabra1 = "HOTEL " + v.Nombre.ToUpper();
            ViewBag.palabra2 = "SOLICITAR DETALLE DE ESTE HOTEL EN " + ((ViajeTipo2)v).Ciudad.Destino.Nombre.ToUpper() + " EN .PDF";
            ViewBag.palabra3 = "CÓMO RESERVAR ESTE HOTEL EN " + ((ViajeTipo2)v).Ciudad.Nombre.ToUpper();
            ViewBag.palabra4 = "VER TODOS LOS HOTELES EN " + ((ViajeTipo2)v).Ciudad.Destino.Nombre.ToUpper();
            ViewBag.menusseleccionado = "Hotel";
            ViewBag.palabra4Link = Url.RouteUrl(new
            {
                controller = "Tipo2",
                action = "HotelListado",
                url = ((ViajeTipo2)v).Ciudad.Destino.Url
            });

            return View("Detalle", new ViewModels.Tipo2DetalleViewModel
            {
                Viaje = v
            });
        }

        [MvcSiteMapNodeAttribute(ParentKey = "Home", Key = "PortadaExcursion", Title = "Excursiones")]
        public ActionResult ExcursionPortada()
        {
            var r = _region.Get().OrderBy(x => x.Orden).ToList();

            ViewBag.seccionId = 8;
            ViewBag.action = "ExcursionListado";
            ViewBag.menusseleccionado = "Excursion";
            ViewBag.palabra1 = "EXCURSIONES EXCLUSIVAS & ORIGINALES";
            ViewBag.palabra2 = "EXCURSIONES EN";
            ViewBag.palabra3 = "EXCURSIONES EN";
            ViewBag.palabra4 = "VER MÁS EXCURSIONES EN";

            return View("Portada", new ViewModels.Tipo2PortadaViewModel
            {
                Regiones = r
            });
        }

        public ActionResult ExcursionListadoRedirect(string url)
        {
            return RedirectToActionPermanent("ExcursionListado", "Tipo2", new { url = url });
        }

        [MvcSiteMapNodeAttribute(ParentKey = "PortadaExcursion", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.ExcursionListadoDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult ExcursionListado(string url)
        {
            var d = _destino.GetByUrl(url);

            var v = _viaje.Get(2, 2, null, null, null, null, null, d.Id, null);

            ViewBag.seccionId = 9;
            ViewBag.action = "ExcursionDetalle";

            ViewBag.palabra1 = "EXCURSIONES EN";
            ViewBag.palabra2 = "EXCURSIÓN";
            ViewBag.palabra3 = "EXCURSIONES ENCONTRADAS EN " + d.Nombre;
            ViewBag.palabra4 = "EXCURSIONES";
            ViewBag.menusseleccionado = "Excursion";

            var vjson = from a in v
                        select new
                        {
                            a.Id,
                            a.Nombre,
                            a.Url,
                            Descripcion = this.achicar(HttpUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(a.Descripcion, @"<[^>]*>", String.Empty).Replace(Environment.NewLine, " "))),
                            a.Precio,
                            a.InfoPrecio,
                            DestinoNombre = ((ViajeTipo2)a).Ciudad.Destino.Nombre,
                            CiudadNombre = ((ViajeTipo2)a).Ciudad.Nombre,
                            CiudadId = ((ViajeTipo2)a).Ciudad.Id,
                            CiudadUrl = ((ViajeTipo2)a).Ciudad.Url,
                            Link = Url.RouteUrl(new { controller = "Tipo2", action = ViewBag.action, urlDestino = ((ViajeTipo2)a).Ciudad.Destino.Url, urlCiudad = ((ViajeTipo2)a).Ciudad.Url, url = a.Url }),
                            Fotos = from f in a.Fotos.OrderBy(x => x.Orden)
                                    select new
                                    {
                                        f.Archivo,
                                        f.Alt
                                    },
                            Tags = from t in a.TagsViaje
                                   where
                                      t.Tag.Eliminado == false
                                   orderby
                                       t.Orden
                                   select new
                                   {
                                       t.TagId,
                                       t.Tag.Nombre,
                                       t.Tag.Url
                                   }

                        };

            return View("Listado", new ViewModels.Tipo2ListadoViewModel
            {
                Viajes = v,
                Destino = d,
                ViajesJson = vjson
            });
        }

        public ActionResult ExcursionDetalleRedirect(string urlDestino, string urlCiudad, string url)
        {
            return RedirectToActionPermanent("ExcursionDetalle", "Tipo2", new { urlDestino = urlDestino, urlCiudad = urlCiudad, url = url });
        }

        [MvcSiteMapNodeAttribute(DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.ExcursionDetalleDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult ExcursionDetalle(string urlDestino, string urlCiudad, string url)
        {
            var v = _viaje.GetByUrl(url);

            if (v.Eliminado)
            {
                return RedirectPermanent(Url.RouteUrl(new
                                                        {
                                                            controller = "Tipo1",
                                                            action = "InteresPortada",
                                                            url = "viajes-a-medida"
                                                        }));
            }

            ViewBag.palabra1 = "EXCURSION "+ v.Nombre.ToUpper();
            ViewBag.palabra2 = "SOLICITAR DETALLE DE ESTA EXCURSIÓN EN " + ((ViajeTipo2)v).Ciudad.Destino.Nombre.ToUpper() + " EN .PDF";
            ViewBag.palabra3 = "CÓMO RESERVAR ESTA EXCURSIÓN";
            ViewBag.palabra4 = "VER TODAS LAS PROPUESTAS DE VIAJES A MEDIDA";
            ViewBag.menusseleccionado = "Excursion";
            ViewBag.palabra4Link = Url.RouteUrl(new
            {
                controller = "Tipo1",
                action = "InteresListado",
                url = "viajes-a-medida"
            });

            return View("Detalle", new ViewModels.Tipo2DetalleViewModel
            {
                Viaje = v
            });
        }

        private string achicar(string valor)
        {
            if (valor.Length > 157)
                return valor.Substring(0, 157) + " ...";
            else
                return valor;
        }
    }
}