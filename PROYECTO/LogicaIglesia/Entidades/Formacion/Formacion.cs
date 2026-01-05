using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Formacion
{
    public class Formacion
    {
        private int idFormacion;
        private string nombre;
        private string descripcion;

        public Formacion(int idFormacion, string nombre, string descripcion)
        {
            this.idFormacion = idFormacion;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public Formacion(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public Formacion() { }

        public int IdFormacion { get => idFormacion; set => idFormacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
