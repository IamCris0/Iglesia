using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.Vistas
{
    public class VMovimientoParroquial
    {
        public int IdMovimientoParroquial { get; set; }
        public string FondoParroquial { get; set; }
        public string EventoParroquial { get; set; }
        public string Fecha { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

        // Constructor vacío
        public VMovimientoParroquial() { }

        // Constructor completo
        public VMovimientoParroquial(
            int idMovimientoParroquial,
            string fondoParroquial,
            string eventoParroquial,
            string fecha,
            string tipo,
            string descripcion,
            decimal monto)
        {
            IdMovimientoParroquial = idMovimientoParroquial;
            FondoParroquial = fondoParroquial;
            EventoParroquial = eventoParroquial;
            Fecha = fecha;
            Tipo = tipo;
            Descripcion = descripcion;
            Monto = monto;
        }
    }
}
