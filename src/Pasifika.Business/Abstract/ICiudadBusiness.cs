using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.Abstract
{
    public interface ICiudadBusiness
    {
        List<Ciudad> GetByDestino(int destinoId);
        Ciudad Get(int id);
        void Delete(int Id);
        void Guardar(Ciudad c);
    }
}
