using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas
{
    public class MovimientoParroquial
    {
        public int IdMovimientoParroquial { get; set; }
        public int IdFondoParroquial { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public int? IdEventoParroquial { get; set; }

        // Constructor vacío
        public MovimientoParroquial() { }

        // Constructor completo
        public MovimientoParroquial(
            int idMovimientoParroquial,
            int idFondoParroquial,
            DateTime fecha,
            string tipo,
            string descripcion,
            decimal monto,
            int? idEventoParroquial)
        {
            IdMovimientoParroquial = idMovimientoParroquial;
            IdFondoParroquial = idFondoParroquial;
            Fecha = fecha;
            Tipo = tipo;
            Descripcion = descripcion;
            Monto = monto;
            IdEventoParroquial = idEventoParroquial;
        }
    }
}
