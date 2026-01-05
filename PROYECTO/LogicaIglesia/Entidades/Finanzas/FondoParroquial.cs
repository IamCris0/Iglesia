using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas
{
    public class FondoParroquial
    {
        public FondoParroquial()
        {
        }

        public FondoParroquial(int idFondoParroquial, string nombre, string descripcion, int idParroquia, decimal saldo)
        {
            IdFondoParroquial = idFondoParroquial;
            Nombre = nombre;
            Descripcion = descripcion;
            IdParroquia = idParroquia;
            Saldo = saldo;
        }

        public int IdFondoParroquial { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdParroquia { get; set; }
        public decimal Saldo { get; set; }
    }
}
