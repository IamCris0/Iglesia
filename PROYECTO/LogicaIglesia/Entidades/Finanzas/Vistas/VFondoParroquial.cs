using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Finanzas.Vistas
{
    public class VFondoParroquial
    {
        public VFondoParroquial(int idFondoParroquial, string nombre, string descripcion, string idParroquia, decimal saldo)
        {
            IdFondoParroquial = idFondoParroquial;
            Nombre = nombre;
            Descripcion = descripcion;
            IdParroquia = idParroquia;
            Saldo = saldo;
        }

        public VFondoParroquial()
        {

        }
        public int IdFondoParroquial { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string IdParroquia { get; set; }
        public decimal Saldo { get; set; }
    }
}
