using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pasifika.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "",
                url: "",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
                name: "quienesSomos",
                url: "quienes-somos",
                defaults: new { controller = "QuienesSomos", action = "Index" },
                namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "guias",
               url: "guias-de-viaje",
               defaults: new { controller = "Guias", action = "Index" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "guiasDetalle",
               url: "guia-de-viaje-de-{destino}",
               defaults: new { controller = "Guias", action = "Detalle" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "colaboraderes",
               url: "colaboradores",
               defaults: new { controller = "Colaboradores", action = "Index" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "notas",
               url: "notas",
               defaults: new { controller = "Notas", action = "Index" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );
            
            routes.MapRoute(
               name: "notasFecha",
               url: "notas/{ano}/{mes}",
               defaults: new { controller = "Notas", action = "IndexAnoMes" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "notasDetalle",
               url: "notas/{url}",
               defaults: new { controller = "Notas", action = "Detalle" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "promociones",
               url: "promociones",
               defaults: new { controller = "Promociones", action = "Index" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "prensa",
               url: "prensa",
               defaults: new { controller = "Prensa", action = "Index" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            //www.pasifika.es/viajes-a-medida
            //www.pasifika.es/viajes/viajes-a-medida

            //www.pasifika.es/viajes-a-australia
            //www.pasifika.es/destinos/viajes-a-australia

            routes.MapRoute(
               name: "interesPortada",
               url: "categoria/destacados/{url}",
               defaults: new { controller = "Tipo1", action = "InteresPortada" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "interesListado",
               url: "categoria/{url}",
               defaults: new { controller = "Tipo1", action = "InteresListado" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "DestinoPortada",
               url: "viajes/destacados/viajes-a-{url}",
               defaults: new { controller = "Tipo1", action = "DestinoPortada" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "DestinoListado",
               url: "viajes/viajes-a-{url}",
               defaults: new { controller = "Tipo1", action = "DestinoListado" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "DestinoDetalle",
               url: "viajes/viajes-a-{urlDestino}/{url}",
               defaults: new { controller = "Tipo1", action = "DestinoDetalle" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "cruceroPortada",
               url: "cruceros-de-lujo/destacados",
               defaults: new { controller = "Tipo1", action = "CruceroPortada" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "cruceroListado",
               url: "cruceros-de-lujo",
               defaults: new { controller = "Tipo1", action = "CruceroListado" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "cruceroDetalle",
               url: "cruceros/cruceros-de-lujo-{urlDestino}/{url}",
               defaults: new { controller = "Tipo1", action = "CruceroDetalle" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "wellnesPortada",
               url: "wellness-spa/destacados",
               defaults: new { controller = "Tipo1", action = "WellnesPortada" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "wellnesListado",
               url: "wellness-spa",
               defaults: new { controller = "Tipo1", action = "WellnesListado" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "wellnesDetalle",
               url: "wellness-spa/wellness-spa-{urlDestino}/{url}",
               defaults: new { controller = "Tipo1", action = "WellnesDetalle" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "trenPortada",
               url: "trenes-de-lujo/destacados",
               defaults: new { controller = "Tipo1", action = "TrenPortada" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "trenListado",
               url: "trenes-de-lujo",
               defaults: new { controller = "Tipo1", action = "TrenListado" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "trenDetalle",
               url: "trenes/trenes-de-lujo-{urlDestino}/{url}",
               defaults: new { controller = "Tipo1", action = "TrenDetalle" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "hotelPortada",
               url: "hoteles-de-lujo",
               defaults: new { controller = "Tipo2", action = "HotelPortada" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "hotelListadoRedirect",
               url: "hoteles-de-lujo/hoteles-de-lujo-en-{url}",
               defaults: new { controller = "Tipo2", action = "HotelListadoRedirect" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "hotelListado",
               url: "hoteles-de-lujo/{url}",
               defaults: new { controller = "Tipo2", action = "HotelListado" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "hotelDetalleRedirect",
               url: "hoteles-de-lujo/hoteles-en-{urlDestino}/hoteles-en-{urlCiudad}/{url}",
               defaults: new { controller = "Tipo2", action = "HotelDetalleRedirect" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "hotelDetalle",
               url: "hoteles-de-lujo/{urlDestino}/{urlCiudad}/{url}",
               defaults: new { controller = "Tipo2", action = "HotelDetalle" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "excursionPortada",
               url: "excursiones",
               defaults: new { controller = "Tipo2", action = "ExcursionPortada" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "excursionListadoRedirect",
               url: "excursiones/excursiones-en-{url}",
               defaults: new { controller = "Tipo2", action = "ExcursionListadoRedirect" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "excursionListado",
               url: "excursiones/{url}",
               defaults: new { controller = "Tipo2", action = "ExcursionListado" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "excursionDetalleRedirect",
               url: "excursiones/excursion-en-{urlDestino}/{urlCiudad}/{url}",
               defaults: new { controller = "Tipo2", action = "ExcursionDetalleRedirect" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "excursionDetalle",
               url: "excursiones/{urlDestino}/{urlCiudad}/{url}",
               defaults: new { controller = "Tipo2", action = "ExcursionDetalle" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "contacto",
               url: "contacto",
               defaults: new { controller = "Formulario", action = "Index", tipo = 1 },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "catalogo",
               url: "catalogo",
               defaults: new { controller = "Formulario", action = "Index", tipo = 2 },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "seminario",
               url: "seminario",
               defaults: new { controller = "Formulario", action = "Index", tipo = 3 },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "compartir",
               url: "compartir",
               defaults: new { controller = "Formulario", action = "Compartir" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "baja",
               url: "baja",
               defaults: new { controller = "Formulario", action = "Baja" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
               name: "downloadCatalogo",
               url: "download-catalogo/{id}",
               defaults: new { controller = "Formulario", action = "DownloadCatalogo" },
               namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );

            routes.MapRoute(
                name: "busquedaIndex",
                url: "busqueda",
                defaults: new { controller = "Busqueda", action = "Index" },
                namespaces: new[] { "Pasifika.WebUI.Controllers" }
             );

            routes.MapRoute(
                name: "busqueda",
                url: "busqueda/{texto}/{pagina}",
                defaults: new { controller = "Busqueda", action = "List", pagina = UrlParameter.Optional },
                namespaces: new[] { "Pasifika.WebUI.Controllers" }
             );
            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Pasifika.WebUI.Controllers" }
            );
            */

            routes.MapRoute(null, "{controller}/{action}", new[] { "Pasifika.WebUI.Controllers" });

 
        }
    }
}
