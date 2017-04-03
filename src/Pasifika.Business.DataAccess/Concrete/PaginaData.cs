using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class PaginaData : IPaginaData
    {
        private readonly PasifikaDbContext _db;

        public PaginaData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Pagina> Get()
        {
            var q = from p in _db.Paginas
                    where
                        p.ViajeId == null && p.NotaId == null
                        && p.Eliminado == false
                    orderby 
                        p.Orden
                    select p;

            return q.ToList();
        }

        public Pagina Get(int id)
        {
            var q = from p in _db.Paginas
                    where
                        p.Id == id
                        && p.Eliminado == false
                    select p;
                    

            return q.FirstOrDefault();
        }

        public Pagina Get(int? SeccionId, int? ViajeId, int? NotaId, int? DestinoId, int? TagId, int? RegionId)
        {
            var q = from p in _db.Paginas
                    where
                        ((NotaId.HasValue && p.NotaId == NotaId) || !NotaId.HasValue)
                        && ((ViajeId.HasValue && p.ViajeId == ViajeId) || !ViajeId.HasValue)
                        && ((SeccionId.HasValue && p.SeccionId == SeccionId) || !SeccionId.HasValue)
                        && ((DestinoId.HasValue && p.DestinoId == DestinoId) || !DestinoId.HasValue)
                        && ((TagId.HasValue && p.TagId == TagId) || !TagId.HasValue)
                        && ((RegionId.HasValue && p.RegionId == RegionId) || !RegionId.HasValue)
                        && p.Eliminado == false
                    orderby
                        p.Orden
                    select p;


            return q.FirstOrDefault();
        }

        public Pagina GetBySeccion(int id)
        {
            var q = from p in _db.Paginas
                    where
                        p.Seccion.Id == id
                        && p.Eliminado == false
                    select p;


            return q.FirstOrDefault();
        }

        public Pagina GetByViaje(int id)
        {
            var q = from p in _db.Paginas
                    where
                        p.Viaje.Id == id
                        && p.Eliminado == false
                    select p;


            return q.FirstOrDefault();
        }

        public Pagina GetByNota(int id)
        {
            var q = from p in _db.Paginas
                    where
                        p.Nota.Id == id
                        && p.Eliminado == false
                    select p;


            return q.FirstOrDefault();
        }

        public void Add(Pagina p)
        {
            _db.Paginas.Add(p);
            _db.SaveChanges();
        }

        public void Remove(Banner b)
        {
            _db.Banners.Remove(b);
        }

        public void RemoveBannerContextual(int id)
        {
            BannerContextual banner = (from b in _db.BannersContextual
                    where b.Id == id
                    select b).FirstOrDefault();

            if (banner != null)
            {
                var p = Get(banner.PaginaId);
                _db.BannersContextual.Remove(banner);
                p.BannersContextual.Remove(banner);
                _db.SaveChanges();
            }

        }

        public void Remove(BannerInferior b)
        {
            _db.BannersInferiores.Remove(b);
        }

        public void Remove(Destacado d)
        {
            _db.Destacados.Remove(d);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
