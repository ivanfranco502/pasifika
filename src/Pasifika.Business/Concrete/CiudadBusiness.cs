using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.Abstract;
using Pasifika.Model;
using Pasifika.Business.DataAccess.Abstract;

namespace Pasifika.Business.Concrete
{
    public class CiudadBusiness : ICiudadBusiness
    {
        private readonly ICiudadData _ciudad;

        public CiudadBusiness(ICiudadData c)
        {
            this._ciudad = c;
        }

        public List<Ciudad> GetByDestino(int destinoId)
        {
            return _ciudad.GetByDestino(destinoId);
        }

        public Ciudad Get(int id)
        {
            return _ciudad.Get(id);
        }

        public void Delete(int Id)
        {
            var c = _ciudad.Get(Id);
            c.Eliminado = true;
            _ciudad.Save();
        }

        public void Guardar(Ciudad c)
        {
            if (c.Id == 0)
                _ciudad.Add(c);
            else
            {
                var ciudad = _ciudad.Get(c.Id);
                ciudad.Nombre = c.Nombre;
                ciudad.Url = c.Url;
                _ciudad.Save();
            }
        }
    }
}