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
    public class PaginaBusiness : IPaginaBusiness
    {
        private readonly IPaginaData _pagina;

        public PaginaBusiness(IPaginaData p)
        {
            this._pagina = p;
        }

        public List<Pagina> Get()
        {
            return _pagina.Get();
        }

        public Pagina Get(int id)
        {
            return _pagina.Get(id);
        }

        public Pagina Get(int? SeccionId, int? ViajeId, int? NotaId, int? DestinoId, int? TagId, int? RegionId)
        {
            return _pagina.Get(SeccionId, ViajeId, NotaId, DestinoId, TagId, RegionId);
        }

        public Pagina GetBySeccion(int id)
        {
            return _pagina.GetBySeccion(id);
        }

        public Pagina GetByViaje(int id)
        {
            return _pagina.GetByViaje(id);
        }

        public Pagina GetByNota(int id)
        {
            return _pagina.GetByNota(id);
        }

        public void Guardar(Pagina p)
        {
            var pagina = _pagina.Get(p.Id);
            if (pagina == null)
                pagina = new Pagina();

            pagina.Id = p.Id;
            pagina.SeccionId = p.SeccionId;
            pagina.TagId = p.TagId;
            pagina.DestinoId = p.DestinoId;
            pagina.ViajeId = p.ViajeId;
            pagina.NotaId = p.NotaId;
            pagina.RegionId = p.RegionId;
            pagina.Eliminado = false;

            if (pagina.Id != 0)
                _pagina.Save();
            else
                _pagina.Add(pagina);

            p.Id = pagina.Id;
        }

        public void Delete(int Id)
        {
            var p = _pagina.Get(Id);
            p.Eliminado = true;
            _pagina.Save();
        }

        public void GuardarBanners(int id, List<Banner> banners, string directorio)
        {
            var p = _pagina.Get(id);
            //p.Banners.Clear();

            if (!Directory.Exists(directorio + "/images/banner/" + id))
                Directory.CreateDirectory(directorio + "/images/banner/" + id);

            foreach (Banner b in banners)
            {
                if (b.Id < 0)
                    b.Operacion = "A";
                else
                    if (b.Operacion == null)
                        b.Operacion = "M";

                if (b.Operacion == "A")
                {
                    b.Id = 0;
                    p.Banners.Add(b);

                    if (b.Stream != null)
                    {
                        using (var fileStream = File.Create(directorio + "/images/banner/" + id + "/" + b.Foto))
                        {
                            b.Stream.CopyTo(fileStream);
                        }
                    }
                }
                else
                {
                    if (b.Operacion == "B")
                    {
                        var bb = p.Banners.Where(x => x.Id == b.Id).First();
                        _pagina.Remove(bb);
                        p.Banners.Remove(bb);
                    }
                    else
                    {
                        if (b.Operacion == "M")
                        {
                            var bb = p.Banners.Where(x => x.Id == b.Id).First();

                            if (b.Stream != null)
                            {
                                using (var fileStream = File.Create(directorio + "/images/banner/" + id + "/" + b.Foto))
                                {
                                    b.Stream.CopyTo(fileStream);

                                }
                            }

                            bb.Alt = b.Alt;
                            bb.Foto = b.Foto;
                            bb.Link = b.Link;
                            bb.Orden = b.Orden;
                            bb.Texto = b.Texto;
                            bb.Texto2 = b.Texto2;
                            bb.Title = b.Title;
                        }
                    }
                }
            }

            _pagina.Save();
        }

        public void GuardarBannersInferiores(int id, List<BannerInferior> banners, string directorio)
        {
            var p = _pagina.Get(id);
            //p.Banners.Clear();

            if (!Directory.Exists(directorio + "/images/bannerinferior/" + id))
                Directory.CreateDirectory(directorio + "/images/bannerinferior/" + id);

            foreach (BannerInferior b in banners)
            {
                if (b.Id < 0)
                    b.Operacion = "A";
                else
                    if (b.Operacion == null)
                        b.Operacion = "M";

                if (b.Operacion == "A")
                {
                    b.Id = 0;
                    p.BannersInferiores.Add(b);

                    if (b.Stream != null)
                    {
                        using (var fileStream = File.Create(directorio + "/images/bannerinferior/" + id + "/" + b.Foto))
                        {
                            b.Stream.CopyTo(fileStream);
                        }
                    }
                }
                else
                {
                    if (b.Operacion == "B")
                    {
                        var bb = p.BannersInferiores.Where(x => x.Id == b.Id).First();
                        _pagina.Remove(bb);
                        p.BannersInferiores.Remove(bb);
                    }
                    else
                    {
                        if (b.Operacion == "M")
                        {
                            var bb = p.BannersInferiores.Where(x => x.Id == b.Id).First();

                            if (b.Stream != null)
                            {
                                using (var fileStream = File.Create(directorio + "/images/bannerinferior/" + id + "/" + b.Foto))
                                {
                                    b.Stream.CopyTo(fileStream);
                                }
                            }

                            bb.Alt = b.Alt;
                            bb.Foto = b.Foto;
                            bb.Link = b.Link;
                            bb.Orden = b.Orden;
                        }
                    }
                }
            }

            _pagina.Save();
        }

        public void GuardarSugeridos(int id, string jsonSugerencias)
        {
            var p = _pagina.Get(id);
            p.SugerenciasPagina.Clear();

            JArray sugerencias = JArray.Parse(jsonSugerencias);

            int orden = 0;
            foreach (JValue val in sugerencias)
            {
                SugerenciaPagina sp = new SugerenciaPagina();
                sp.PaginaId = id;
                sp.SugerenciaId = int.Parse((string)val.Value);
                sp.Orden = orden;
                p.SugerenciasPagina.Add(sp);

                orden++;
            }

            _pagina.Save();
        }

        public void GuardarDestacados(int id, List<Destacado> destacados, string directorio)
        {
            var p = _pagina.Get(id);

            if (!Directory.Exists(directorio + "/images/destacado/" + id))
                Directory.CreateDirectory(directorio + "/images/destacado/" + id);

            foreach (Destacado s in destacados)
            {
                if (s.Id < 0)
                    s.Operacion = "A";
                else
                    if (s.Operacion == null)
                        s.Operacion = "M";

                if (s.Operacion == "A")
                {
                    s.Id = 0;
                    p.Destacados.Add(s);

                    if (s.Stream != null)
                    {
                        using (var fileStream = File.Create(directorio + "/images/destacado/" + id + "/" + s.Foto))
                        {
                            s.Stream.CopyTo(fileStream);
                        }
                    }
                }
                else
                {
                    if (s.Operacion == "B")
                    {
                        var ss = p.Destacados.Where(x => x.Id == s.Id).First();
                        _pagina.Remove(ss);
                        p.Destacados.Remove(ss);
                    }
                    else
                    {
                        if (s.Operacion == "M")
                        {
                            var ss = p.Destacados.Where(x => x.Id == s.Id).First();

                            if (s.Stream != null)
                            {
                                using (var fileStream = File.Create(directorio + "/images/destacado/" + id + "/" + s.Foto))
                                {
                                    s.Stream.CopyTo(fileStream);

                                }
                            }

                            ss.Foto = s.Foto;
                            ss.Link = s.Link;
                            ss.Orden = s.Orden;
                            ss.Titulo = s.Titulo;
                            ss.SubTitulo = s.SubTitulo;
                            ss.SubTitulo2 = s.SubTitulo2;
                            ss.Alt = s.Alt;
                        }
                    }
                }
            }

            _pagina.Save();
        }

        public void GuardarMetaTag(MetaTag m)
        {
            var p = _pagina.Get(m.PaginaId);
            MetaTag meta = p.MetaTags.Where(x => x.Id == m.Id).FirstOrDefault();
            if (meta == null)
                meta = new MetaTag();

            meta.Title = m.Title;
            meta.Description = m.Description;
            meta.Keywords = m.Keywords;
            meta.Id = m.Id;
            meta.PaginaId = meta.PaginaId;

            p.MetaTags.Add(meta);

            _pagina.Save();
        }

        public void GuardarPaginaTexto(PaginaTexto m)
        {
            var p = _pagina.Get(m.PaginaId);
            PaginaTexto pt = p.PaginaTextos.Where(x => x.Id == m.Id).FirstOrDefault();
            if (pt == null)
                pt = new PaginaTexto();

            pt.Texto = m.Texto;
            pt.Id = m.Id;

            p.PaginaTextos.Add(pt);

            _pagina.Save();
        }

        public void RemoveBannerContextual(int id)
        {
            _pagina.RemoveBannerContextual(id);
        }

        public void GuardarBannersContextual(BannerContextual b, string directorio)
        {
            var p = _pagina.Get(b.PaginaId);

            if (!Directory.Exists(directorio + "/images/bannercontextual/" + p.Id))
                Directory.CreateDirectory(directorio + "/images/bannercontextual/" + p.Id);

            BannerContextual banner = p.BannersContextual.Where(x => x.Id == b.Id).FirstOrDefault();
            if (banner == null)
                banner = new BannerContextual();

            banner.Id = b.Id;
            banner.PaginaId = b.PaginaId;

            banner.Foto = b.Foto;
            banner.Alt = b.Alt;
            banner.Link = b.Link;
            banner.Title = b.Title;
            banner.Orden = b.Orden;

            if (b.Stream != null)
            {
                using (var fileStream = File.Create(directorio + "/images/bannercontextual/" + b.PaginaId + "/" + b.Foto))
                {
                    b.Stream.CopyTo(fileStream);
                }
            }

          

            p.BannersContextual.Add(banner);

            _pagina.Save();
        }
        public void GuardarInfoRelacion(InfoRelacion i, string directorio)
        {
            var p = _pagina.Get(i.PaginaId);

            if (!Directory.Exists(directorio + "/images/info/" + p.Id))
                Directory.CreateDirectory(directorio + "/images/info/" + p.Id);

            InfoRelacion info = p.InfoRelaciones.Where(x => x.Id == i.Id).FirstOrDefault();
            if (info == null)
                info = new InfoRelacion();

            info.Id = i.Id;
            info.PaginaId = i.PaginaId;

            info.Titulo1 = i.Titulo1;
            info.SubTitulo1 = i.SubTitulo1;
            info.Texto1 = i.Texto1;
            info.Foto1 = i.Foto1;
            info.Alt1 = i.Alt1;
            info.Link1 = i.Link1;

            if (i.Stream1 != null)
            {
                using (var fileStream = File.Create(directorio + "/images/info/" + i.PaginaId + "/" + i.Foto1))
                {
                    i.Stream1.CopyTo(fileStream);
                }
            }

            info.Titulo2 = i.Titulo2;
            info.SubTitulo2 = i.SubTitulo2;
            info.Texto2 = i.Texto2;
            info.Foto2 = i.Foto2;
            info.Alt2 = i.Alt2;
            info.Link2 = i.Link2;

            if (i.Stream2 != null)
            {
                using (var fileStream = File.Create(directorio + "/images/info/" + i.PaginaId + "/" + i.Foto2))
                {
                    i.Stream2.CopyTo(fileStream);
                }
            }

            info.Titulo3 = i.Titulo3;
            info.SubTitulo3 = i.SubTitulo3;
            info.Texto3 = i.Texto3;
            info.Foto3 = i.Foto3;
            info.Alt3 = i.Alt3;
            info.Link3 = i.Link3;

            if (i.Stream3 != null)
            {
                using (var fileStream = File.Create(directorio + "/images/info/" + i.PaginaId + "/" + i.Foto3))
                {
                    i.Stream3.CopyTo(fileStream);
                }
            }

            info.Titulo4 = i.Titulo4;
            info.SubTitulo4 = i.SubTitulo4;
            info.Texto4 = i.Texto4;
            info.Foto4 = i.Foto4;
            info.Alt4 = i.Alt4;
            info.Link4 = i.Link4;

            if (i.Stream4 != null)
            {
                using (var fileStream = File.Create(directorio + "/images/info/" + i.PaginaId + "/" + i.Foto4))
                {
                    i.Stream4.CopyTo(fileStream);
                }
            }

            p.InfoRelaciones.Add(info);

            _pagina.Save();
        }

        public void Order(string jsonOrden)
        {
            JArray ids = JArray.Parse(jsonOrden);
            int orden = 0;
            foreach (JValue id in ids)
            {
                var p = _pagina.Get(int.Parse((string)id.Value));
                p.Orden = orden;
                orden++;
            }

            _pagina.Save();
        }
    }
}
