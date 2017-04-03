using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Pasifika.Business.Abstract;
using MvcSiteMapProvider;
using System.IO;

namespace Pasifika.WebUI.Controllers
{
    public class FormularioController : Controller
    {
        public readonly IFormularioSesionBusiness _formSesion;
        public readonly IContactoBusiness _contacto;
        public readonly IViajeBusiness _viaje;

        public FormularioController(IFormularioSesionBusiness f, IContactoBusiness c, IViajeBusiness v)
        {
            this._formSesion = f;
            this._contacto = c;
            this._viaje = v;
        }

        [ChildActionOnly]
        public PartialViewResult Cargar(int tipo, bool cartel, int? id)
        {
            string titulo = "";
            string tituloModalGracias = "";

            List<FormularioSesion> fs = new List<FormularioSesion>();

            switch (tipo)
            {
                case 1:
                    titulo = "INFORMACIÓN PERSONAL";
                    tituloModalGracias = "Contacto";
                    break;
                case 2:
                    titulo = "FORMULARIO";
                    tituloModalGracias = "SOLICITUD DE INFORMACIÓN";
                    break;
                case 3:
                    titulo = "FORMULARIO DE INSCRIPCIÓN";
                    tituloModalGracias = "SESIONES INFORMATIVAS";
                    fs = _formSesion.Get();
                    break;
            }

            var d = CRM.Business.Destino.getDestinos();
            var v = CRM.Business.TipoViaje.getTiposViajes();
            var p = CRM.Business.Provincia.getProvincias();

            if (id.HasValue)
                ViewBag.id = id.Value;

            return PartialView(new ViewModels.FormularioIndexViewModel
            {
                Tipo = tipo,
                Titulo = titulo,
                TituloModalGracias = tituloModalGracias,
                Sesiones = fs,
                Cartel = cartel,
                Destinos = d,
                TiposViajes = v,
                Provincias = p
            });
        }

        [MvcSiteMapNodeAttribute(ParentKey = "Home", DynamicNodeProvider = "Pasifika.WebUI.DI.DynamicNodeProvider.FormularioIndexDynamicNodeProvider, Pasifika.WebUI")]
        public ActionResult Index(int tipo, bool? cartel, int? id)
        {
            ViewBag.tipo = tipo;
            switch (tipo)
            {
                case 1:
                    ViewBag.titulo = "CONTACTO";
                    ViewBag.seccionId = 16;
                    
                    break;
                case 2:
                    ViewBag.titulo = "SOLICITUD DE INFORMACIÓN";
                    ViewBag.seccionId = 25;
                    break;
                case 3:
                    ViewBag.titulo = "SESIONES INFORMATIVAS";
                    ViewBag.seccionId = 19;
                    ViewBag.menusseleccionado = "Seminarios";
                    break;
            }

            ViewBag.cartel = cartel.HasValue ? cartel.Value : false;

            if (id.HasValue)
                ViewBag.id = id.Value;

            return View();
        }

