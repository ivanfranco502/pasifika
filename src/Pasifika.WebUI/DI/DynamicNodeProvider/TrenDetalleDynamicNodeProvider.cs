using MvcSiteMapProvider;
using Pasifika.Business.Abstract;
using Pasifika.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasifika.WebUI.DI.DynamicNodeProvider
{
    public class TrenDetalleDynamicNodeProvider : DynamicNodeProviderBase
    {
        private readonly IViajeBusiness _viajes;
        public TrenDetalleDynamicNodeProvider(IViajeBusiness v)
        {
            this._viajes = v;
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var viajes = _viajes.Get(1, 3);

            foreach (var v in viajes)
            {
                DynamicNode dynamicNode = new DynamicNode();

                dynamicNode.Title = v.Nombre;
                dynamicNode.Key = "TrenDestalle_" + v.Id;

                dynamicNode.RouteValues.Add("urlDestino", ((ViajeTipo1)v).Destino.Url);
                dynamicNode.RouteValues.Add("url", v.Url);

                yield return dynamicNode;
            }
        }
    }
}