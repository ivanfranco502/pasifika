using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.Abstract
{
    public interface IBannerHomeBusiness
    {
        List<BannerHome> Get();
        BannerHome GetMostrar();
        BannerHome Get(int id);
        void Guardar(BannerHome b, string directorio);
        void Delete(int Id);
    }
}
