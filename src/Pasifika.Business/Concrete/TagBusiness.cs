using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.Abstract;
using Pasifika.Model;
using Pasifika.Business.DataAccess.Abstract;

namespace Pasifika.Business.Concrete
{
    public class TagBusiness : ITagBusiness
    {
        private readonly ITagData _tag;

        public TagBusiness(ITagData t)
        {
            this._tag = t;
        }

        public List<Tag> Get()
        {
            return _tag.Get();
        }

        public Tag Get(int Id)
        {
            return _tag.Get(Id);
        }

        public Tag GetByUrl(string url)
        {
            return _tag.GetByUrl(url);
        }

        public void Guardar(Tag tag)
        {
            if (tag.Id == 0)
                _tag.Add(tag);
            else
            {
                var t = _tag.Get(tag.Id);
                t.Nombre = tag.Nombre;
                t.Url = tag.Url;
                t.Descripcion = tag.Descripcion;
                t.Texto = tag.Texto;

                _tag.Save();
            }
        }

        public void Delete(int Id)
        {
            var t = _tag.Get(Id);
            t.Eliminado = true;
            _tag.Save();
        }
    }
}
