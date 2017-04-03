using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class SeccionData : ISeccionData
    {
        private readonly PasifikaDbContext _db;

        public SeccionData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Seccion> Get()
        {
            var q = from s in _db.Secciones
                    select s;

            return q.ToList();
        }
    }
}
