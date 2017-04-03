using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface ISugerenciaData
    {
        List<Sugerencia> Get();
        Sugerencia Get(int id);
        void Add(Sugerencia s);
        void Save();
    }
}
