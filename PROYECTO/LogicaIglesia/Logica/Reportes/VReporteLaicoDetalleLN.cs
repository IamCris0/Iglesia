using Datos.Reportes;
using Datos.Roles;
using Entidades.Reportes;
using Entidades.Roles.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Reportes
{
    public class VReporteLaicoDetalleLN
    {
        public List<Entidades.Reportes.VReporteLaicoDetalle> Listar(string filtro, int? idCapilla, int? idFormacion, string estado)
        {
            List<Entidades.Reportes.VReporteLaicoDetalle> lista = new List<VReporteLaicoDetalle>();

            try
            {
                var datos = VReporteLaicoDetalleCD.Listar(filtro, idCapilla, idFormacion, estado);

                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Reportes.VReporteLaicoDetalle(
                            item.idLaico,
                            item.Laico,
                            item.idCapilla,
                            item.Capilla,
                            item.idFormacion,
                            item.Formacion,
                            item.EstadoFormacion,
                            item.FechaInicioFormacion,
                            item.FechaFinFormacion, 
                            item.RolFuncional
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar LaicoRolFuncional", ex);
            }
            return lista;
        }
    }
}
