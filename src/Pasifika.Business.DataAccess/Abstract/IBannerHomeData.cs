using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface IBannerHomeData
    {
        List<BannerHome> Get();
        BannerHome GetMostrar();
        BannerHome Get(int id);
        void Add(BannerHome b);
        void Update(BannerHome b);
        void Save();
    }
}
