using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Formacion.Vistas
{
    public class VLaicoFormacion
    {
        public VLaicoFormacion(int idLaicoFormacion, string laico, string formacion, string estado, string fechaInicio, string fechaFin)
        {
            IdLaicoFormacion = idLaicoFormacion;
            Laico = laico;
            Formacion = formacion;
            Estado = estado;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }

        public VLaicoFormacion() { }

        public int IdLaicoFormacion { get; set; }
        public string Laico { get; set; }
        public string Formacion { get; set; }
        public string Estado { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
}
