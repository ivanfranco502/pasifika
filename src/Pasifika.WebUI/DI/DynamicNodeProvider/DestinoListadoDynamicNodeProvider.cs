using MvcSiteMapProvider;
using Pasifika.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasifika.WebUI.DI.DynamicNodeProvider
{
    public class DestinoListadoDynamicNodeProvider : DynamicNodeProviderBase
    {
        private readonly IDestinoBusiness _destino;
        public DestinoListadoDynamicNodeProvider(IDestinoBusiness d)
        {
            this._destino = d;
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var destinos = _destino.Get();

            foreach (var d in destinos)
            {
                DynamicNode dynamicNode = new DynamicNode();

                dynamicNode.Title = "Viajes a " + d.Nombre;
                dynamicNode.Key = "DestinoViajeListado_" + d.Id;
                //dynamicNode.ParentKey = "DestinoViaje_" + d.Id;

                dynamicNode.RouteValues.Add("url", d.Url);

                yield return dynamicNode;
            }
        }
    }
}