using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.Abstract
{
    public interface ISugerenciaBusiness
    {
        List<Sugerencia> Get();
        Sugerencia Get(int id);
        void Delete(int Id);
        void Guardar(Sugerencia s, string directorio);

    }
}
