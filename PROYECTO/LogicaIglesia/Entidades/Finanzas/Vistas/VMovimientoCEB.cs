using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.Vistas
{
    public class VMovimientoCEB
    {
        public VMovimientoCEB()
        {
        }

        public VMovimientoCEB(int idMovimientoCEB, string cEB, string fondoCapilla, string eventoCapilla, string fecha, string tipo, string descripcion, decimal monto)
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
        public string CEB { get; set; }
        public string FondoCapilla { get; set; }
        public string EventoCapilla { get; set; }
        public string Fecha { get; set; }
        public string Tipo { get; set; }        
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
