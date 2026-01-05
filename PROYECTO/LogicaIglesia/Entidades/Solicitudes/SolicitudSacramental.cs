using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Solicitudes
{
    public class SolicitudSacramental
    {
        public int IdSolicitudSacramental { get; set; }
        public int IdLaico { get; set; }
        public string Sacramento { get; set; }
        public DateTime FechaSolicitada { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }

        public SolicitudSacramental() { }

        public SolicitudSacramental(
            int idSolicitudSacramental,
            int idLaico,
            string sacramento,
            DateTime fechaSolicitada,
            DateTime? fechaFinal,
            string estado,
            string observaciones
        )
        {
            IdSolicitudSacramental = idSolicitudSacramental;
            IdLaico = idLaico;
            Sacramento = sacramento;
            FechaSolicitada = fechaSolicitada;
            FechaFinal = fechaFinal;
            Estado = estado;
            Observaciones = observaciones;
        }
    }
}
