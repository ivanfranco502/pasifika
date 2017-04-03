using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class BannerHomeData : IBannerHomeData
    {
        private readonly PasifikaDbContext _db;

        public BannerHomeData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<BannerHome> Get()
        {
            var q = from b in _db.BannersHome
                    where
                        b.Eliminado == false
                    select b;

            return q.ToList();
        }

        public BannerHome GetMostrar()
        {
            var q = from b in _db.BannersHome
                    where
                        b.Eliminado == false
                        && b.Mostrar == true
                    select b;

            return q.FirstOrDefault();
        }

        public BannerHome Get(int id)
        {
            var q = from b in _db.BannersHome
                    where
                        b.Id == id
                    select b;

            return q.FirstOrDefault();
        }

        public void Add(BannerHome b)
        {
            _db.BannersHome.Add(b);
            _db.SaveChanges();
        }

        public void Update(BannerHome b)
        {
            _db.BannersHome.Attach(b);
            _db.Entry(b).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
