using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface INotaData
    {
        List<Nota> Get(int? ano, int? mes, bool? visible);
        List<Nota> GetPaginado(int? ano, int? mes, bool? visible, int pageIndex, int pageSize);
        List<Nota> GetPublicas();
        List<Nota> GetPrensa();
        Nota Get(int id);
        Nota GetByUrl(string url);
        void Add(Nota n);
        void Update(Nota n);
        void Save();
    }
}
