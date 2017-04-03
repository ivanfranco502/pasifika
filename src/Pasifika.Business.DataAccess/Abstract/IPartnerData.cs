using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface IPartnerData
    {
        List<Partner> Get();
        Partner Get(int id);
        void Add(Partner p);
        void Save();
    }
}
