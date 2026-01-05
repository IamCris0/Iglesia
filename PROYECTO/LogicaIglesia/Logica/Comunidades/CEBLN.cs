using Datos.Conunidades;
using Entidades.Comunidades.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Comunidades
{
    public class CEBLN
    {
        public List<Entidades.Comunidades.Vistas.VCEB> Listar(string filtro)
        {
            List<Entidades.Comunidades.Vistas.VCEB> lista = new List<VCEB>();

            try
            {
                var datos = CEBCD.Listar(filtro);

                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Comunidades.Vistas.VCEB(
                        item.idCEB,
                        item.CEB,
                        item.Capilla,
                        item.Activo,
                        item.Estado,
                        item.FechaCreacion
                        ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar CEB", ex);
            }

            return lista;
        }

        public Entidades.Comunidades.CEB ObtenerPorId(int id)
        {
            try
            {
                var aux = CEBCD.BuscarPorId(id);
                if (aux == null) return null;

                return new Entidades.Comunidades.CEB(
                    aux.idCEB,
                    aux.Nombre,
                    aux.idCapilla,
                    aux.Activo,                   
                    aux.FechaCreacion
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener CEB", ex);
            }
        }

        public bool Insertar(Entidades.Comunidades.CEB oc)
        {
            try
            {
                CEBCD.Insertar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar CEB", ex);
            }
        }

        public bool Modificar(Entidades.Comunidades.CEB oc)
        {
            try
            {
                CEBCD.Modificar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar CEB", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                CEBCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar CEB", ex);
            }
        }
    }
}
