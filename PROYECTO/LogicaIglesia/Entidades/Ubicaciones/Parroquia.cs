using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ubicaciones
{
    public class Parroquia
    {
        public int IdParroquia { get; set; }
        public string Nombre { get; set; }
        public string Zona { get; set; }

        public Parroquia() { }

        public Parroquia(int idParroquia, string nombre, string zona)
        {
            IdParroquia = idParroquia;
            Nombre = nombre;
            Zona = zona;
        }
    }
}
