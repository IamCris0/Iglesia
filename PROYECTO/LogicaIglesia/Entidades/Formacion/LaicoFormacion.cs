using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Formacion
{
    public class LaicoFormacion
    {
        public int IdLaicoFormacion { get; set; }
        public int IdLaico { get; set; }
        public int IdFormacion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public LaicoFormacion() { }

        public LaicoFormacion(int idLaico, int idFormacion, string estado, DateTime fechaInicio)
        {
            IdLaico = idLaico;
            IdFormacion = idFormacion;
            Estado = estado;
            FechaInicio = fechaInicio;
        }

        public LaicoFormacion(
            int id,
            int idLaico,
            int idFormacion,
            string estado,
            DateTime fechaInicio,
            DateTime? fechaFin
        )
        {
            IdLaicoFormacion = id;
            IdLaico = idLaico;
            IdFormacion = idFormacion;
            Estado = estado;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }
    }
}
