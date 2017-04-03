using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Business.Abstract
{
    public interface IExcelExportBusiness
    {
        Byte[] GetExcel(DataTable data);
    }
}
