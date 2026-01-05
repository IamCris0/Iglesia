using Datos.LinqToSQL;
using Datos.Ubicaciones;
using Entidades.Ubicaciones.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Ubicaciones
{
    public class CapillaLN
    {
        public List<Entidades.Ubicaciones.Vistas.VCapilla> Listar(string filtro)
        {
            List<Entidades.Ubicaciones.Vistas.VCapilla> lista = new List<VCapilla> ();    

            try
            {
                var datos = CapillaCD.Listar(filtro);

                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Ubicaciones.Vistas.VCapilla(
                        item.idCapilla,
                        item.Capilla,
                        item.Direccion,
                        item.Parroquia,
                        item.Coordinador
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Capilla", ex);
            }

            return lista;
        }

        public Entidades.Ubicaciones.Capilla ObtenerPorId(int id)
        {
            try
            {
                var aux = CapillaCD.BuscarPorId(id);
                if (aux == null) return null;

                return new Entidades.Ubicaciones.Capilla(
                    aux.idCapilla,
                    aux.Nombre,
                    aux.Direccion,
                    aux.idParroquia,
                    (int)aux.idLaicoCoordinador
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener Capilla", ex);
            }
        }

        public int Insertar(Entidades.Ubicaciones.Capilla oc)
        {
            try
            {
                 return CapillaCD.Insertar(oc);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Capilla", ex);
            }
        }

        public bool Modificar(Entidades.Ubicaciones.Capilla oc)
        {
            try
            {
                CapillaCD.Modificar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Capilla", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                CapillaCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Capilla", ex);
            }
        }

        public bool AsignarCoordinador(int idCapilla, int idLaicoNuevo)
        {
            try
            {
                return CapillaCD.AsignarCoordinador(idCapilla, idLaicoNuevo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al asignar coordinador a la capilla", ex);
            }
        }
    }
}
