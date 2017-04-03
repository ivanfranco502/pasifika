using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface IContactoData
    {
        List<Contacto> Get();
        void Add(Contacto c);
        void Save();
        void Remove(int Id);

        System.Data.DataTable GetDataExport();
    }
}
