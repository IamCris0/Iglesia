using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Solicitudes.Vistas
{
    public class VSolicitudSacramental
    {
        public int IdSolicitudSacramental { get; set; }
        public string Laico { get; set; }
        public string Sacramento { get; set; }
        public string FechaSolicitada { get; set; }
        public string FechaFinal { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }

        public VSolicitudSacramental() { }

        public VSolicitudSacramental(
            int idSolicitudSacramental,
            string laico,
            string sacramento,
            string fechaSolicitada,
            string fechaFinal,
            string estado,
            string observaciones
        )
        {
            IdSolicitudSacramental = idSolicitudSacramental;
            Laico = laico;
            Sacramento = sacramento;
            FechaSolicitada = fechaSolicitada;
            FechaFinal = fechaFinal;
            Estado = estado;
            Observaciones = observaciones;
        }
    }
}
