using MvcSiteMapProvider;
using Pasifika.Business.Abstract;
using Pasifika.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasifika.WebUI.DI.DynamicNodeProvider
{
    public class HotelDetalleDynamicNodeProvider : DynamicNodeProviderBase
    {
        private readonly IViajeBusiness _viajes;

        public HotelDetalleDynamicNodeProvider(IViajeBusiness v)
        {
            this._viajes = v;
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var viajes = _viajes.Get(2, 1);

            foreach (var v in viajes)
            {
                DynamicNode dynamicNode = new DynamicNode();

                dynamicNode.Title = v.Nombre;
                dynamicNode.Key = "HotelDestalle_" + v.Id;
                dynamicNode.ParentKey = "HotelListado_" + ((ViajeTipo2)v).Ciudad.Destino.Id;

                dynamicNode.RouteValues.Add("urlDestino", ((ViajeTipo2)v).Ciudad.Destino.Url);
                dynamicNode.RouteValues.Add("urlCiudad", ((ViajeTipo2)v).Ciudad.Url);
                dynamicNode.RouteValues.Add("url", v.Url);

                yield return dynamicNode;
            }
        }
    }
}