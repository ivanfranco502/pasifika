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
    public class SugerenciaBusiness : ISugerenciaBusiness
    {
        private readonly ISugerenciaData _sugerencia;

        public SugerenciaBusiness(ISugerenciaData s)
        {
            this._sugerencia= s;
        }

        public List<Sugerencia> Get()
        {
            return _sugerencia.Get();
        }
        
        public Sugerencia Get(int id)
        {
            return _sugerencia.Get(id);
        }

        public void Delete(int Id)
        {
            var s = _sugerencia.Get(Id);
            s.Eliminado = true;
            _sugerencia.Save();
        }

        public void Guardar(Sugerencia s, string directorio)
        {
            if (s.Stream != null)
            {
                using (var fileStream = File.Create(directorio + "/images/sugerencia/" + s.Foto))
                {
                    s.Stream.CopyTo(fileStream);
                }
            }

            if (s.Id == 0)
                _sugerencia.Add(s);
            else
            {
                var sugerencia = _sugerencia.Get(s.Id);
                sugerencia.Link = s.Link;
                sugerencia.Foto = s.Foto;
                sugerencia.SubTitulo = s.SubTitulo;
                sugerencia.SubTitulo2 = s.SubTitulo2;
                sugerencia.Titulo = s.Titulo;
                sugerencia.Alt = s.Alt;

                _sugerencia.Save();
            }
        }
    }
}
