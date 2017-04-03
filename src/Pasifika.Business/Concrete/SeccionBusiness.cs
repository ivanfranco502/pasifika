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
    public class SeccionBusiness : ISeccionBusiness
    {
        private readonly ISeccionData _seccion;

        public SeccionBusiness(ISeccionData s)
        {
            this._seccion = s;
        }

        public List<Seccion> Get()
        {
            return _seccion.Get();
        }
    }
}
