using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.Abstract;
using Pasifika.Model;
using Pasifika.Business.DataAccess.Abstract;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Pasifika.Business.Concrete
{
    public class ViajeBusiness : IViajeBusiness
    {
        private readonly IViajeData _viaje;
        private readonly ITagData _tag;

        public ViajeBusiness(IViajeData v, ITagData t)
        {
            this._viaje = v;
            this._tag = t;
        }

        public List<Viaje> Get()
        {
            return _viaje.Get();
        }

        public List<Viaje> Get(int TipoViaje, int SubTipoViaje)
        {
            return _viaje.Get(TipoViaje, SubTipoViaje);
        }

        public List<Viaje> Get(int TipoViaje, int SubTipoViaje, int? presupuestoDesde, int? presupuestoHasta, int? duracionDesde, int? duracionHasta, List<int> tags, int? destinoId, int? ciudadId)
        {
            return _viaje.Get(TipoViaje, SubTipoViaje, presupuestoDesde, presupuestoHasta, duracionDesde, duracionHasta, tags, destinoId, ciudadId);
        }

        public Viaje Get(int id)
        {
            return _viaje.Get(id);
        }

        public Viaje GetByUrl(string url)
        {
            return _viaje.GetByUrl(url);
        }

        public void Guardar(int Id, int TipoViaje, int SubTipoViaje, string Nombre, string Url, int? Duracion, int Precio, string InfoPrecio, string Paises, string Ciudades, string Referencia, string PDF, string ImagenListado, string AltImagenListado, string Tags, List<Foto> Fotos, string Descripcion, string Itinerario, string Alojamiento, string Actividades, string Translados, string CuandoIr, string Presupuesto, string Comentarios, int? DestinoId, int? CiudadId, string InformacionGeneral, string Importante, string Condicion, string NombreCrucero, string TituloCuadro, string TextoCuadro, string directorio, Stream filePDF = null, Stream fileImagenListado = null)
        {
            object v = _viaje.Get(Id);


            if (TipoViaje == 1 && SubTipoViaje == 1)
            {
                if (v == null)
                    v = new Vuelo();
            }

            if (TipoViaje == 1 && SubTipoViaje == 2)
            {
                if (v == null)
                    v = new Crucero();
            }

            if (TipoViaje == 1 && SubTipoViaje == 3)
            {
                if (v == null)
                    v = new Tren();
            }

            if (TipoViaje == 1 && SubTipoViaje == 4)
            {
                if (v == null)
                    v = new Wellnes();
            }

            if (TipoViaje == 2 && SubTipoViaje == 1)
            {
                if (v == null)
                    v = new Hotel();
            }

            if (TipoViaje == 2 && SubTipoViaje == 2)
            {
                if (v == null)
                    v = new Excursion();
            }

            ((Viaje)v).Id = Id;
            ((Viaje)v).Nombre = Nombre;
            ((Viaje)v).Url = Url;

            ((Viaje)v).Precio = Precio;
            ((Viaje)v).InfoPrecio = InfoPrecio;
            ((Viaje)v).Referencia = Referencia;
            ((Viaje)v).Descripcion = Descripcion;

            ((Viaje)v).AltImagenListado = AltImagenListado;

            ((Viaje)v).TituloCuadro = TituloCuadro;
            ((Viaje)v).TextoCuadro = TextoCuadro;

            if (TipoViaje == 1)
            {
                ((ViajeTipo1)v).Duracion = Duracion.Value;
                ((ViajeTipo1)v).Paises = Paises;
                ((ViajeTipo1)v).Ciudades = Ciudades;
                ((ViajeTipo1)v).Itinerario = Itinerario;
                ((ViajeTipo1)v).Alojamiento = Alojamiento;
                ((ViajeTipo1)v).Actividades = Actividades;
                ((ViajeTipo1)v).Translados = Translados;
                ((ViajeTipo1)v).CuandoIr = CuandoIr;
                ((ViajeTipo1)v).Presupuesto = Presupuesto;
                ((ViajeTipo1)v).Comentarios = Comentarios;
                ((ViajeTipo1)v).DestinoId = DestinoId.Value;
            }

            if (TipoViaje == 2)
            {
                ((ViajeTipo2)v).CiudadId = CiudadId.Value;
                ((ViajeTipo2)v).InformacionGeneral = InformacionGeneral;
                ((ViajeTipo2)v).Importante = Importante;
                ((ViajeTipo2)v).Condicion = Condicion;
            }

            if (TipoViaje == 1 && SubTipoViaje == 2)
            {
                ((Crucero)v).NombreCrucero = NombreCrucero;
            }

            //creo los tags
            var t = _tag.Get();
            string[] tagVec = Tags.Split(',');

            ((Viaje)v).TagsViaje.Clear();

            if (Tags != "")
            {
                Tag tNew;
                int orden = 1;
                foreach (string tag in tagVec)
                {
                    var tt = t.Where(c => c.Id.ToString() == tag).FirstOrDefault();
                    if (tt != null)
                    {
                        tNew = tt;
                    }
                    else
                    {
                        tNew = new Tag();
                        tNew.Nombre = tag;
                    }

                    ((Viaje)v).TagsViaje.Add(new ViajeTag
                    {
                        Tag = tNew,
                        Orden = orden
                    });
                    orden++;
                }
            }

            if (filePDF != null)
            {
                using (var fileStream = File.Create(directorio + "/images/pdf/" + PDF))
                {
                    filePDF.CopyTo(fileStream);
                }
            }
            ((Viaje)v).PDF = PDF;

            if (fileImagenListado != null)
            {
                using (var fileStream = File.Create(directorio + "/images/foto/listado/" + ImagenListado))
                {
                    fileImagenListado.CopyTo(fileStream);
                }
            }
            ((Viaje)v).ImagenListado = ImagenListado;

            foreach (var foto in Fotos)
            {
                if (foto.Id < 0)
                    foto.Operacion = "A";
                else
                    if (foto.Operacion == null)
                        foto.Operacion = "M";

                if (foto.Operacion == "A")
                {
                    foto.Id = 0;
                    ((Viaje)v).Fotos.Add(foto);

                    if (foto.Stream != null)
                    {
                        using (var fileStream = File.Create(directorio + "/images/foto/" + foto.Archivo))
                        {
                            foto.Stream.CopyTo(fileStream);
                        }
                    }
                }
                else
                {
                    if (foto.Operacion == "B")
                    {
                        var f = ((Viaje)v).Fotos.Where(x => x.Id == foto.Id).First();
                        _viaje.Remove(f);
                        ((Viaje)v).Fotos.Remove(f);
                    }
                    else
                    {
                        if (foto.Operacion == "M")
                        {
                            var f = ((Viaje)v).Fotos.Where(x => x.Id == foto.Id).First();
                            f.Orden = foto.Orden;
                            f.Alt = foto.Alt;
                        }
                    }
                }
            }

            if (Id == 0)
                _viaje.Add((Viaje)v);
            else
                _viaje.Save();            
        }

        public void Delete(int Id)
        {
            var v = _viaje.Get(Id);
            v.Eliminado = true;
            _viaje.Save();
        }

        public void Order(string jsonOrden)
        {
            JArray ids = JArray.Parse(jsonOrden);
            int orden = 0;
            foreach (JValue id in ids)
            {
                var p = _viaje.Get(int.Parse((string)id.Value));
                p.Orden = orden;
                orden++;
            }

            _viaje.Save();
        }
    }
}
