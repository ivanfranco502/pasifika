using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.Abstract;
using Pasifika.Model;
using Pasifika.Business.DataAccess.Abstract;
using System.Net.Mail;
using System.Data;

namespace Pasifika.Business.Concrete
{
    public class ContactoBusiness : IContactoBusiness
    {
        private readonly IContactoData _contacto;

        public ContactoBusiness(IContactoData c)
        {
            this._contacto = c;
        }

        public List<Contacto> Get()
        {
            return _contacto.Get();
        }

        public void Guardar(Contacto c)
        {
            _contacto.Add(c);
        }

        public void Delete(int Id)
        {
            _contacto.Remove(Id);
        }

        public void SendMail(string to, string subject, string body)
        {
            this.SendMail("web@pasifika.es", to, subject, body);
        }

        public void SendMail(string from, string to, string subject, string body)
        {
            MailMessage mMailMessage = new MailMessage();

            mMailMessage.From = new MailAddress(from, "Pasifika Viajes");
            mMailMessage.To.Add(new MailAddress(to));
            mMailMessage.Subject = subject;
            mMailMessage.Body = body;
            mMailMessage.IsBodyHtml = false;
            mMailMessage.Priority = MailPriority.Normal;

            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.Host = "smtp.pasifika.es";

            if (from == "web@pasifika.es")
                mSmtpClient.Credentials = new System.Net.NetworkCredential("rdl638c", "Ma1lpas1f1ka");
            else
                if (from == "catalogo@pasifika.es")
                    mSmtpClient.Credentials = new System.Net.NetworkCredential("adl689c", "Catal0g0");
                    
            mSmtpClient.Send(mMailMessage);
        }

        public DataTable GetDataExport()
        {
            return _contacto.GetDataExport();
        }
    }
}
