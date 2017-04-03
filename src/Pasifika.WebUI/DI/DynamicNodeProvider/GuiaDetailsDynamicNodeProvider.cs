using MvcSiteMapProvider;
using Pasifika.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasifika.WebUI.DI.DynamicNodeProvider
{
    public class GuiaDetailsDynamicNodeProvider : DynamicNodeProviderBase 
    {
        private readonly IDestinoBusiness _destino;
        public GuiaDetailsDynamicNodeProvider(IDestinoBusiness d)
        {
            this._destino = d;
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var destinoDB = _destino.Get();
            
            // Create a node for each nota 
            foreach (var destino in destinoDB)
            {
                DynamicNode dynamicNode = new DynamicNode();
                dynamicNode.Title = "Guía de viaje de " + destino.Nombre;
                dynamicNode.Key = "Destino_" + destino.Id;
                dynamicNode.RouteValues.Add("destino", destino.Url);

                yield return dynamicNode;
            }
        } 
    }
}