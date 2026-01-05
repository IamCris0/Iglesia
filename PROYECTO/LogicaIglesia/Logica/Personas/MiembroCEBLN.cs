using Datos.Personas;
using Entidades.Personas.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Personas
{
    public class MiembroCEBLN
    {
        public List<Entidades.Personas.Vistas.VMiembroCEB> Listar(string filtro)
        {
            List<Entidades.Personas.Vistas.VMiembroCEB> lista = new List<VMiembroCEB>();

            try
            {
                var datos = MiembroCEBCD.Listar(filtro);

                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Personas.Vistas.VMiembroCEB(
                             item.idMiembroCEB,
                             item.Laico,
                             item.CEB,
                             item.Activo,
                             item.FechaIngreso
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar MiembroCEB", ex);
            }

            return lista;
        }

        public Entidades.Personas.MiembroCEB ObtenerPorId(int id)
        {
            try
            {
                var item = MiembroCEBCD.BuscarPorId(id);
                if (item == null) return null;

                return new Entidades.Personas.MiembroCEB(
                             item.idMiembroCEB,
                             item.idLaico,
                             item.idCEB,
                             item.Activo,
                             item.FechaIngreso
                             );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener MiembroCEB", ex);
            }
        }

        public void Insertar(Entidades.Personas.MiembroCEB oc)
        {
            try
            {
                MiembroCEBCD.Insertar(oc);

            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar MiembroCEB", ex);
            }
        }

        public bool Modificar(Entidades.Personas.MiembroCEB oc)
        {
            try
            {
                MiembroCEBCD.Modificar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar MiembroCEB", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                MiembroCEBCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar MiembroCEB", ex);
            }
        }
    }
}
