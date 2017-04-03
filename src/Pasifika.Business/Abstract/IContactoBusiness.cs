using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;
using System.Data;

namespace Pasifika.Business.Abstract
{
    public interface IContactoBusiness
    {
        List<Contacto> Get();
        void Guardar(Contacto c);
        void Delete(int Id);
        void SendMail(string to, string subject, string body);
        void SendMail(string from, string to, string subject, string body);
        DataTable GetDataExport();
    }
}
