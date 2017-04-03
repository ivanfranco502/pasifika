using MvcSiteMapProvider;
using Pasifika.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasifika.WebUI.DI.DynamicNodeProvider
{
    public class InteresPortadaDynamicNodeProvider : DynamicNodeProviderBase
    {
        private readonly ITagBusiness _tag;
        public InteresPortadaDynamicNodeProvider(ITagBusiness t)
        {
            this._tag = t;
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var tags = _tag.Get();
            
            string[] urlTags = new string[8];
            urlTags[0] = "viajes-a-medida";
            urlTags[1] = "viajes-de-novios";
            urlTags[2] = "viajes-en-familia";
            urlTags[3] = "vueltas-al-mundo";
            urlTags[4] = "viajes-combinados";
            urlTags[5] = "viajes-de-lujo";
            urlTags[6] = "high-end-travel";
            urlTags[7] = "wellness-y-Spa-de-lujo";

            var urls = urlTags.Cast<string>().ToList();

            var lst = from t in tags
                      where urls.Contains(t.Url)
                      select t;

            foreach (var t in lst)
            {
                DynamicNode dynamicNode = new DynamicNode();

                dynamicNode.Title = t.Descripcion + " destacados";
                dynamicNode.Key = "InteresTag_" + t.Id;

                dynamicNode.RouteValues.Add("url", t.Url);

                yield return dynamicNode;
            }
        }
    }
}