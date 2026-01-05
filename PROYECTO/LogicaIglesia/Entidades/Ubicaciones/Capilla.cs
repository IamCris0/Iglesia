using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ubicaciones
{
    public class Capilla
    {
        private int idCapilla;
        private string nombre;
        private string direccion;
        private int idParroquia;
        private int idLaicoCoordinador;

        public Capilla(int idCapilla, string nombre, string direccion, int idParroquia, int idLaicoCoordinador)
        {
            this.IdCapilla = idCapilla;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.IdParroquia = idParroquia;
            this.IdLaicoCoordinador = idLaicoCoordinador;
        }

        public Capilla(string nombre, string direccion, int idParroquia)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.IdParroquia = idParroquia;
        }
        public Capilla ()
        {

        }

        public int IdCapilla { get => idCapilla; set => idCapilla = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int IdParroquia { get => idParroquia; set => idParroquia = value; }
        public int IdLaicoCoordinador { get => idLaicoCoordinador; set => idLaicoCoordinador = value; }
    }
}
