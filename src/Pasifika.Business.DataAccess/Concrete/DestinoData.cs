using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class DestinoData : IDestinoData
    {
        private readonly PasifikaDbContext _db;

        public DestinoData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Destino> GetByRegion(int regionId)
        {
            var q = from d in _db.Destinos
                    where
                        d.Eliminado == false
                        && d.Region.Id == regionId
                    orderby
                        d.Orden
                    select d;

            return q.ToList();
        }

        public Destino GetByUrl(string url)
        {
            var q = from d in _db.Destinos
                    where
                        d.Eliminado == false
                        && d.Url == url
                    select d;

            return q.FirstOrDefault();
        }

        public List<Destino> Get()
        {
            var q = from d in _db.Destinos
                    where
                        d.Eliminado == false
                    orderby
                        d.Orden
                    select d;

            return q.ToList();
        }

        public Destino Get(int id)
        {
            var q = from d in _db.Destinos
                    where
                        d.Id == id
                        && d.Eliminado == false
                    select d;
                    

            return q.FirstOrDefault();
        }

        public void Add(Destino d)
        {
            _db.Destinos.Add(d);
            _db.SaveChanges();
        }

        public void Remove(DestinoTitulo d)
        {
            _db.DestinosTitulos.Remove(d);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
