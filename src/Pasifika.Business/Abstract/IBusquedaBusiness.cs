using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.Abstract
{
    public interface IBusquedaBusiness
    {
        List<Busqueda> GetDatos(string texto, int pageIndex, int pageSize);
    }
}
