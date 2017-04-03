using MvcSiteMapProvider.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasifika.WebUI.DI.Ninject.Modules
{
    public class MyReservedAttributeNameProvider : ReservedAttributeNameProvider
    {
        public MyReservedAttributeNameProvider(
        IEnumerable<string> attributesToIgnore
        )
            : base(attributesToIgnore)
        {
        }

        public override bool IsRouteAttribute(string attributeName)
        {
            return attributeName != "visibility"
                && !attributesToIgnore.Contains(attributeName)
                && !attributeName.StartsWith("data-");
        }
    }
}