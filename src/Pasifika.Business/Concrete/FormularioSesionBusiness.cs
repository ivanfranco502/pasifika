using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.Abstract;
using Pasifika.Model;
using Pasifika.Business.DataAccess.Abstract;
using Newtonsoft.Json.Linq;

namespace Pasifika.Business.Concrete
{
    public class FormularioSesionBusiness : IFormularioSesionBusiness
    {
        private readonly IFormularioSesionData _formulario;

        public FormularioSesionBusiness(IFormularioSesionData f)
        {
            this._formulario = f;
        }

        public List<FormularioSesion> Get()
        {
            return _formulario.Get();
        }

        public FormularioSesion Get(int id)
        {
            return _formulario.Get(id);
        }

        public void Guardar(string json)
        {
            JArray sessiones = JArray.Parse(json);

            int orden = 0;
            foreach (JObject obj in sessiones)
            {
                int id = int.Parse((string)obj["id"]);
                string text = (string)obj["text"];
                string operacion = (string)obj["operacion"];

                FormularioSesion sesion;

                if (operacion == "")
                {
                    if (id < 0)
                    {
                        sesion = new FormularioSesion();
                        sesion.Nombre = text;
                        sesion.Orden = orden;

                        _formulario.Add(sesion);
                    }
                    else
                    {
                        sesion = _formulario.Get(id);
                        sesion.Nombre = text;
                        sesion.Orden = orden;

                        _formulario.Save();
                    }

                    orden++;
                }
                else
                {
                    if (operacion == "B" && id > 0)
                    {
                        sesion = _formulario.Get(id);
                        _formulario.Remove(sesion);
                        _formulario.Save();
                    }
                }
            }
        }
    }
}
