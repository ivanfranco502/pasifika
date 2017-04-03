using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Business.Abstract;
using Pasifika.Model;
using Pasifika.Business.DataAccess.Abstract;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Pasifika.Business.Concrete
{
    public class DestinoBusiness : IDestinoBusiness
    {
        private readonly IDestinoData _destino;

        public DestinoBusiness(IDestinoData d)
        {
            this._destino = d;
        }

        public List<Destino> GetByRegion(int regionId)
        {
            return _destino.GetByRegion(regionId);
        }

        public Destino GetByUrl(string url)
        {
            return _destino.GetByUrl(url);
        }

        public List<Destino> Get()
        {
            return _destino.Get();
        }

        public Destino Get(int id)
        {
            return _destino.Get(id);
        }

        public void Delete(int Id)
        {
            var d = _destino.Get(Id);
            d.Eliminado = true;
            _destino.Save();
        }

        public void Guardar(Destino d, string directorio, IEnumerable<string> Titulo = null, IEnumerable<string> Texto = null)
        {
            if (!Directory.Exists(directorio + "/images/destino/guia"))
                Directory.CreateDirectory(directorio + "/images/destino/guia");

            if (!Directory.Exists(directorio + "/images/destino/hotel"))
                Directory.CreateDirectory(directorio + "/images/destino/hotel");

            if (!Directory.Exists(directorio + "/images/destino/excursion"))
                Directory.CreateDirectory(directorio + "/images/destino/excursion");

            if (d.StreamPDFGuia!= null)
            {
                using (var fileStream = File.Create(directorio + "/images/destino/guia/" + d.PDFGuia))
                {
                    d.StreamPDFGuia.CopyTo(fileStream);
                }
            }

            if (d.StreamGuia != null)
            {
                using (var fileStream = File.Create(directorio + "/images/destino/guia/" + d.FotoGuia))
                {
                    d.StreamGuia.CopyTo(fileStream);
                }
            }

            if (d.StreamHotel != null)
            {
                using (var fileStream = File.Create(directorio + "/images/destino/hotel/" + d.FotoHotel))
                {
                    d.StreamHotel.CopyTo(fileStream);
                }
            }

            if (d.StreamExcursion != null)
            {
                using (var fileStream = File.Create(directorio + "/images/destino/excursion/" + d.FotoExcursion))
                {
                    d.StreamExcursion.CopyTo(fileStream);
                }
            }

            int pos = 0;
            if (d.Id == 0)
            {
                if (Titulo != null)
                {
                    foreach (var t in Titulo)
                    {
                        d.DestinoTitulos.Add(new DestinoTitulo
                        {
                            Id = 0,
                            Titulo = t,
                            Texto = Texto.ElementAt(pos)
                        });

                        pos++;
                    }
                }
                _destino.Add(d);
            }
            else
            {
                var destino = _destino.Get(d.Id);
                destino.Nombre = d.Nombre;
                destino.Url = d.Url;
                destino.FotoGuia = d.FotoGuia;
                destino.FotoHotel = d.FotoHotel;
                destino.FotoExcursion = d.FotoExcursion;
                destino.PDFGuia= d.PDFGuia;
                destino.Alt = d.Alt;
                destino.Datos = d.Datos;
                destino.Resumen = d.Resumen;

                foreach(var dt in destino.DestinoTitulos.ToList())
                {
                    _destino.Remove(dt);
                }

                destino.DestinoTitulos.Clear();
                
                if (Titulo != null)
                {
                    foreach (var t in Titulo)
                    {
                        destino.DestinoTitulos.Add(new DestinoTitulo
                        {
                            Id = 0,
                            Titulo = t,
                            Texto = Texto.ElementAt(pos)
                        });

                        pos++;
                    }
                }

                _destino.Save();
            }
        }

        public void Order(string jsonOrden)
        {
            JArray ids = JArray.Parse(jsonOrden);
            int orden = 0;
            foreach (JValue id in ids)
            {
                var p = _destino.Get(int.Parse((string)id.Value));
                p.Orden = orden;
                orden++;
            }

            _destino.Save();
        }
    }
}
