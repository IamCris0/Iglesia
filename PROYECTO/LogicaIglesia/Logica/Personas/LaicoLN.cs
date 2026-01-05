using Datos.Personas;
using Entidades.Personas.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Personas
{
    public class LaicoLN
    {
        public List<Entidades.Personas.Vistas.VLaico> Listar(string filtro)
        {
            List<Entidades.Personas.Vistas.VLaico> lista = new List<VLaico>();

            try
            {
                var datos = LaicoCD.Listar(filtro);

                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Personas.Vistas.VLaico(
                        item.idLaico,
                        item.Nombres,
                        item.Apellidos,
                        item.Capilla,
                        item.Telefono,
                        item.Activo
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Laico", ex);
            }

            return lista;
        }

        public Entidades.Personas.Laico ObtenerPorId(int id)
        {
            try
            {
                var aux = LaicoCD.BuscarPorId(id);
                if (aux == null) return null;

                return new Entidades.Personas.Laico(
                    aux.idLaico,
                    aux.Nombres,
                    aux.Apellidos,
                    aux.Telefono,
                    (int)aux.idCapilla,
                    aux.Activo
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener Laico", ex);
            }
        }

        public int Insertar(Entidades.Personas.Laico oc)
        {
            try
            {
                return LaicoCD.Insertar(oc);

            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Laico", ex);
            }
        }

        public bool Modificar(Entidades.Personas.Laico oc)
        {
            try
            {
                LaicoCD.Modificar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Laico", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                LaicoCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Laico", ex);
            }
        }
    }
}
