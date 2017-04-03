using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;

namespace Pasifika.Business.DataAccess.Abstract
{
    public interface IViajeData
    {
        List<Viaje> Get();
        List<Viaje> Get(int TipoViaje, int SubTipoViaje);
        List<Viaje> Get(int TipoViaje, int SubTipoViaje, int? presupuestoDesde, int? presupuestoHasta, int? duracionDesde, int? duracionHasta, List<int> tags, int? destinoId, int? ciudadId);
        Viaje Get(int id);
        Viaje GetByUrl(string url);
        void Add(Viaje v);
        void Remove(Foto f);
        void Save();
    }
}
