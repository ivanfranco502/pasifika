using Pasifika.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface IBusquedaData
    {
        List<Busqueda> GetDatos(string texto, int pageIndex, int pageSize);
    }
}
