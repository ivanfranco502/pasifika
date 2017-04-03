using MvcSiteMapProvider;
using Pasifika.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasifika.WebUI.DI.DynamicNodeProvider
{
    public class NotaIndexDynamicNodeProvider : DynamicNodeProviderBase
    {
        private readonly INotaBusiness _nota;
        public NotaIndexDynamicNodeProvider(INotaBusiness n)
        {
            this._nota = n;
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var notaDB = _nota.Get(null, null, null);
            
            // create node for each year month nota
            var qNotas = from n in notaDB
                         group n by n.Fecha.Year into notasAnos

                         orderby notasAnos.Key descending
                         select new
                         {
                             year = notasAnos.Key,
                             months = from o in notasAnos
                                      group o by o.Fecha.Month into notasMeses
                                      select new
                                      {
                                          month = notasMeses.Key,
                                          notas = notasMeses.OrderByDescending(x => x.Fecha)
                                      }
                         };

            foreach (var y in qNotas.ToList())
            {
                foreach(var m in y.months)
                {
                    DynamicNode dynamicNode = new DynamicNode();
                    
                    //string text = m.notas.First().Fecha.ToString("MMMM", System.Globalization.CultureInfo.CurrentCulture);
                    //dynamicNode.Title = "nota de " + char.ToUpper(text[0]) + ((text.Length > 1) ? text.Substring(1).ToLower() : string.Empty) +":";
                    dynamicNode.Title = "Notas"; 
                    //dynamicNode.ParentKey = "Notas";
                    dynamicNode.Key = "Notas_de_"+ y.year.ToString() +"_" + m.month.ToString();

                    dynamicNode.RouteValues.Add("mes", m.month);
                    dynamicNode.RouteValues.Add("ano", y.year);

                    yield return dynamicNode;
                }
            }
        }
    }
}