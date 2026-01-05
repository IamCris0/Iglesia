using Datos.Configuracion;
using Datos.Eventos;
using Entidades.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Configuracion
{
    public class HorarioMisaLN
    {
        public List<Entidades.Configuracion.VHorarioMisa> Listar(string filtro)
        {
            List<Entidades.Configuracion.VHorarioMisa> lista = new List<VHorarioMisa>();

            try
            {
                var datos = HorarioMisaCD.Listar(filtro);

                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Configuracion.VHorarioMisa(
                        item.idHorarioMisa,
                        item.Capilla,
                        item.DiaSemana,
                        item.Hora,
                        item.Activo
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar HorarioMisa", ex);
            }

            return lista;
        }

        public Entidades.Configuracion.HorarioMisa ObtenerPorId(int id)
        {
            try
            {
                var item = HorarioMisaCD.BuscarPorId(id);
                if (item == null) return null;

                return new Entidades.Configuracion.HorarioMisa(
                        item.idHorarioMisa,
                        item.idCapilla,
                        item.DiaSemana,
                        item.Hora,
                        item.Activo
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener HorarioMisa", ex);
            }
        }

        public void Insertar(Entidades.Configuracion.HorarioMisa oc)
        {
            try
            {
                HorarioMisaCD.Insertar(oc);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar HorarioMisa", ex);
            }
        }

        public bool Modificar(Entidades.Configuracion.HorarioMisa oc)
        {
            try
            {
                HorarioMisaCD.Modificar(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar HorarioMisa", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                HorarioMisaCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar HorarioMisa", ex);
            }
        }


    }
}
