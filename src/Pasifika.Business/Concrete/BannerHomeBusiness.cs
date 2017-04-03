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
    public class BannerHomeBusiness : IBannerHomeBusiness
    {
        private readonly IBannerHomeData _banner;

        public BannerHomeBusiness(IBannerHomeData b)
        {
            this._banner = b;
        }

        public List<BannerHome> Get()
        {
            return _banner.Get();
        }

        public BannerHome GetMostrar()
        {
            return _banner.GetMostrar();
        }

        public BannerHome Get(int id)
        {
            return _banner.Get(id);
        }

        public void Guardar(BannerHome b, string directorio)
        {
            if (!Directory.Exists(directorio + "/images/bannerhome/"))
                Directory.CreateDirectory(directorio + "/images/bannerhome/");

            if (b.Stream != null)
            {
                using (var fileStream = File.Create(directorio + "/images/bannerhome/" + b.Foto))
                {
                    b.Stream.CopyTo(fileStream);
                }
            }

            if (b.Id == 0)
                _banner.Add(b);
            else
                _banner.Update(b);
        }

        public void Delete(int Id)
        {
            var b = _banner.Get(Id);
            b.Eliminado = true;
            _banner.Save();
        }
    }
}
