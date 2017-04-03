using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface ICiudadData
    {
        List<Ciudad> GetByDestino(int destinoId);
        Ciudad Get(int id);
        void Add(Ciudad c);
        void Save();
    }
}
