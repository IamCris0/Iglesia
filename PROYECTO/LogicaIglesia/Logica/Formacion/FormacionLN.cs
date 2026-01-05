using Datos.Formacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Formacion
{
    public class FormacionLN
    {
        public List<Entidades.Formacion.Formacion> Listar(string filtro)
        {
            List<Entidades.Formacion.Formacion> lista = new List<Entidades.Formacion.Formacion>();

            try
            {
                var datos = FormacionCD.Listar(filtro);
                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Formacion.Formacion(
                        item.idFormacion,
                        item.Nombre,
                        item.Descripcion
                        ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Formacion", ex);
            }

            return lista;
        }

        public Entidades.Formacion.Formacion ObtenerPorId(int id)
        {
            try
            {
                var aux = FormacionCD.BuscarPorId(id);
                if (aux == null) return null;

                return new Entidades.Formacion.Formacion(
                    aux.idFormacion,
                    aux.Nombre,
                    aux.Descripcion
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener Formacion", ex);
            }
        }

        public bool Insertar(Entidades.Formacion.Formacion of)
        {
            try
            {
                FormacionCD.Insertar(of);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Formacion", ex);
            }
        }

        public bool Modificar(Entidades.Formacion.Formacion of)
        {
            try
            {
                FormacionCD.Modificar(of);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Formacion", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                FormacionCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Formacion", ex);
            }
        }
    }
}
