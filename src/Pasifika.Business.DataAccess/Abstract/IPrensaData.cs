using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface IPrensaData
    {
        List<Prensa> Get();
        Prensa Get(int id);
        void Add(Prensa p);
        void Save();
    }
}
