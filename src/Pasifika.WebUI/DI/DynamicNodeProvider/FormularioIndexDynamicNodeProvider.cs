using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasifika.WebUI.DI.DynamicNodeProvider
{
    public class FormularioIndexDynamicNodeProvider : DynamicNodeProviderBase 
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            DynamicNode dynamicNode = new DynamicNode();
            dynamicNode.Title = "Contacto";
            dynamicNode.Key = "Contacto";
            dynamicNode.RouteValues.Add("tipo", 1);

            yield return dynamicNode;

            dynamicNode = new DynamicNode();
            dynamicNode.Title = "Catálogo";
            dynamicNode.Key = "Catalogo";
            dynamicNode.RouteValues.Add("tipo", 2);

            yield return dynamicNode;

            dynamicNode = new DynamicNode();
            dynamicNode.Title = "Sesiones informativas";
            dynamicNode.Key = "Sesiones";
            dynamicNode.RouteValues.Add("tipo", 3);

            yield return dynamicNode;
        } 
    }
}