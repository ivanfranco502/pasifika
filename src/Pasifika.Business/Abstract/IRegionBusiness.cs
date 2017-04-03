using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.Abstract
{
    public interface IRegionBusiness
    {
        List<Region> Get();
        Region Get(int id);
        void Delete(int Id);
        void Order(string jsonOrden);
        void Guardar(Region r, string directorio);
    }
}
