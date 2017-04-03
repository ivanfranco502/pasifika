using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.Abstract;
using Pasifika.Model;
using Pasifika.Business.DataAccess.Abstract;
using System.IO;

namespace Pasifika.Business.Concrete
{
    public class PromocionBusiness : IPromocionBusiness
    {
        private readonly IPromocionData _promocion;

        public PromocionBusiness(IPromocionData p)
        {
            this._promocion = p;
        }

        public List<Promocion> Get()
        {
            return _promocion.Get();
        }
        
        public Promocion Get(int id)
        {
            return _promocion.Get(id);
        }

        public void Delete(int Id)
        {
            var p = _promocion.Get(Id);
            p.Eliminado = true;
            _promocion.Save();
        }

        public void Guardar(Promocion p, string directorio)
        {
            if (p.Stream != null)
            {
                using (var fileStream = File.Create(directorio + "/images/promocion/" + p.Foto))
                {
                    p.Stream.CopyTo(fileStream);
                }
            }

            if (p.Id == 0)
                _promocion.Add(p);
            else
            {
                var promocion = _promocion.Get(p.Id);
                promocion.Link = p.Link;
                promocion.Foto = p.Foto;
                promocion.SubTitulo = p.SubTitulo;
                promocion.Titulo = p.Titulo;
                promocion.Promo = p.Promo;
                promocion.Alt = p.Alt;

                _promocion.Save();
            }
        }
    }
}
