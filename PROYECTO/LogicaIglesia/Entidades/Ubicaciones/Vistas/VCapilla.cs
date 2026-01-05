using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Ubicaciones.Vistas
{
    public class VCapilla
    {
        private int idCapilla;
        private string nombre;
        private string direccion;
        private string parroquia;
        private string coordinador;

        public VCapilla()
        {
        }

        public VCapilla(int idCapilla, string nombre, string direccion, string idParroquia, string idLaicoCoordinador)
        {
            this.IdCapilla = idCapilla;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Parroquia = idParroquia;
            this.Coordinador = idLaicoCoordinador;
        }



        public int IdCapilla { get => idCapilla; set => idCapilla = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Parroquia { get => parroquia; set => parroquia = value; }
        public string Coordinador { get => coordinador; set => coordinador = value; }
    }
}
