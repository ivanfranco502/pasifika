using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class CiudadData : ICiudadData
    {
        private readonly PasifikaDbContext _db;

        public CiudadData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Ciudad> GetByDestino(int destinoId)
        {
            var q = from c in _db.Ciudades
                    where
                        c.Eliminado == false
                        && c.Destino.Id == destinoId
                    select c;

            return q.ToList();
        }

        public Ciudad Get(int id)
        {
            var q = from c in _db.Ciudades
                    where
                        c.Id == id
                        && c.Eliminado == false
                    select c;
                    

            return q.FirstOrDefault();
        }

        public void Add(Ciudad c)
        {
            _db.Ciudades.Add(c);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
