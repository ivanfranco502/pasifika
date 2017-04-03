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
    public class NotaBusiness : INotaBusiness
    {
        private readonly INotaData _nota;

        public NotaBusiness(INotaData n)
        {
            this._nota = n;
        }

        public List<Nota> Get(int? ano, int? mes, bool? visible)
        {
            return _nota.Get(ano, mes, visible);
        }

        public List<Nota> GetPaginado(int? ano, int? mes, bool? visible, int pageIndex, int pageSize)
        {
            return _nota.GetPaginado(ano, mes, visible,pageIndex,pageSize);
        }

        public List<Nota> GetPublicas() 
        {
            return _nota.GetPublicas();
        }

        public List<Nota> GetPrensa()
        {
            return _nota.GetPrensa();
        }

        public Nota Get(int id)
        {
            return _nota.Get(id);
        }

        public Nota GetByUrl(string url)
        {
            return _nota.GetByUrl(url);
        }

        public void Guardar(Nota n, string texto, string directorio)
        {
            if (n.Id == 0)
                _nota.Add(n);
            else
                _nota.Update(n);

            using (var tw = new StreamWriter(directorio + "/images/nota/" + n.Id.ToString() + ".html", false))
            {
                tw.Write(texto);
            }
        }

        public void Delete(int Id)
        {
            var n = _nota.Get(Id);
            n.Eliminado = true;
            _nota.Save();
        }
    }
}
