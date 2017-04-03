using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Business.Abstract;
using Pasifika.Model;
using System.IO;
using Newtonsoft.Json;

namespace Pasifika.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class ViajeTipo1Controller : Controller
    {
        private readonly IViajeBusiness _viaje;
        private readonly ITagBusiness _tag;
        private readonly IDestinoBusiness _destino;

        public ViajeTipo1Controller(IViajeBusiness v, ITagBusiness t, IDestinoBusiness d)
        {
            this._viaje = v;
            this._tag = t;
            this._destino = d;
        }

        public ActionResult List(int TipoViaje, int SubTipoViaje)
        {
            var v = _viaje.Get(TipoViaje, SubTipoViaje);

            return View(new ViewModels.ViajeTipo1ListViewModel
            {
                Viajes = v,
                TipoViaje = TipoViaje,
                SubTipoViaje = SubTipoViaje
            });
        }

        public ViewResult Create(int TipoViaje, int SubTipoViaje)
        {
            object v = null;
            var d = _destino.Get();

            if (TipoViaje == 1 && SubTipoViaje == 1)
            {
                v = new Vuelo();
            }

            if (TipoViaje == 1 && SubTipoViaje == 2)
            {
                v = new Crucero();
            }

            if (TipoViaje == 1 && SubTipoViaje == 3)
            {
                v = new Tren();
            }

            if (TipoViaje == 1 && SubTipoViaje == 4)
            {
                v = new Wellnes();
            }

            if (TipoViaje == 2 && SubTipoViaje == 1)
            {
                v = new Hotel();
            }

            if (TipoViaje == 2 && SubTipoViaje == 2)
            {
                v = new Excursion();
            }

            var t = _tag.Get();
            return View("Edit", new ViewModels.ViajeTipo1EditViewModel
            {
                Viaje = v,
                Tags = t,
                TipoViaje = TipoViaje,
                SubTipoViaje = SubTipoViaje,
                Destinos = d
            });
        }

        public ViewResult Edit(int id)
        {
            var v = _viaje.Get(id);
            var t = _tag.Get();
            var d = _destino.Get();

            int TipoViaje = 0;
            int SubTipoViaje = 0;

            if (v is Pasifika.Model.Vuelo)
            {
                TipoViaje = 1;
                SubTipoViaje = 1;
            }

            if (v is Pasifika.Model.Crucero)
            {
                TipoViaje = 1;
                SubTipoViaje = 2;
            }

            if (v is Pasifika.Model.Wellnes)
            {
                TipoViaje = 1;
                SubTipoViaje = 4;
            }

            if (v is Pasifika.Model.Tren)
            {
                TipoViaje = 1;
                SubTipoViaje = 3;
            }

            if (v is Pasifika.Model.Hotel)
            {
                TipoViaje = 2;
                SubTipoViaje = 1;
            }

            if (v is Pasifika.Model.Excursion)
            {
                TipoViaje = 2;
                SubTipoViaje = 2;
            }

            return View(new ViewModels.ViajeTipo1EditViewModel
            {
                Viaje = v,
                Tags = t,
                TipoViaje = TipoViaje,
                SubTipoViaje = SubTipoViaje,
                Destinos = d
            });
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int Id, int TipoViaje, int SubTipoViaje, string Nombre, string Url, int? Duracion, int Precio, string InfoPrecio, string Paises, string Ciudades, string Referencia, string PDF, string ImagenListado, string AltImagenListado, string Tags, string txtJsonImagenes, string Descripcion, string Itinerario, string Alojamiento, string Actividades, string Translados, string CuandoIr, string Presupuesto, string Comentarios, int? DestinoId, int? CiudadId, string InformacionGeneral, string Importante, string Condicion, string NombreCrucero, string TituloCuadro, string TextoCuadro, HttpPostedFileBase filePDF = null, HttpPostedFileBase fileImagenListado = null, IEnumerable<HttpPostedFileBase> fileImagenes = null)
        {
            Stream ImagenListadoStream = null;
            if (fileImagenListado != null)
            {
                ImagenListadoStream = fileImagenListado.InputStream;
                ImagenListado = fileImagenListado.FileName;
            }
            if (ImagenListado == "")
                ImagenListado = null;

            Stream PDFStream = null;
            if (filePDF != null)
            {
                PDFStream = filePDF.InputStream;
                PDF = filePDF.FileName;
            }
            if (PDF == "")
                PDF = null;

            List<Foto> f = JsonConvert.DeserializeObject<List<Foto>>(txtJsonImagenes);
            int posFileImagenes = 0;
            foreach (Foto foto in f)
            {
                if (foto.Operacion == null || (foto.Operacion != null && foto.Operacion != "B"))
                {
                    if (foto.Id < 0)
                    {
                        if (fileImagenes.ElementAt(posFileImagenes) != null)
                        {
                            foto.Archivo = fileImagenes.ElementAt(posFileImagenes).FileName;
                            foto.Stream = fileImagenes.ElementAt(posFileImagenes).InputStream;
                        }
                        else
                            foto.Operacion = "B";

                        posFileImagenes++;
                    }
                }
            }

            _viaje.Guardar(Id, TipoViaje, SubTipoViaje, Nombre, Url, Duracion, Precio, InfoPrecio, Paises, Ciudades, Referencia, PDF, ImagenListado, AltImagenListado, Tags, f, Descripcion, Itinerario, Alojamiento, Actividades, Translados, CuandoIr, Presupuesto, Comentarios, DestinoId, CiudadId, InformacionGeneral, Importante, Condicion, NombreCrucero, TituloCuadro, TextoCuadro, Server.MapPath("~/Content/"), PDFStream, ImagenListadoStream);

            return RedirectToAction("List", new
            {
                TipoViaje = TipoViaje,
                SubTipoViaje = SubTipoViaje
            });
        }

        [HttpPost]
        public ActionResult Delete(int Id, int TipoViaje, int SubTipoViaje)
        {
            _viaje.Delete(Id);

            return RedirectToAction("List", new
            {
                TipoViaje = TipoViaje,
                SubTipoViaje = SubTipoViaje
            });
        }

        [HttpPost]
        public ActionResult Order(string txtJsonOrden, int TipoViaje, int SubTipoViaje)
        {
            _viaje.Order(txtJsonOrden);

            return RedirectToAction("List", new
            {
                TipoViaje = TipoViaje,
                SubTipoViaje = SubTipoViaje
            });
        }
    }
}