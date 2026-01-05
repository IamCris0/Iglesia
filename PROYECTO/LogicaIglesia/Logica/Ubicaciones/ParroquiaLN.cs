using Datos.Ubicaciones;
using Entidades.Ubicaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Ubicaciones
{
    public class ParroquiaLN
    {
        public List<Parroquia> Listar()
        {
            try
            {
                var lista = new List<Parroquia>();
                var datos = ParroquiaCD.Listar();

                foreach (var item in datos)
                {
                    lista.Add(new Parroquia(
                        item.idParroquia,
                        item.Nombre,
                        item.Zona
                    ));
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar parroquias", ex);
            }
        }

        public Parroquia Obtener(int id)
        {
            try
            {
                var obj = ParroquiaCD.BuscarPorId(id);
                if (obj == null) return null;

                return new Parroquia(obj.idParroquia, obj.Nombre, obj.Zona);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener parroquia", ex);
            }
        }

        public bool Insertar(Parroquia p)
        {
            ParroquiaCD.Insertar(p);
            return true;
        }

        public bool Modificar(Parroquia p)
        {
            ParroquiaCD.Modificar(p);
            return true;
        }

        public bool Eliminar(int id)
        {
            ParroquiaCD.Eliminar(id);
            return true;
        }
    }
}
