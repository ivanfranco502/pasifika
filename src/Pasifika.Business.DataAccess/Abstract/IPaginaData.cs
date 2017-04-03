using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface IPaginaData
    {

        List<Pagina> Get();
        Pagina Get(int id);
        Pagina Get(int? SeccionId, int? ViajeId, int? NotaId, int? DestinoId, int? TagId, int? RegionId);
        Pagina GetBySeccion(int id);
        Pagina GetByViaje(int id);
        Pagina GetByNota(int id);
        void Add(Pagina p);
        void Remove(Banner b);
        void Remove(BannerInferior b);
        void Remove(Destacado d);
        void Save();
        void RemoveBannerContextual(int id);
    }
}
