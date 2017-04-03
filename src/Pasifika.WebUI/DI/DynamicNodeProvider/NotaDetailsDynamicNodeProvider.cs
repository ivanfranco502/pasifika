using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Pasifika.Business.Abstract;

namespace Pasifika.WebUI.DI.DynamicNodeProvider
{
    public class NotaDetailsDynamicNodeProvider : DynamicNodeProviderBase 
    {
        private readonly INotaBusiness _nota;
        public NotaDetailsDynamicNodeProvider(INotaBusiness n)
        {
            this._nota = n;
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var notaDB = _nota.Get(null, null, null);
            
            // Create a node for each nota 
            foreach (var nota in notaDB)
            {
                DynamicNode dynamicNode = new DynamicNode();
                dynamicNode.Title = nota.Titulo;
                //dynamicNode.ParentKey = "Notas";
                dynamicNode.Key = "Nota_" + nota.Id;
                dynamicNode.RouteValues.Add("url", nota.Url);

                yield return dynamicNode;
            }

        } 
    }
}