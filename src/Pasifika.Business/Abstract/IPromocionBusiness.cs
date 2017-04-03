using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.Abstract
{
    public interface IPromocionBusiness
    {
        List<Promocion> Get();
        Promocion Get(int id);
        void Delete(int Id);
        void Guardar(Promocion p, string directorio);

    }
}
