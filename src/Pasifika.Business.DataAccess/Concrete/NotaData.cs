using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class NotaData : INotaData
    {
        private readonly PasifikaDbContext _db;

        public NotaData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Nota> Get(int? ano, int? mes, bool? visible)
        {
            var q = from n in _db.Notas
                    where
                        n.Eliminado == false
                        && ((visible.HasValue && n.Visible == visible) || !visible.HasValue)
                        && ((ano.HasValue && n.Fecha.Year == ano.Value) || !ano.HasValue)
                        && ((mes.HasValue && n.Fecha.Month == mes.Value) || !mes.HasValue)
                    orderby
                        n.Fecha descending
                    select n;

            return q.ToList();
        }

        public List<Nota> GetPaginado(int? ano, int? mes, bool? visible, int pageIndex, int pageSize)
        {
            var q = from n in _db.Notas
                    where
                        n.Eliminado == false
                        && ((visible.HasValue && n.Visible == visible) || !visible.HasValue)
                        && ((ano.HasValue && n.Fecha.Year == ano.Value) || !ano.HasValue)
                        && ((mes.HasValue && n.Fecha.Month == mes.Value) || !mes.HasValue)
                    orderby
                        n.Fecha descending
                    select n;

            var result =  q.ToList();

            pageIndex -= 1;

            int size = pageSize;

            if (((pageSize * pageIndex) + pageSize) > result.Count())
                size = result.Count() - (pageSize * pageIndex);

            result = result.GetRange(pageIndex * pageSize, size);

            return result;

        }

        public List<Nota> GetPublicas()
        {
            var q = from n in _db.Notas
                    where
                        n.Eliminado == false
                        && n.Visible == true
                    orderby
                        n.Fecha descending
                    select n;

            return q.ToList();
        }

        public List<Nota> GetPrensa()
        {
            var q = from n in _db.Notas
                    where
                        n.Eliminado == false
                        && n.EnPrensa == true
                    orderby
                        n.Fecha descending
                    select n;

            return q.ToList();
        }

        public Nota Get(int id)
        {
            var q = from n in _db.Notas
                    where 
                        n.Id == id
                    select n;

            return q.FirstOrDefault();
        }

        public Nota GetByUrl(string url)
        {
            var q = from n in _db.Notas
                    where
                        n.Url == url
                        && n.Eliminado == false
                    select n;

            return q.FirstOrDefault();
        }

        public void Add(Nota n)
        {
            _db.Notas.Add(n);
            _db.SaveChanges();
        }

        public void Update(Nota n)
        {
            _db.Notas.Attach(n);
            _db.Entry(n).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
