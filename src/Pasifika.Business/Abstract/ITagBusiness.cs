using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.Abstract
{
    public interface ITagBusiness
    {
        List<Tag> Get();
        Tag Get(int Id);
        Tag GetByUrl(string url);
        void Guardar(Tag tag);
        void Delete(int Id);
    }
}
