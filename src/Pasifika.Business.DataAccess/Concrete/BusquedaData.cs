using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;
using System.Data;
using System.Data.SqlClient;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class BusquedaData : IBusquedaData
    {
        private readonly PasifikaDbContext _db;

        public BusquedaData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Busqueda> GetDatos(string texto, int pageIndex, int pageSize)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@Descripcion", texto);
            parametros[1] = new SqlParameter("@PageIndex", pageIndex);
            parametros[2] = new SqlParameter("@PageSize", pageSize);

            var result = _db.Database.SqlQuery<Busqueda>("sp_busqueda_datos @Descripcion, @PageIndex, @PageSize", parametros).ToList();

            return result;

        }
    }

    
}
