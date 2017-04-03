using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.Abstract
{
    public interface IFormularioSesionBusiness
    {
        List<FormularioSesion> Get();
        FormularioSesion Get(int id);
        void Guardar(string json);
    }
}
