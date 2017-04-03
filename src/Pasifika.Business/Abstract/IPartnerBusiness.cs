using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.Abstract
{
    public interface IPartnerBusiness
    {
        List<Partner> Get();
        Partner Get(int id);
        void Guardar(Partner p, string directorio);
        void Delete(int id);
        void Order(string jsonOrden);
    }
}
