using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.Abstract
{
    public interface IPaginaBusiness
    {
        List<Pagina> Get();
        Pagina Get(int id);
        Pagina Get(int? SeccionId, int? ViajeId, int? NotaId, int? DestinoId, int? TagId, int? RegionId);
        Pagina GetBySeccion(int id);
        Pagina GetByViaje(int id);
        Pagina GetByNota(int id);
        void Guardar(Pagina p);
        void Delete(int Id);
        void GuardarBanners(int id, List<Banner> banners, string directorio);
        void GuardarBannersInferiores(int id, List<BannerInferior> banners, string directorio);
        void GuardarSugeridos(int id, string jsonSugerencias);
        void GuardarDestacados(int id, List<Destacado> destacados, string directorio);
        void GuardarMetaTag(MetaTag m);
        void GuardarInfoRelacion(InfoRelacion i, string directorio);
        void GuardarPaginaTexto(PaginaTexto m);
        void GuardarBannersContextual(BannerContextual b, string directorio);
        void Order(string jsonOrden);
        void RemoveBannerContextual(int id);
    }
}
