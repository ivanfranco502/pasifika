using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface IRegionData
    {
        List<Region> Get();
        Region Get(int id);
        void Add(Region r);
        void Save();
    }
}
