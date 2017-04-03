using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class ViajeTag
    {
        [Key, Column(Order = 0)]
        public int TagId { get; set; }
        [Key, Column(Order = 1)]
        public int ViajeId { get; set; }
        public int Orden { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Viaje Viaje { get; set; }
    }
}
