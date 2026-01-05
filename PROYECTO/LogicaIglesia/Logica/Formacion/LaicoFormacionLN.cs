using Datos.Formacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Formacion
{
    public class LaicoFormacionLN
    {
        public List<Entidades.Formacion.Vistas.VLaicoFormacion> Listar(string valor)
        {
            List<Entidades.Formacion.Vistas.VLaicoFormacion> lista = new List<Entidades.Formacion.Vistas.VLaicoFormacion>();

            try
            {
                var datos = LaicoFormacionCD.Listar("");
                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Formacion.Vistas.VLaicoFormacion(
                        item.idLaicoFormacion,
                        item.Laico,
                        item.Formacion,
                        item.Estado,
                        item.FechaInicio,
                        item.FechaFin
                        ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar LaicoFormacion", ex);
            }

            return lista;
        }

        public Entidades.Formacion.LaicoFormacion ObtenerPorId(int id)
        {
            try
            {
                var item = LaicoFormacionCD.BuscarPorId(id);
                if (item == null) return null;

                return new Entidades.Formacion.LaicoFormacion(
                        item.idLaicoFormacion,
                        item.idLaico,
                        item.idFormacion,
                        item.Estado,
                        item.FechaInicio,
                        item.FechaFin
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener LaicoFormacion", ex);
            }
        }

        public bool Insertar(Entidades.Formacion.LaicoFormacion of)
        {
            try
            {
                LaicoFormacionCD.Insertar(of);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar LaicoFormacion", ex);
            }
        }

        public bool Modificar(Entidades.Formacion.LaicoFormacion of)
        {
            try
            {
                LaicoFormacionCD.Modificar(of);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar LaicoFormacion", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                LaicoFormacionCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar LaicoFormacion", ex);
            }
        }
    }
}