        [HttpPost]
        public ActionResult Save(int Tipo, Contacto c, string dia, string mes, string anio, string fechaSalidaMes, string fechaSalidaMesText, string fechaSalidaAnio, string destinoText, string tipoViajeText, string presupuestoEstimado, int? idProvincia, int? destino, int? tipoViaje, int? id)
        {
            c.Fecha = DateTime.Now;

            switch (Tipo)
            {
                case 1:
                    c.Tipo = "CONTACTO";
                    break;
                case 2:
                    c.Tipo = "CATÁLOGO";
                    break;
                case 3:
                    c.Tipo = "SEMINARIOS";
                    break;
            }

            if (c.Pais == "es")
            {
                c.Europa = true;
                //c.Pais = "";
            }
            else
            {
                c.Europa = false;
                c.Provincia = "";
                //c.Pais = ""
            }

            if (!String.IsNullOrEmpty(dia) && !String.IsNullOrEmpty(mes) && !String.IsNullOrEmpty(anio))
                c.FechaNacimiento = new DateTime(int.Parse(anio), int.Parse(mes), int.Parse(dia));

            if (Tipo == 1)
            {
                if (c.Email != "jfvynms4281rt@hotmail.com")
                {
                    CRM.Model.Fichas dsFichas = new CRM.Model.Fichas();
                    CRM.Model.Fichas.FichaRow row = dsFichas.Ficha.NewFichaRow();
                    row.apellido = c.Apellido;
                    row.conocio = c.Conocio == null ? "" : c.Conocio;
                    row.consulta = c.Mensaje == null ? "" + c.Url : c.Mensaje + Environment.NewLine + Environment.NewLine + c.Url;
                    row.email = c.Email;
                    row.formaContacto = "EMAIL";
                    row.horario = c.HoraContacto == null ? "" : c.HoraContacto;
                    row.nombre = c.Nombre;
                    row.pais = c.Pais;
                    row.telefono = c.Telefono;
                    row.ano = int.Parse(fechaSalidaAnio);
                    if (!String.IsNullOrEmpty(dia) && !String.IsNullOrEmpty(mes) && !String.IsNullOrEmpty(anio))
                        row.fechaNacimiento = new DateTime(int.Parse(anio), int.Parse(mes), int.Parse(dia));
                    else
                        row.fechaNacimiento = new DateTime(1920, 1, 1);
                    row.idDestino = destino.Value;
                    row.mes = int.Parse(fechaSalidaMes);

                    row.espana = c.Europa;

                    if (c.Europa)
                        row.idProvincia = idProvincia.Value;

                    row.sexo = c.Sexo;
                    row.idTipoViaje = tipoViaje.Value;
                    row.fechaSolicitud = DateTime.Now;
                    row.idArea = (int)CRM.Business.Area.AreaType.AtencionAlCliente;
                    row.idStatus = (int)CRM.Business.Status.StatusType.Nuevo;
                    row.idUsuario = 1;
                    //row.presupuestoAprox = presupuestoEstimado;

                    int idFicha = CRM.Business.Ficha.insertFicha(row);
                }
            }
            
            _contacto.Guardar(c);


            string body = "";
            string subject = "";
            string consulta = "";
            string to = "";

            body += "Nombre:" + c.Nombre + Environment.NewLine;
            body += "Apellido:" + c.Apellido + Environment.NewLine;
            body += "Email:" + c.Email + Environment.NewLine;
            body += "España:" + c.Europa.ToString() + Environment.NewLine;
            body += "Otro:" + c.Pais + Environment.NewLine;
            body += "Provincia:" + c.Provincia + Environment.NewLine;
            body += "Sexo:" + c.Sexo + Environment.NewLine;
            if (c.FechaNacimiento.HasValue)
                body += "Fecha de nacimiento:" + c.FechaNacimiento.Value.ToString("dd/MM/yyyy") + Environment.NewLine;

            switch (Tipo)
            {
                case 1:
                    body += "Teléfono de contacto:" + c.Telefono + Environment.NewLine;
                    body += "Horario que podemos contactar por teléfono:" + c.HoraContacto + Environment.NewLine;
                    body += "Destino: " + destinoText + Environment.NewLine;
                    body += "Tipo de viaje: " + tipoViajeText + Environment.NewLine;
                    body += "Fecha salida: " + fechaSalidaMesText + " " + fechaSalidaAnio + Environment.NewLine;
                    body += "Presupuesto: " + presupuestoEstimado + Environment.NewLine;
                    
                    consulta += "CONSULTA:" + Environment.NewLine;
                    consulta += c.Mensaje + Environment.NewLine;
                    subject = "Solicitud de información";
                    to = "contacto@pasifika.es";
                    break;
                case 4:
                    //email.Tipo = "News";
                    subject = "Inscripción a la newsletter";
                    to = "news@pasifika.es";
                    break;
                case 2:
                    subject = "Solicitud de catálogo";
                    to = "catalogo@pasifika.es";
                    break;
                case 3:
                    body += "Teléfono de contacto:" + c.Telefono + Environment.NewLine;
                    subject = "Sesion Informativa";
                    to = "sesiones@pasifika.es";
                    break;
            }
            body += "Como nos ha conocido:" + c.Conocio + Environment.NewLine;

            body = subject.ToUpper() + ":" + Environment.NewLine + body + Environment.NewLine + body;
            body += consulta + Environment.NewLine;
            body += "Link:" + c.Url;

            _contacto.SendMail("catalogo@pasifika.es", to, subject, body);

            if (Tipo == 2)
            {
                string pdf = "";
                if (id.HasValue)
                    pdf = Convert.ToBase64String(BitConverter.GetBytes(id.Value)).Replace("==", "");

                body = "";

                body += "Estimado/a " + c.Nombre + ", " + Environment.NewLine;
                body += Environment.NewLine;
                body += "En el siguiente enlace podrá ver la información que nos ha solicitado." + Environment.NewLine;
                body += "http://testpasifika.azurewebsites.net/download-catalogo/" + pdf + Environment.NewLine;
                body += Environment.NewLine;
                body += "Si tuviera interés en recibir asesoramiento profesional para diseñar su viaje, por favor no dude en contactar nuevamente con nosotros." + Environment.NewLine;
                body += Environment.NewLine;
                body += "TEL: +34 91 715 5422  | info@pasifika.es" + Environment.NewLine;
                body += Environment.NewLine;
                body += "OFICINA: Calle Francia 3 - Piso 1º B. 28224 Pozuelo de Alarcón. Madrid - España" + Environment.NewLine;
                body += Environment.NewLine;
                body += "HORARIOS: De lunes a viernes: de 09.00h a 14.00h y de 16.00h a 19.00h. Sábados con cita previa " + Environment.NewLine;
                body += Environment.NewLine;
                body += "Muchas gracias," + Environment.NewLine;
                body += Environment.NewLine;
                body += "Saludos cordiales, ";
                body += Environment.NewLine;
                body += "Pasifika Viajes" + Environment.NewLine;

                _contacto.SendMail("catalogo@pasifika.es", c.Email, "Su solicitud de información", body);
            }

            return RedirectToAction("Index", new
            {
                tipo = Tipo,
                cartel = true
            });
        }

