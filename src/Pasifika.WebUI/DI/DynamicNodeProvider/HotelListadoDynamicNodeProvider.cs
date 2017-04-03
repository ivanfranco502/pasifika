using MvcSiteMapProvider;
using Pasifika.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasifika.WebUI.DI.DynamicNodeProvider
{
    public class HotelListadoDynamicNodeProvider : DynamicNodeProviderBase
    {
        private readonly IDestinoBusiness _destino;
        public HotelListadoDynamicNodeProvider(IDestinoBusiness d)
        {
            this._destino = d;
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var destinos = _destino.Get();

            var result = from d in destinos
                         from c in d.Ciudades
                         where
                            c.Eliminado == false
                            && c.Viajes.Any(x => (x is Pasifika.Model.Hotel && !x.Eliminado))
                         group d by d into destinogroup
                         select destinogroup;

            foreach (var d in result)
            {
                DynamicNode dynamicNode = new DynamicNode();

                dynamicNode.Title = "Hoteles de lujo en " + d.Key.Nombre;
                dynamicNode.Key = "HotelListado_" + d.Key.Id;

                dynamicNode.RouteValues.Add("url", d.Key.Url);

                yield return dynamicNode;
            }
        }
    }
}