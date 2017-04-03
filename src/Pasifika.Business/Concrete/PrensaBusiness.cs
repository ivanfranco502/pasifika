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
    public class PrensaBusiness : IPrensaBusiness
    {
        private readonly IPrensaData _prensa;

        public PrensaBusiness(IPrensaData p)
        {
            this._prensa = p;
        }

        public List<Prensa> Get()
        {
            return _prensa.Get();
        }
        
        public Prensa Get(int id)
        {
            return _prensa.Get(id);
        }

        public void Delete(int Id)
        {
            var p = _prensa.Get(Id);
            p.Eliminado = true;
            _prensa.Save();
        }

        public void Guardar(Prensa p, string directorio)
        {
            if (!Directory.Exists(directorio + "/images/prensa/foto"))
                Directory.CreateDirectory(directorio + "/images/prensa/foto");

            if (!Directory.Exists(directorio + "/images/prensa/pdf"))
                Directory.CreateDirectory(directorio + "/images/prensa/pdf");

            if (p.StreamFoto != null)
            {
                using (var fileStream = File.Create(directorio + "/images/prensa/foto/" + p.Foto))
                {
                    p.StreamFoto.CopyTo(fileStream);
                }
            }

            if (p.StreamPDF != null)
            {
                using (var fileStream = File.Create(directorio + "/images/prensa/pdf/" + p.PDF))
                {
                    p.StreamPDF.CopyTo(fileStream);
                }
            }

            if (p.Id == 0)
                _prensa.Add(p);
            else
            {
                var prensa = _prensa.Get(p.Id);
                prensa.Foto = p.Foto;
                prensa.Titulo = p.Titulo;
                prensa.PDF = p.PDF;
                prensa.Alt = p.Alt;
                prensa.Revista = p.Revista;
                prensa.Fecha = p.Fecha;
                prensa.Link = p.Link;
                prensa.Resumen = p.Resumen;

                _prensa.Save();
            }
        }
    }
}
