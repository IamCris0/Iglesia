using Datos.Personas;
using Entidades.Personas.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Personas
{
    public class SacerdoteLN
    {
        public List<Entidades.Personas.Sacerdote> Listar()
        {
            List<Entidades.Personas.Sacerdote> lista = new List<Entidades.Personas.Sacerdote>();

            try
            {
                var datos = SacerdoteCD.Listar();

                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Personas.Sacerdote(
                             item.idSacerdote,
                             item.Nombres,
                             item.Apellidos,
                             item.Apodo
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Sacerdote", ex);
            }

            return lista;
        }

        public Entidades.Personas.Sacerdote ObtenerPorId(int id)
        {
            try
            {
                var item = SacerdoteCD.BuscarPorId(id);
                if (item == null) return null;

                return new Entidades.Personas.Sacerdote(
                        item.idSacerdote,
                        item.Nombres,
                        item.Apellidos,
                        item.Apodo
                             );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener Sacerdote", ex);
            }
        }

        public void Insertar(Entidades.Personas.Sacerdote oc)
        {
            try
            {
                SacerdoteCD.Insertar(oc);

            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Sacerdote", ex);
            }
        }

        public bool Modificar(Entidades.Personas.Sacerdote oc)
        {
            try
            {
                SacerdoteCD.Modificar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Sacerdote", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                SacerdoteCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Sacerdote", ex);
            }
        }
    }
}