        [MvcSiteMapNodeAttribute(Title = "Compartir", ParentKey = "Home", Key = "Compartir")]
        public ActionResult Compartir(bool? cartel)
        {
            ViewBag.cartel = cartel.HasValue ? cartel.Value : false;

            return View();
        }

        [HttpPost]
        public ActionResult SaveCompartir(string Nombre, string NombreAmigo, string Email, string EmailAmigo, string Asunto, string Mensaje, bool? Recibir, string Url)
        {
            string body = "";
            string subject = Asunto;
            string to = EmailAmigo;

            body += "Hola " + NombreAmigo + Environment.NewLine;
            body += Nombre + "te manda este mensaje:" + Environment.NewLine;
            body += Mensaje + Environment.NewLine;
            body += "Link: " + Url + Environment.NewLine;
            
            _contacto.SendMail(to, subject, body);

            if (Recibir.HasValue && Recibir.Value)
                to = Email;

            _contacto.SendMail(to, subject, body);

            return RedirectToAction("Compartir", new {
                cartel = true
            });
        }

        [MvcSiteMapNodeAttribute(Title = "Solicitud de baja", ParentKey = "Home", Key = "Baja")]
        public ActionResult Baja(bool? cartel)
        {
            ViewBag.cartel = cartel.HasValue ? cartel.Value : false;

            return View();
        }

        [HttpPost]
        public ActionResult SaveBaja(string email, string mensaje)
        {
            Contacto c = new Contacto();
            c.Email = email;
            c.Fecha = DateTime.Now;
            c.Mensaje = mensaje;
            c.Newsletter = false;
            c.Tipo = "BAJA";

            _contacto.Guardar(c);

            string subject = "Inscripción a la newsletter";
            string to = "news@pasifika.es";
            string body = "";
            body += "Email que solicita dar de baja:" + c.Email + Environment.NewLine;
            body += "Motivo:" + c.Mensaje + Environment.NewLine;

            _contacto.SendMail(to, subject, body);

            return RedirectToAction("Baja", new
            {
                cartel = true
            });
        }

        public ActionResult DownloadCatalogo(string id) 
        {
            //var a = Convert.ToBase64String(BitConverter.GetBytes(int.Parse(id))).Replace("==", "");
            int idViaje = BitConverter.ToInt32(Convert.FromBase64String(id + "=="), 0);

            var v = _viaje.Get(idViaje);
            StreamReader streamReader = new StreamReader(Server.MapPath("~/Content/images/pdf/" + v.PDF));

            
            Response.AppendHeader("content-disposition", "inline; filename=Catalogo.pdf");
            return new FileStreamResult(streamReader.BaseStream, "application/pdf");
        }
    }
}