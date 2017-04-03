using Pasifika.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Business.Abstract
{
    public interface INotaBusiness
    {
        List<Nota> Get(int? ano, int? mes, bool? visible);
        List<Nota> GetPaginado(int? ano, int? mes, bool? visible, int pageIndex, int pageSize);
        List<Nota> GetPublicas();
        List<Nota> GetPrensa();
        Nota Get(int id);
        Nota GetByUrl(string url);
        void Guardar(Nota n, string texto, string directorio);
        void Delete(int Id);
    }
}
