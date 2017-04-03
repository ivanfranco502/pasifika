using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface IDestinoData
    {
        List<Destino> GetByRegion(int regionId);
        Destino GetByUrl(string url);
        List<Destino> Get();
        Destino Get(int id);
        void Add(Destino d);
        void Remove(DestinoTitulo d);
        void Save();
    }
}
