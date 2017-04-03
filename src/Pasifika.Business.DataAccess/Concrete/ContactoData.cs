using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Model;
using System.Data;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class ContactoData : IContactoData
    {
        private readonly PasifikaDbContext _db;

        public ContactoData(PasifikaDbContext db)
        {
            this._db = db;
        }

        public List<Contacto> Get()
        {
            var q = from c in _db.Contactos
                    orderby
                        c.Fecha descending
                    select c;

            return q.ToList();
        }

        public void Add(Contacto c)
        {
            _db.Contactos.Add(c);
            _db.SaveChanges();
        }

        public void Remove(int Id)
        {
            var c = _db.Contactos.Where(x => x.Id == Id).First();
            _db.Contactos.Remove(c);
            _db.SaveChanges();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public DataTable GetDataExport()
        {

            var query = from en in _db.Contactos
                        select en;

            DataTable ds = new DataTable("contactos");

            ds.Columns.Add("Fecha");
            ds.Columns.Add("Hora");
            ds.Columns.Add("Form");
            ds.Columns.Add("Session");
            ds.Columns.Add("Sexo");
            ds.Columns.Add("Nombre");
            ds.Columns.Add("Apellido");
            ds.Columns.Add("Email");
            ds.Columns.Add("Espana");
            ds.Columns.Add("Provincia");
            ds.Columns.Add("OtrosPaises");
            ds.Columns.Add("Telefono");
            ds.Columns.Add("DOB");
            ds.Columns.Add("Conocio");
            ds.Columns.Add("Newsletter");
            ds.Columns.Add("Privacidad");
            ds.Columns.Add("Url");

            foreach (var c in query)
            {
                DataRow dr = ds.Rows.Add();
                dr["Fecha"] = c.Fecha.ToString("dd/MM/yyyy");
                dr["Hora"] = c.Fecha.ToString("HH:mm");
                dr["Form"] = c.Tipo;
                dr["Session"] = c.Sesion;
                dr["Sexo"] = c.Sexo;
                dr["Nombre"] = c.Nombre;
                dr["Apellido"] = c.Apellido;
                dr["Email"] = c.Email;
                dr["Espana"] = c.Europa;
                dr["Provincia"] = c.Provincia;
                dr["OtrosPaises"] = c.Pais;
                dr["Telefono"] = c.Telefono;
                dr["DOB"] = c.FechaNacimiento.HasValue ? c.FechaNacimiento.Value.ToString("dd/MM/yyyy") : "";
                dr["Conocio"] = c.Conocio;
                dr["Newsletter"] = c.Newsletter;
                dr["Privacidad"] = "Si";
                dr["Url"] = c.Url;
              

            }

            return ds;

        }
    }
}
