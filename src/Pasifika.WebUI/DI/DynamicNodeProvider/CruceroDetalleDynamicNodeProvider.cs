using MvcSiteMapProvider;
using Pasifika.Business.Abstract;
using Pasifika.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasifika.WebUI.DI.DynamicNodeProvider
{
    public class CruceroDetalleDynamicNodeProvider : DynamicNodeProviderBase
    {
        private readonly IViajeBusiness _viajes;
        public CruceroDetalleDynamicNodeProvider(IViajeBusiness v)
        {
            this._viajes = v;
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var viajes = _viajes.Get(1, 2);

            foreach (var v in viajes)
            {
                DynamicNode dynamicNode = new DynamicNode();

                dynamicNode.Title = v.Nombre;
                dynamicNode.Key = "cruceroDestalle_" + v.Id;

                dynamicNode.RouteValues.Add("urlDestino", ((ViajeTipo1)v).Destino.Url);
                dynamicNode.RouteValues.Add("url", v.Url);

                yield return dynamicNode;
            }
        }
    }
}