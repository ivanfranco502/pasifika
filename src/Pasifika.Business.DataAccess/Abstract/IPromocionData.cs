using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface IPromocionData
    {
        List<Promocion> Get();
        Promocion Get(int id);
        void Add(Promocion p);
        void Save();
    }
}
