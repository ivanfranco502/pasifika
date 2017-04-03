using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class FormularioSesionData : IFormularioSesionData
    {
        private readonly PasifikaDbContext _db;

        public FormularioSesionData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<FormularioSesion> Get()
        {
            var q = from p in _db.FormularioSesiones
                    select p;

            return q.ToList();
        }

        public FormularioSesion Get(int id)
        {
            var q = from p in _db.FormularioSesiones
                    where
                        p.Id == id
                    select p;
                    

            return q.FirstOrDefault();
        }

        public void Add(FormularioSesion p)
        {
            _db.FormularioSesiones.Add(p);
            _db.SaveChanges();
        }

        public void Remove(FormularioSesion b)
        {
            _db.FormularioSesiones.Remove(b);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
