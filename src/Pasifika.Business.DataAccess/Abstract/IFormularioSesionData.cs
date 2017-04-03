using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface IFormularioSesionData
    {
        List<FormularioSesion> Get();
        FormularioSesion Get(int id);
        void Add(FormularioSesion p);
        void Remove(FormularioSesion b);
        void Save();
    }
}
