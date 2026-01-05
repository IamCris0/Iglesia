using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Eventos
{
    public class Misa
    {
        public int IdMisa { get; set; }
        public int IdCapilla { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? MontoRecaudado { get; set; }
        public string Estado { get; set; }
        public int? IdSacerdote { get; set; }
        public int? IdSolicitudSacramental { get; set; }

        // Constructor vacío (OBLIGATORIO)
        public Misa() { }

        // Constructor para insertar
        public Misa(
            int idCapilla,
            int? idSacerdote,
            DateTime fecha,
            decimal montoRecaudado,
            string estado,
            int? idSolicitudSacramental
        )
        {
            IdCapilla = idCapilla;
            Fecha = fecha;
            MontoRecaudado = montoRecaudado;
            Estado = estado;
            IdSacerdote = idSacerdote;
            IdSolicitudSacramental = idSolicitudSacramental;
        }

        // Constructor para actualizar
        public Misa(
            int idMisa,
            int idCapilla,
            int? idSacerdote,
            DateTime fecha,
            decimal montoRecaudado,
            string estado,
            int? idSolicitudSacramental
        )
        {
            IdMisa = idMisa;
            IdCapilla = idCapilla;
            Fecha = fecha;
            MontoRecaudado = montoRecaudado;
            Estado = estado;
            IdSacerdote = idSacerdote;
            IdSolicitudSacramental = idSolicitudSacramental;
        }
    }
}
