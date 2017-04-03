using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Model
{
    public class MetaTag
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }
        [MaxLength(800)]
        public string Description { get; set; }
        [MaxLength(800)]
        public string Keywords { get; set; }

        public int PaginaId { get; set; }
        public virtual Pagina Pagina { get; set; }
    }
}
