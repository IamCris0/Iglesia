using Datos.Roles;
using Entidades.Roles.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Roles
{
    public class LaicoRolFuncionalLN
    {
        public List<Entidades.Roles.Vistas.VLaicoRolFuncional> Listar(string filtro)
        {
            List<Entidades.Roles.Vistas.VLaicoRolFuncional> lista = new List<VLaicoRolFuncional>();

            try
            {
                var datos = LaicoRolFuncionalCD.Listar(filtro);

                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Roles.Vistas.VLaicoRolFuncional(
                        item.idLaicoRolFuncional,
                        item.Laico,
                        item.Rol
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar LaicoRolFuncional", ex);
            }

            return lista;
        }

        public Entidades.Roles.LaicoRolFuncional ObtenerPorId(int id)
        {
            try
            {
                var aux = LaicoRolFuncionalCD.BuscarPorId(id);
                if (aux == null) return null;

                return new Entidades.Roles.LaicoRolFuncional(
                    aux.idLaicoRolFuncional,
                    aux.idLaico,
                    aux.idRolFuncional
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener LaicoRolFuncional", ex);
            }
        }

        public bool Insertar(Entidades.Roles.LaicoRolFuncional oc)
        {
            try
            {
                LaicoRolFuncionalCD.Insertar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar LaicoRolFuncional", ex);
            }
        }

        public bool Modificar(Entidades.Roles.LaicoRolFuncional oc)
        {
            try
            {
                LaicoRolFuncionalCD.Modificar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar LaicoRolFuncional", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                LaicoRolFuncionalCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar LaicoRolFuncional", ex);
            }
        }
    }
}
