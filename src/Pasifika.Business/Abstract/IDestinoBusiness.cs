using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.Abstract
{
    public interface IDestinoBusiness
    {
        List<Destino> GetByRegion(int regionId);
        Destino GetByUrl(string url);
        List<Destino> Get();
        Destino Get(int id);
        void Delete(int Id);
        void Order(string jsonOrden);
        void Guardar(Destino d, string directorio, IEnumerable<string> Titulo = null, IEnumerable<string> Texto = null);
    }
}
