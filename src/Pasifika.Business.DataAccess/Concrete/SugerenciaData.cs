using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class SugerenciaData : ISugerenciaData
    {
        private readonly PasifikaDbContext _db;

        public SugerenciaData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Sugerencia> Get()
        {
            var q = from s in _db.Sugerencias
                    where
                        s.Eliminado == false
                    select s;

            return q.ToList();
        }

        public Sugerencia Get(int id)
        {
            var q = from s in _db.Sugerencias
                    where
                        s.Id == id
                    select s;


            return q.FirstOrDefault();
        }

        public void Add(Sugerencia s)
        {
            _db.Sugerencias.Add(s);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
