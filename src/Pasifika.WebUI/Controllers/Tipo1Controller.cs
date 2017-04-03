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
    public class Tipo1Controller : Controller
    {
        private readonly IPaginaBusiness _pagina;
        private readonly ITagBusiness _tag;
        private readonly IDestinoBusiness _destino;
        private readonly IViajeBusiness _viajes;

        public Tipo1Controller(IPaginaBusiness p, ITagBusiness t, IDestinoBusiness d, IViajeBusiness v)
        {
            this._pagina = p;
            this._tag = t;
            this._destino = d;
            this._viajes = v;
        }

        //[MvcSiteMapNodeAttribute(ParentKey = "Home", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.InteresPortadaDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult InteresPortada(string url)
        {
            return RedirectToActionPermanent("InteresListado", "Tipo1", new { url = url });

            var t = _tag.GetByUrl(url);

            ViewBag.menusseleccionado = url;

            ViewBag.seccionId = 4;
            ViewBag.tagId = t.Id;

            ViewBag.palabra = t.Descripcion.ToUpper();
            ViewBag.palabra2 = "VER TODAS LAS PROPUESTAS DE " + t.Descripcion.ToUpper();
            ViewBag.palabra3 = t.Descripcion.ToUpper();

            ViewBag.link = Url.RouteUrl(new { controller = "Tipo1", action = "InteresListado", url = t.Url });

            return View("Portada");
        }

        [MvcSiteMapNodeAttribute(ParentKey = "Home", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.InteresListadoDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult InteresListado(string url)
        {
            var t = _tag.GetByUrl(url);

            if (t.Eliminado)
                return RedirectPermanent(Url.RouteUrl(new
                {
                    controller = "Home",
                    action = "Index"
                }));

            if (t.Id == 1284)
                return RedirectToActionPermanent("WellnesListado", "Tipo1");

            ViewBag.menusseleccionado = url;
            ViewBag.seccionId = 5;
            ViewBag.tagId = t.Id;

            ViewBag.palabra = t.Descripcion.ToUpper();
            ViewBag.palabra2 = t.Descripcion.ToUpper();
            ViewBag.palabra3 = "VIAJE";
            ViewBag.palabra4 = "VER VIAJE";
            ViewBag.palabra5 = "días";
            ViewBag.palabra6 = "ciudades";

            ViewBag.controller = "Tipo1";
            ViewBag.action = "DestinoDetalle";

            ViewBag.menusseleccionado = url;


            List<int> tags = new List<int>();
            tags.Add(t.Id);

            var v = _viajes.Get(1, 1, null, null, null, null, tags, null, null);

            var vjson = from a in v
                        select new
                        {
                            EsBannerContextual = false,
                            IdContextual = 0,
                            a.Id,
                            a.Nombre,
                            a.AltImagenListado,
                            a.ImagenListado,
                            a.Url,
                            ((ViajeTipo1)a).Paises,
                            Descripcion = this.achicar(HttpUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(a.Descripcion, @"<[^>]*>", String.Empty).Replace(Environment.NewLine, " "))),
                            ((ViajeTipo1)a).Duracion,
                            a.Precio,
                            DestinoNombre = ((ViajeTipo1)a).Destino.Nombre,
                            DestinoUrl = ((ViajeTipo1)a).Destino.Url,
                            ((ViajeTipo1)a).Ciudades,
                            Link = Url.RouteUrl(new { controller = ViewBag.controller, action = ViewBag.action, urlDestino = ((ViajeTipo1)a).Destino.Url, url = a.Url }),
                            Tags = from tt in a.TagsViaje
                                   where
                                      tt.Tag.Eliminado == false
                                   orderby
                                       tt.Orden
                                   select new
                                   {
                                       tt.TagId,
                                       tt.Tag.Nombre,
                                       tt.Tag.Url
                                   }

                        };

            Pagina p = _pagina.Get(ViewBag.seccionId, null, null, null, ViewBag.tagId, null);

            BannerContextual b = p.BannersContextual.FirstOrDefault();

            var vjson1 = vjson.ToList();

            if (b != null)
            {
                vjson1.Insert(0, new
                {
                    EsBannerContextual = true,
                    IdContextual = p.Id,
                    Id = -1,
                    Nombre = b.Title,
                    AltImagenListado = b.Alt,
                    ImagenListado = b.Foto,
                    Url = b.Link,
                    Paises = "",
                    Descripcion = "",
                    Duracion = 0,
                    Precio = 0,
                    DestinoNombre = "",
                    DestinoUrl = "",
                    Ciudades = "",
                    Link = b.Link,
                    Tags = from tt in new List<ViajeTag>()
                           select new
                           {
                               tt.TagId,
                               tt.Tag.Nombre,
                               tt.Tag.Url
                           }
                });
            }

            return View("Listado", new ViewModels.Tipo1ListadoViewModel
            {
                Viajes = v,
                Tag = t,
                ViajesJson = vjson1
            });
        }

        //[MvcSiteMapNodeAttribute(ParentKey = "Home", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.DestinoPortadaDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult DestinoPortada(string url)
        {
            return RedirectToActionPermanent("DestinoListado", "Tipo1", new { url = url });

            var d = _destino.GetByUrl(url);

            ViewBag.seccionId = 14;
            ViewBag.destinoId = d.Id;

            ViewBag.palabra = "VIAJES A " + d.Nombre.ToUpper();
            ViewBag.palabra2 = "VER TODAS LAS PROPUESTAS DE VIAJES A " + d.Nombre.ToUpper();
            ViewBag.palabra3 = "VIAJES A " + d.Nombre.ToUpper();
            ViewBag.action = "DestinoDetalle";
            ViewBag.menusseleccionado = d.Url;

            ViewBag.link = Url.RouteUrl(new { controller = "Tipo1", action = "DestinoListado", url = d.Url });

            return View("Portada");
        }

        [MvcSiteMapNodeAttribute(ParentKey = "Home", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.DestinoListadoDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult DestinoListado(string url)
        {
            var d = _destino.GetByUrl(url);

            ViewBag.seccionId = 15;
            ViewBag.destinoId = d.Id;

            ViewBag.palabra = "VIAJES A " + d.Nombre.ToUpper();
            ViewBag.palabra2 = "VIAJES A " + d.Nombre.ToUpper();
            ViewBag.palabra3 = "VIAJE";
            ViewBag.palabra4 = "VER VIAJE";
            ViewBag.palabra5 = "días";
            ViewBag.palabra6 = "ciudades";

            ViewBag.controller = "Tipo1";
            ViewBag.action = "DestinoDetalle";

            ViewBag.menusseleccionado = url;

            var v = _viajes.Get(1, 1, null, null, null, null, null, d.Id, null);


            var vjson = from a in v
                        select new
                        {
                            EsBannerContextual = false,
                            IdContextual = 0,
                            a.Id,
                            a.Nombre,
                            a.AltImagenListado,
                            a.ImagenListado,
                            a.Url,
                            ((ViajeTipo1)a).Paises,
                            Descripcion = this.achicar(HttpUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(a.Descripcion, @"<[^>]*>", String.Empty).Replace(Environment.NewLine, " "))),
                            ((ViajeTipo1)a).Duracion,
                            a.Precio,
                            DestinoNombre = ((ViajeTipo1)a).Destino.Nombre,
                            DestinoUrl = ((ViajeTipo1)a).Destino.Url,
                            ((ViajeTipo1)a).Ciudades,
                            Link = Url.RouteUrl(new { controller = ViewBag.controller, action = ViewBag.action, urlDestino = ((ViajeTipo1)a).Destino.Url, url = a.Url }),
                            Tags = from tt in a.TagsViaje
                                   where
                                      tt.Tag.Eliminado == false
                                   orderby
                                       tt.Orden
                                   select new
                                   {
                                       tt.TagId,
                                       tt.Tag.Nombre,
                                       tt.Tag.Url
                                   }

                        };
            //var jsonmodel = @Html.Raw(Json.Encode(Model));
            Pagina p = _pagina.Get(ViewBag.seccionId, null, null, ViewBag.destinoId, null, null);

            BannerContextual b = p.BannersContextual.FirstOrDefault();

            var vjson1 = vjson.ToList();

            if (b != null)
            {
                vjson1.Insert(0, new
                {
                    EsBannerContextual = true,
                    IdContextual = p.Id,
                    Id = -1,
                    Nombre = b.Title,
                    AltImagenListado = b.Alt,
                    ImagenListado = b.Foto,
                    Url = b.Link,
                    Paises = "",
                    Descripcion = "",
                    Duracion = 0,
                    Precio = 0,
                    DestinoNombre = "",
                    DestinoUrl = "",
                    Ciudades = "",
                    Link = b.Link,
                    Tags = from tt in new List<ViajeTag>()
                           select new
                           {
                               tt.TagId,
                               tt.Tag.Nombre,
                               tt.Tag.Url
                           }
                });
            }


            string json = JsonConvert.SerializeObject(vjson1);

            return View("Listado", new ViewModels.Tipo1ListadoViewModel
            {
                Viajes = v,
                ViajesJson = vjson1,
                BannerContextual = p.BannersContextual.FirstOrDefault()
            });
        }

        private string achicar(string valor)
        {
            if (valor.Length > 157)
                return valor.Substring(0, 157) + " ...";
            else
                return valor;
        }

        [MvcSiteMapNodeAttribute(DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.DestinoDetalleDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult DestinoDetalle(string url)
        {
            var v = _viajes.GetByUrl(url);

            if (v.Eliminado)
            {
                return RedirectPermanent(Url.RouteUrl(new
                                                        {
                                                            controller = "Tipo1",
                                                            action = "DestinoListado",
                                                            url = ((ViajeTipo1)v).Destino.Url
                                                        }));
            }

            ViewBag.palabra1 = "VIAJES A " + ((ViajeTipo1)v).Destino.Nombre.ToUpper();
            ViewBag.palabra2 = "VIAJE A " + ((ViajeTipo1)v).Destino.Nombre.ToUpper();
            ViewBag.palabra3 = "VIAJES A " + ((ViajeTipo1)v).Destino.Nombre.ToUpper();

            ViewBag.palabra3Link = Url.RouteUrl(new
            {
                controller = "Tipo1",
                action = "DestinoListado",
                url = ((ViajeTipo1)v).Destino.Url
            });

            ViewBag.menusseleccionado = ((ViajeTipo1)v).Destino.Url;

            ViewBag.palabra4 = "VIAJE A " + ((ViajeTipo1)v).Destino.Nombre.ToUpper();
            ViewBag.palabra5 = "días";
            ViewBag.palabraIntereses = "INTERESES DEL VIAJE";

            ViewBag.controller = "Tipo1";
            ViewBag.action = "DestinoDetalle";

            return View("Detalle", new ViewModels.Tipo1DetalleViewModel
            {
                Viaje = v
            });
        }

        
        //[MvcSiteMapNodeAttribute(ParentKey = "Home", Key = "PortadaCrucero", Title = "Cruceros destacados")]
        public ActionResult CruceroPortada()
        {
            return RedirectToActionPermanent("CruceroListado", "Tipo1");

            ViewBag.seccionId = 6;

            ViewBag.palabra = "CRUCEROS DE LUJO & EXCLUSIVOS";
            ViewBag.palabra2 = "VER TODOS LOS CRUCEROS";
            ViewBag.palabra3 = "CRUCEROS DE LUJO";
            ViewBag.menusseleccionado = "Crucero";

            ViewBag.link = Url.RouteUrl(new { controller = "Tipo1", action = "CruceroListado" });

            return View("Portada");
        }

        [MvcSiteMapNodeAttribute(ParentKey = "Home", Key = "ListadoCrucero", Title = "Cruceros")]
        public ActionResult CruceroListado()
        {
            ViewBag.seccionId = 7;

            ViewBag.palabra = "CRUCEROS DE LUJO & EXCLUSIVOS";
            ViewBag.palabra2 = "CRUCEROS";
            ViewBag.palabra3 = "CRUCERO DE LUJO";
            ViewBag.palabra4 = "VER CRUCERO";
            ViewBag.palabra5 = "días";
            ViewBag.palabra6 = "ciudades";

            ViewBag.controller = "Tipo1";
            ViewBag.action = "CruceroDetalle";
            ViewBag.menusseleccionado = "Crucero";


            var v = _viajes.Get(1, 2, null, null, null, null, null, null, null);

            var vjson = from a in v
                        select new
                        {
                            EsBannerContextual = false,
                            IdContextual = 0,
                            a.Id,
                            a.Nombre,
                            a.AltImagenListado,
                            a.ImagenListado,
                            a.Url,
                            ((ViajeTipo1)a).Paises,
                            Descripcion = this.achicar(HttpUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(a.Descripcion, @"<[^>]*>", String.Empty).Replace(Environment.NewLine, " "))),
                            ((ViajeTipo1)a).Duracion,
                            a.Precio,
                            DestinoNombre = ((ViajeTipo1)a).Destino.Nombre,
                            DestinoUrl = ((ViajeTipo1)a).Destino.Url,
                            ((ViajeTipo1)a).Ciudades,
                            Link = Url.RouteUrl(new { controller = ViewBag.controller, action = ViewBag.action, urlDestino = ((ViajeTipo1)a).Destino.Url, url = a.Url }),
                            Tags = from tt in a.TagsViaje
                                   where
                                      tt.Tag.Eliminado == false
                                   orderby
                                       tt.Orden
                                   select new
                                   {
                                       tt.TagId,
                                       tt.Tag.Nombre,
                                       tt.Tag.Url
                                   }

                        };


            Pagina p = _pagina.Get(ViewBag.seccionId, null, null, null, null, null);

            BannerContextual b = p.BannersContextual.FirstOrDefault();

            var vjson1 = vjson.ToList();

            if (b != null)
            {
                vjson1.Insert(0, new
                {
                    EsBannerContextual = true,
                    IdContextual = p.Id,
                    Id = -1,
                    Nombre = b.Title,
                    AltImagenListado = b.Alt,
                    ImagenListado = b.Foto,
                    Url = b.Link,
                    Paises = "",
                    Descripcion = "",
                    Duracion = 0,
                    Precio = 0,
                    DestinoNombre = "",
                    DestinoUrl = "",
                    Ciudades = "",
                    Link = b.Link,
                    Tags = from tt in new List<ViajeTag>()
                           select new
                           {
                               tt.TagId,
                               tt.Tag.Nombre,
                               tt.Tag.Url
                           }
                });
            }


            return View("Listado", new ViewModels.Tipo1ListadoViewModel
            {
                Viajes = v,
                ViajesJson = vjson1
            });
        }

        [MvcSiteMapNodeAttribute(ParentKey = "ListadoCrucero", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.CruceroDetalleDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult CruceroDetalle(string url)
        {
            var v = _viajes.GetByUrl(url);

            if (v.Eliminado)
            {
                return RedirectPermanent(Url.RouteUrl(new { controller = "Tipo1", action = "CruceroListado" }));
            }

            ViewBag.palabra1 = "CRUCEROS DE LUJO & EXCLUSIVOS";
            ViewBag.palabra2 = "CRUCERO";
            ViewBag.palabra3 = "VIAJES A " + ((ViajeTipo1)v).Destino.Nombre.ToUpper();
            ViewBag.menusseleccionado = "Crucero";
            ViewBag.palabra3Link = Url.RouteUrl(new
                                                {
                                                    controller = "Tipo1",
                                                    action = "DestinoListado",
                                                    url = ((ViajeTipo1)v).Destino.Url
                                                });
            ViewBag.palabra4 = "CRUCERO";
            ViewBag.palabra5 = "días";
            ViewBag.palabraIntereses = "INTERESES DEL CRUCERO";

            ViewBag.controller = "Tipo1";
            ViewBag.action = "DestinoDetalle";

            return View("Detalle", new ViewModels.Tipo1DetalleViewModel
            {
                Viaje = v
            });
        }

        
        //[MvcSiteMapNodeAttribute(ParentKey = "Home", Key = "PortadaTren", Title = "Trenes destacados")]
        public ActionResult TrenPortada()
        {
            return RedirectToActionPermanent("TrenListado", "Tipo1");

            ViewBag.seccionId = 10;

            ViewBag.palabra = "TRENES DE LUJO & EXCLUSIVOS";
            ViewBag.palabra2 = "VER TODOS LOS TRENES";
            ViewBag.palabra3 = "TRENES DE LUJO";
            ViewBag.menusseleccionado = "Tren";

            ViewBag.link = Url.RouteUrl(new { controller = "Tipo1", action = "TrenListado" });

            return View("Portada");
        }

        [MvcSiteMapNodeAttribute(ParentKey = "Home", Key = "ListadoTren", Title = "Trenes")]
        public ActionResult TrenListado()
        {
            ViewBag.seccionId = 11;

            ViewBag.palabra = "TRENES DE LUJO & EXCLUSIVOS";
            ViewBag.palabra2 = "TRENES";
            ViewBag.palabra3 = "TREN DE LUJO";
            ViewBag.palabra4 = "VER TREN";
            ViewBag.palabra5 = "días";
            ViewBag.palabra6 = "ciudades";
            
            ViewBag.controller = "Tipo1";
            ViewBag.action = "TrenDetalle";
            ViewBag.menusseleccionado = "Tren";

            var v = _viajes.Get(1, 3, null, null, null, null, null, null, null);
            
            var vjson = from a in v
                        select new
                        {
                            EsBannerContextual = false,
                            IdContextual = 0,
                            a.Id,
                            a.Nombre,
                            a.AltImagenListado,
                            a.ImagenListado,
                            a.Url,
                            ((ViajeTipo1)a).Paises,
                            Descripcion = this.achicar(HttpUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(a.Descripcion, @"<[^>]*>", String.Empty).Replace(Environment.NewLine, " "))),
                            ((ViajeTipo1)a).Duracion,
                            a.Precio,
                            DestinoNombre = ((ViajeTipo1)a).Destino.Nombre,
                            DestinoUrl = ((ViajeTipo1)a).Destino.Url,
                            ((ViajeTipo1)a).Ciudades,
                            Link = Url.RouteUrl(new { controller = ViewBag.controller, action = ViewBag.action, urlDestino = ((ViajeTipo1)a).Destino.Url, url = a.Url }),
                            Tags = from tt in a.TagsViaje
                                   where
                                      tt.Tag.Eliminado == false
                                   orderby
                                       tt.Orden
                                   select new
                                   {
                                       tt.TagId,
                                       tt.Tag.Nombre,
                                       tt.Tag.Url
                                   }

                        };

            Pagina p = _pagina.Get(ViewBag.seccionId, null, null, null, null, null);

            BannerContextual b = p.BannersContextual.FirstOrDefault();

            var vjson1 = vjson.ToList();

            if (b != null)
            {
                vjson1.Insert(0, new
                {
                    EsBannerContextual = true,
                    IdContextual = p.Id,
                    Id = -1,
                    Nombre = b.Title,
                    AltImagenListado = b.Alt,
                    ImagenListado = b.Foto,
                    Url = b.Link,
                    Paises = "",
                    Descripcion = "",
                    Duracion = 0,
                    Precio = 0,
                    DestinoNombre = "",
                    DestinoUrl = "",
                    Ciudades = "",
                    Link = b.Link,
                    Tags = from tt in new List<ViajeTag>()
                           select new
                           {
                               tt.TagId,
                               tt.Tag.Nombre,
                               tt.Tag.Url
                           }
                });
            }


            return View("Listado", new ViewModels.Tipo1ListadoViewModel
            {
                Viajes = v,
                ViajesJson = vjson1
            });
        }

        [MvcSiteMapNodeAttribute(ParentKey = "ListadoTren", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.TrenDetalleDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult TrenDetalle(string url)
        {
            var v = _viajes.GetByUrl(url);

            if (v.Eliminado)
            {
                return RedirectPermanent(Url.RouteUrl(new { controller = "Tipo1", action = "TrenListado" }));
            }

            ViewBag.palabra1 = "TRENES DE LUJO & EXCLUSIVOS";
            ViewBag.palabra2 = "TREN";
            ViewBag.palabra3 = "VIAJES A MEDIDA";
            ViewBag.menusseleccionado = "Tren";

            ViewBag.palabra3Link = Url.RouteUrl(new
                                    {
                                        controller = "Tipo1",
                                        action = "InteresListado",
                                        url = "viajes-a-medida"
                                    });
            ViewBag.palabra4 = "ITINERARIO EN TREN";
            ViewBag.palabra5 = "días";
            ViewBag.palabraIntereses = "INTERESES DE ESTE ITINERARIO EN TREN";

            ViewBag.controller = "Tipo1";
            ViewBag.action = "DestinoDetalle";

            return View("Detalle", new ViewModels.Tipo1DetalleViewModel
            {
                Viaje = v
            });
        }

        //[MvcSiteMapNodeAttribute(ParentKey = "Home", Key = "PortadaWellnes", Title = "Wellness & Spa destacados")]
        public ActionResult WellnesPortada()
        {
            return RedirectToActionPermanent("WellnesListado", "Tipo1");

            ViewBag.seccionId = 28;

            ViewBag.palabra = "WELLNESS & SPA";
            ViewBag.palabra2 = "VER TODOS LOS PROGRAMAS WELLNESS & SPA";
            ViewBag.palabra3 = "PROGRAMAS WELLNESS & SPA";
            ViewBag.menusseleccionado = "Wellnes";

            ViewBag.link = Url.RouteUrl(new { controller = "Tipo1", action = "WellnesListado" });

            return View("Portada");
        }

        [MvcSiteMapNodeAttribute(ParentKey = "Home", Key = "ListadoWellnes", Title = "Wellness & Spa")]
        public ActionResult WellnesListado()
        {
            ViewBag.seccionId = 29;

            ViewBag.palabra = "WELLNESS & SPA";
            ViewBag.palabra2 = "PROGRAMAS WELLNESS & SPA";
            ViewBag.palabra3 = "WELLNESS & SPA";
            ViewBag.palabra4 = "VER DETALLE";
            ViewBag.palabra5 = "noches";
            ViewBag.palabra6 = "ciudad";

            ViewBag.controller = "Tipo1";
            ViewBag.action = "WellnesDetalle";
            ViewBag.menusseleccionado = "Wellnes";


            var v = _viajes.Get(1, 4, null, null, null, null, null, null, null);

            var vjson = from a in v
                        select new
                        {
                            EsBannerContextual = false,
                            IdContextual = 0,
                            a.Id,
                            a.Nombre,
                            a.AltImagenListado,
                            a.ImagenListado,
                            a.Url,
                            ((ViajeTipo1)a).Paises,
                            Descripcion = this.achicar(HttpUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(a.Descripcion, @"<[^>]*>", String.Empty).Replace(Environment.NewLine, " "))),
                            ((ViajeTipo1)a).Duracion,
                            a.Precio,
                            DestinoNombre = ((ViajeTipo1)a).Destino.Nombre,
                            DestinoUrl = ((ViajeTipo1)a).Destino.Url,
                            ((ViajeTipo1)a).Ciudades,
                            Link = Url.RouteUrl(new { controller = ViewBag.controller, action = ViewBag.action, urlDestino = ((ViajeTipo1)a).Destino.Url, url = a.Url }),
                            Tags = from tt in a.TagsViaje
                                   where
                                      tt.Tag.Eliminado == false
                                   orderby
                                       tt.Orden
                                   select new
                                   {
                                       tt.TagId,
                                       tt.Tag.Nombre,
                                       tt.Tag.Url
                                   }

                        };


            Pagina p = _pagina.Get(ViewBag.seccionId, null, null, null, null, null);

            BannerContextual b = p.BannersContextual.FirstOrDefault();

            var vjson1 = vjson.ToList();

            if (b != null)
            {
                vjson1.Insert(0, new
                {
                    EsBannerContextual = true,
                    IdContextual = p.Id,
                    Id = -1,
                    Nombre = b.Title,
                    AltImagenListado = b.Alt,
                    ImagenListado = b.Foto,
                    Url = b.Link,
                    Paises = "",
                    Descripcion = "",
                    Duracion = 0,
                    Precio = 0,
                    DestinoNombre = "",
                    DestinoUrl = "",
                    Ciudades = "",
                    Link = b.Link,
                    Tags = from tt in new List<ViajeTag>()
                           select new
                           {
                               tt.TagId,
                               tt.Tag.Nombre,
                               tt.Tag.Url
                           }
                });
            }


            return View("Listado", new ViewModels.Tipo1ListadoViewModel
            {
                Viajes = v,
                ViajesJson = vjson1
            });
        }

        [MvcSiteMapNodeAttribute(ParentKey = "ListadoWellnes", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.WellnesDetalleDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult WellnesDetalle(string url)
        {
            var v = _viajes.GetByUrl(url);

            if (v.Eliminado)
            {
                return RedirectPermanent(Url.RouteUrl(new { controller = "Tipo1", action = "WellnesListado" }));
            }

            ViewBag.palabra1 = "VIAJES WELLNESS & SPA";
            ViewBag.palabra2 = "WELLNESS & SPA";
            ViewBag.palabra3 = "VIAJES WELLNESS & SPA";
            ViewBag.menusseleccionado = "Wellnes";
            ViewBag.palabra3Link = Url.RouteUrl(new
            {
                controller = "Tipo1",
                action = "DestinoListado",
                url = ((ViajeTipo1)v).Destino.Url
            });
            ViewBag.palabra4 = "PROGRAMA";
            ViewBag.palabra5 = "noches";
            ViewBag.palabraIntereses = "INTERESES DEL PROGRAMA WELLNESS & SPA";

            ViewBag.controller = "Tipo1";
            ViewBag.action = "DestinoDetalle";

            return View("Detalle", new ViewModels.Tipo1DetalleViewModel
            {
                Viaje = v
            });
        }
    }
}