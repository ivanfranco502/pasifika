using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;
using Pasifika.Business.DataAccess.Abstract;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class PartnerData : IPartnerData
    {
        private readonly PasifikaDbContext _db;

        public PartnerData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Partner> Get()
        {
            var q = from p in _db.Partners
                    where
                        p.Eliminado == false
                    orderby 
                        p.Orden
                    select p;

            return q.ToList();
        }

        public Partner Get(int id)
        {
            var q = from p in _db.Partners
                    where
                        p.Id == id
                    select p;
                    

            return q.FirstOrDefault();
        }

        public void Add(Partner p)
        {
            _db.Partners.Add(p);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
