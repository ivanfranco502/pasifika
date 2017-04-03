using MvcSiteMapProvider;
using Pasifika.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasifika.WebUI.DI.DynamicNodeProvider
{
    public class ExcursionListadoDynamicNodeProvider : DynamicNodeProviderBase
    {
        private readonly IDestinoBusiness _destino;
        public ExcursionListadoDynamicNodeProvider(IDestinoBusiness d)
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
                            && c.Viajes.Any(x => (x is Pasifika.Model.Excursion && !x.Eliminado))
                         group d by d into destinogroup
                         select destinogroup;

            foreach (var d in result)
            {
                DynamicNode dynamicNode = new DynamicNode();

                dynamicNode.Title = " Excursiones en " + d.Key.Nombre;
                dynamicNode.Key = "ExcursionListado_" + d.Key.Id;

                dynamicNode.RouteValues.Add("url", d.Key.Url);

                yield return dynamicNode;
            }
        }
    }
}