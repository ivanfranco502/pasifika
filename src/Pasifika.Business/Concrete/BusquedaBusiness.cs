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
    public class BusquedaBusiness : IBusquedaBusiness
    {
        private readonly IBusquedaData _busqueda;
        private readonly IViajeData _viaje;
        private readonly INotaData _nota;
        private readonly IDestinoData _Destino; 

        public BusquedaBusiness(IBusquedaData b,IViajeData v, INotaData n, IDestinoData d )
        {
            this._busqueda = b;
            this._viaje = v;
            this._nota = n;
            this._Destino = d;
        }

        public List<Busqueda> GetDatos(string texto, int pageIndex, int pageSize)
        {
            List<Busqueda> result = _busqueda.GetDatos(texto, pageIndex, pageSize);

            if (result != null)
            {
                foreach (Busqueda busqueda in result)
                {
                    if (busqueda.Tipo == 1)
                        busqueda.Viaje = _viaje.Get(busqueda.Id);
                    else if (busqueda.Tipo == 2)
                        busqueda.Nota = _nota.Get(busqueda.Id);
                    else
                        busqueda.Destino = _Destino.Get(busqueda.Id);
                        
                }
            }

            return result;
        }

    }
}
