using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Reportes
{
    public class VReporteLaicoDetalle
    {
        public VReporteLaicoDetalle() { }

        public VReporteLaicoDetalle(int idLaico, string laico, int? idCapilla, string capilla, int? idFormacion, string formacion, string estadoFormacion, DateTime? fechaInicioFormacion, DateTime? fechaFinFormacion, string rolFuncional)
        {
            IdLaico = idLaico;
            Laico = laico;
            IdCapilla = idCapilla;
            Capilla = capilla;
            IdFormacion = idFormacion;
            Formacion = formacion;
            EstadoFormacion = estadoFormacion;
            FechaInicioFormacion = fechaInicioFormacion;
            FechaFinFormacion = fechaFinFormacion;
            RolFuncional = rolFuncional;
        }

        public int IdLaico { get; set; }
        public string Laico { get; set; }
        public int? IdCapilla { get; set; } 
        public string Capilla { get; set; }

        public int? IdFormacion { get; set; }
        public string Formacion { get; set; }
        public string EstadoFormacion { get; set; }
        public DateTime? FechaInicioFormacion { get; set; }
        public DateTime? FechaFinFormacion { get; set; }

        public string RolFuncional { get; set; }
    }
}
