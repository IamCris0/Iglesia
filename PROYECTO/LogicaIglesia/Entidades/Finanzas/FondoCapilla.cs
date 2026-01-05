using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas
{
    public class FondoCapilla
    {
        public FondoCapilla()
        {
        }

        public FondoCapilla(int idFondoCapilla, string nombre, string descripcion, int idCapilla, decimal saldo)
        {
            IdFondoCapilla = idFondoCapilla;
            Nombre = nombre;
            Descripcion = descripcion;
            IdCapilla = idCapilla;
            Saldo = saldo;
        }

        public int IdFondoCapilla { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdCapilla { get; set; }
        public decimal Saldo { get; set; }
    }
}
