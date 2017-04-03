using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.Abstract
{
    public interface IPrensaBusiness
    {
        List<Prensa> Get();
        Prensa Get(int id);
        void Delete(int Id);
        void Guardar(Prensa p, string directorio);
    }
}
