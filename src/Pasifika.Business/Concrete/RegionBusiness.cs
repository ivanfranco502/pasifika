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
    public class RegionBusiness : IRegionBusiness
    {
        private readonly IRegionData _region;

        public RegionBusiness(IRegionData r)
        {
            this._region = r;
        }

        public List<Region> Get()
        {
            return _region.Get();
        }
        
        public Region Get(int id)
        {
            return _region.Get(id);
        }

        public void Delete(int Id)
        {
            var r = _region.Get(Id);
            r.Eliminado = true;
            _region.Save();
        }

        public void Guardar(Region r, string directorio)
        {
            if (r.Stream != null)
            {
                using (var fileStream = File.Create(directorio + "/images/region/" + r.Foto))
                {
                    r.Stream.CopyTo(fileStream);
                }
            }

            if (r.Id == 0)
                _region.Add(r);
            else
            {
                var region = _region.Get(r.Id);
                region.Nombre = r.Nombre;
                region.Foto = r.Foto;
                region.Url = r.Url;
                region.Orden = r.Orden;
                region.Descripcion = r.Descripcion;

                _region.Save();
            }
        }

        public void Order(string jsonOrden)
        {
            JArray ids = JArray.Parse(jsonOrden);
            int orden = 0;
            foreach (JValue id in ids)
            {
                var p = _region.Get(int.Parse((string)id.Value));
                p.Orden = orden;
                orden++;
            }

            _region.Save();
        }
    }
}
