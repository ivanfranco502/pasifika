using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class TagData : ITagData
    {
        private readonly PasifikaDbContext _db;

        public TagData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Tag> Get()
        {
            var q = from t in _db.Tags
                    where
                        t.Eliminado == false
                    select t;

            return q.ToList();
        }

        public Tag Get(int Id)
        {
            var q = from t in _db.Tags
                    where   
                        t.Id == Id
                    select t;

            return q.FirstOrDefault();
        }

        public Tag GetByUrl(string url)
        {
            var q = from t in _db.Tags
                    where
                        t.Url == url
                    select t;

            return q.FirstOrDefault();
        }

        public void Add(Tag tag)
        {
            _db.Tags.Add(tag);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
