using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class Pagina
    {
        public Pagina()
        {
            //SugerenciasPagina = new HashSet<SugerenciaPagina>();
        }

        [Key]
        public int Id { get; set; }
        public int Orden { get; set; }
        public bool Eliminado { get; set; }
        public int? SeccionId { get; set; }
        public int? DestinoId { get; set; }
        public int? TagId { get; set; }
        public int? ViajeId { get; set; }
        public int? NotaId { get; set; }
        public int? RegionId { get; set; }

        public virtual Seccion Seccion { get; set; }
        public virtual Destino Destino { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual Viaje Viaje { get; set; }
        public virtual Nota Nota { get; set; }
        public virtual Region Region { get; set; }

        public virtual ICollection<PaginaTexto> PaginaTextos { get; set; }
        public virtual ICollection<Destacado> Destacados { get; set; }
        public virtual ICollection<SugerenciaPagina> SugerenciasPagina { get; set; }
        public virtual ICollection<Banner> Banners { get; set; }
        public virtual ICollection<BannerContextual> BannersContextual { get; set; }
        public virtual ICollection<BannerInferior> BannersInferiores { get; set; }
        public virtual ICollection<MetaTag> MetaTags { get; set; }
        public virtual ICollection<InfoRelacion> InfoRelaciones { get; set; }
    }
}
