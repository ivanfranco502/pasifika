using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class ViajeData : IViajeData
    {
        private readonly PasifikaDbContext _db;

        public ViajeData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Viaje> Get()
        {
            var q = from v in _db.Viajes
                    orderby
                        v.Orden
                    where
                        v.Eliminado == false
                        //&& v is ViajeTipo1
                    select v;

            return q.ToList();
        }

        public List<Viaje> Get(int TipoViaje, int SubTipoViaje)
        {
            var q = from v in _db.Viajes
                    orderby
                        v.Orden
                    where
                        v.Eliminado == false
                        && ((v is Vuelo && TipoViaje == 1 && SubTipoViaje == 1)
                        || (v is Crucero && TipoViaje == 1 && SubTipoViaje == 2)
                        || (v is Tren && TipoViaje == 1 && SubTipoViaje == 3)
                        || (v is Wellnes && TipoViaje == 1 && SubTipoViaje == 4)
                        || (v is Hotel && TipoViaje == 2 && SubTipoViaje == 1)
                        || (v is Excursion && TipoViaje == 2 && SubTipoViaje == 2))
                    select v;

            return q.ToList();
        }

        public List<Viaje> Get(int TipoViaje, int SubTipoViaje, int? presupuestoDesde, int? presupuestoHasta, int? duracionDesde, int? duracionHasta, List<int> tags, int? destinoId, int? ciudadId)
        {
            if (tags == null)
                tags = new List<int>();
            
            var q = from v in _db.Viajes
                    orderby
                        v.Orden
                    where
                        v.Eliminado == false
                        && ((v is Vuelo && TipoViaje == 1 && SubTipoViaje == 1)
                        || (v is Crucero && TipoViaje == 1 && SubTipoViaje == 2)
                        || (v is Tren && TipoViaje == 1 && SubTipoViaje == 3)
                        || (v is Wellnes && TipoViaje == 1 && SubTipoViaje == 4)
                        || (v is Hotel && TipoViaje == 2 && SubTipoViaje == 1)
                        || (v is Excursion && TipoViaje == 2 && SubTipoViaje == 2))
                        && ((presupuestoDesde.HasValue && v.Precio >= presupuestoDesde.Value) || !presupuestoDesde.HasValue)
                        && ((presupuestoHasta.HasValue && v.Precio <= presupuestoHasta.Value) || !presupuestoHasta.HasValue)
                        && ((duracionDesde.HasValue && v is ViajeTipo1 && (v as ViajeTipo1).Duracion >= duracionDesde.Value && (v as ViajeTipo1).Duracion <= duracionHasta.Value) || !duracionDesde.HasValue)
                        && ((destinoId.HasValue && (v is ViajeTipo1 && (v as ViajeTipo1).DestinoId == destinoId.Value || v is ViajeTipo2 && (v as ViajeTipo2).Ciudad.DestinoId == destinoId.Value)) || !destinoId.HasValue)
                        //&& ((destinoId.HasValue && v is ViajeTipo2 && (v as ViajeTipo2).Ciudad.DestinoId == destinoId.Value) || !destinoId.HasValue)
                        && ((ciudadId.HasValue && v is ViajeTipo2 && (v as ViajeTipo2).CiudadId == ciudadId.Value) || !ciudadId.HasValue)
                        && (v.TagsViaje.Any(x => tags.Contains(x.TagId)) || tags.Count == 0) 
                        
                    select v;

            return q.ToList();
        }

        public Viaje Get(int id)
        {
            var q = from v in _db.Viajes
                    where
                        v.Id == id
                    select v;

            return q.FirstOrDefault();
        }

        public Viaje GetByUrl(string url)
        {
            var q = from v in _db.Viajes
                    where
                        v.Url == url
                    select v;

            return q.FirstOrDefault();
        }

        public void Add(Viaje v)
        {
            _db.Viajes.Add(v);
            _db.SaveChanges();
        }

        public void Remove(Foto f)
        {
            _db.Fotos.Remove(f);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
