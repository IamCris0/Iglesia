using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas
{
    public class MovimientoCEB
    {
        public MovimientoCEB()
        {
        }

        public MovimientoCEB(int idMovimientoCEB, int cEB, int fondoCapilla, int eventoCapilla, DateTime fecha, string tipo, string descripcion, decimal monto)
        {
            IdMovimientoCEB = idMovimientoCEB;
            CEB = cEB;
            FondoCapilla = fondoCapilla;
            EventoCapilla = eventoCapilla;
            Fecha = fecha;
            Tipo = tipo;
            Descripcion = descripcion;
            Monto = monto;
        }

        public int IdMovimientoCEB { get; set; }
        public int CEB { get; set; }
        public int FondoCapilla { get; set; }
        public int EventoCapilla { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }     
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
