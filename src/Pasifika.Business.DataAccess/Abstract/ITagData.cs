using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface ITagData
    {
        List<Tag> Get();
        Tag Get(int Id);
        Tag GetByUrl(string url);
        void Add(Tag tag);
        void Save();
    }
}
