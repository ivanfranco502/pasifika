using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class RegionData : IRegionData
    {
        private readonly PasifikaDbContext _db;

        public RegionData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Region> Get()
        {
            var q = from p in _db.Regiones
                    where
                        p.Eliminado == false
                    select p;

            return q.ToList();
        }

        public Region Get(int id)
        {
            var q = from p in _db.Regiones
                    where
                        p.Id == id
                    select p;


            return q.FirstOrDefault();
        }

        public void Add(Region r)
        {
            _db.Regiones.Add(r);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
