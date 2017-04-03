using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;
using System.IO;

namespace Pasifika.Business.Abstract
{
    public interface IViajeBusiness
    {
        List<Viaje> Get();
        List<Viaje> Get(int TipoViaje, int SubTipoViaje);
        List<Viaje> Get(int TipoViaje, int SubTipoViaje, int? presupuestoDesde, int? presupuestoHasta, int? duracionDesde, int? duracionHasta, List<int> tags, int? destinoId, int? ciudadId);
        Viaje Get(int id);
        Viaje GetByUrl(string url);
        void Guardar(int Id, int TipoViaje, int SubTipoViaje, string Nombre, string Url, int? Duracion, int Precio, string InfoPrecio, string Paises, string Ciudades, string Referencia, string PDF, string ImagenListado, string AltImagenListado, string Tags, List<Foto> Fotos, string Descripcion, string Itinerario, string Alojamiento, string Actividades, string Translados, string CuandoIr, string Presupuesto, string Comentarios, int? DestinoId, int? CiudadId, string InformacionGeneral, string Importante, string Condicion, string NombreCrucero, string TituloCuadro, string TextoCuadro, string directorio, Stream filePDF = null, Stream fileImagenListado = null);
        void Delete(int Id);
        void Order(string jsonOrden);
    }
}
