using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class PrensaData : IPrensaData
    {
        private readonly PasifikaDbContext _db;

        public PrensaData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Prensa> Get()
        {
            var q = from p in _db.Prensas
                    orderby p.Fecha descending
                    where
                        p.Eliminado == false
                    select p;

            return q.ToList();
        }

        public Prensa Get(int id)
        {
            var q = from p in _db.Prensas
                    where
                        p.Id == id
                    select p;


            return q.FirstOrDefault();
        }

        public void Add(Prensa p)
        {
            _db.Prensas.Add(p);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
