using Datos.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Seguridad
{
    public class RolSistemaLN
    {
        public List<Entidades.Seguridad.RolSistema> Listar()
        {
            List<Entidades.Seguridad.RolSistema> lista = new List<Entidades.Seguridad.RolSistema>();

            try
            {
                var datos = RolSistemaCD.Listar();
                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Seguridad.RolSistema(
                        item.idRolSistema,
                        item.Nombre,
                        item.Descripcion
                        ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar RolSistema", ex);
            }

            return lista;
        }

        public Entidades.Seguridad.RolSistema ObtenerPorId(int id)
        {
            try
            {
                var aux = RolSistemaCD.BuscarPorId(id);
                if (aux == null) return null;

                return new Entidades.Seguridad.RolSistema(
                    aux.idRolSistema,
                    aux.Nombre,
                    aux.Descripcion
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener RolSistema", ex);
            }
        }

        public bool Insertar(Entidades.Seguridad.RolSistema of)
        {
            try
            {
                RolSistemaCD.Insertar(of);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar RolSistema", ex);
            }
        }

        public bool Modificar(Entidades.Seguridad.RolSistema of)
        {
            try
            {
                RolSistemaCD.Modificar(of);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar RolSistema", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                RolSistemaCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar RolSistema", ex);
            }
        }
    }
}
