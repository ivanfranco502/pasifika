using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.Abstract;
using Pasifika.Model;
using Pasifika.Business.DataAccess.Abstract;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Pasifika.Business.Concrete
{
    public class PartnerBusiness : IPartnerBusiness
    {
        private readonly IPartnerData _partner;

        public PartnerBusiness(IPartnerData p)
        {
            this._partner = p;
        }

        public List<Partner> Get()
        {
            return _partner.Get();
        }

        public Partner Get(int id)
        {
            return _partner.Get(id);
        }

        public void Guardar(Partner p, string directorio)
        {
            if (p.Stream != null)
            {
                using (var fileStream = File.Create(directorio + "/images/partner/" + p.Foto))
                {
                    p.Stream.CopyTo(fileStream);
                }
            }

            if (p.Id == 0)
                _partner.Add(p);
            else
            {
                var partner = _partner.Get(p.Id);
                partner.Nombre = p.Nombre;
                partner.Orden = p.Orden;
                partner.Texto = p.Texto;
                partner.Foto = p.Foto;
                partner.Alt = p.Alt;
                partner.Link = p.Link;

                _partner.Save();
            }
        }

        public void Delete(int id)
        {
            var p = _partner.Get(id);
            p.Eliminado = true;
            _partner.Save();
        }

        public void Order(string jsonOrden)
        {
            JArray ids = JArray.Parse(jsonOrden);
            int orden = 0;
            foreach (JValue id in ids)
            {
                var p = _partner.Get(int.Parse((string)id.Value));
                p.Orden = orden;
                orden++;
            }

            _partner.Save();
        }
    }
}
