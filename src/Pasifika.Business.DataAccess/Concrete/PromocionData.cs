using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class PromocionData : IPromocionData
    {
        private readonly PasifikaDbContext _db;

        public PromocionData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Promocion> Get()
        {
            var q = from p in _db.Promociones
                    where
                        p.Eliminado == false
                    select p;

            return q.ToList();
        }

        public Promocion Get(int id)
        {
            var q = from p in _db.Promociones
                    where
                        p.Id == id
                    select p;


            return q.FirstOrDefault();
        }

        public void Add(Promocion s)
        {
            _db.Promociones.Add(s);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
