using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Reportes
{
    public class VReporteLaicoDetalleCD
    {
        public static List<sp_Reporte_Laico_DetalleResult> Listar(string filtro, int? idCapilla, int? idFormacion, string estado)
        {
            string f = string.IsNullOrWhiteSpace(filtro) ? null : filtro;
            string e = string.IsNullOrWhiteSpace(estado) ? null : estado;
            int? ic = (idCapilla <= 0) ? null : idCapilla;
            int? iform = (idFormacion <= 0) ? null : idFormacion;

            using (var db = new DControlDataContext())
            {
                return db.sp_Reporte_Laico_Detalle(f, ic, iform, e).ToList();
            }
        }
    }
}
