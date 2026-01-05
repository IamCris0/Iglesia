using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.Vistas
{
    public class VFondoCapilla
    {
        public VFondoCapilla(int idFondoCapilla, string nombre, string descripcion, string capilla, decimal saldo)
        {
            IdFondoCapilla = idFondoCapilla;
            Nombre = nombre;
            Descripcion = descripcion;
            Capilla = capilla;
            Saldo = saldo;
        }
        public VFondoCapilla()
        {

        }

        public int IdFondoCapilla { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Capilla { get; set; }
        public decimal Saldo { get; set; }


    }
}
