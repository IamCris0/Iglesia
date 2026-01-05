using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Eventos
{
    public class EventoParroquialCD
    {
        public static List<sp_EventoParroquial_ListarResult> Listar(string valor)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_EventoParroquial_Listar(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Evento Parroquial", ex);
            }
        }

        public static sp_EventoParroquial_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_EventoParroquial_BuscarPorId(id).FirstOrDefault();
            }
        }
        public static void Insertar(Entidades.Eventos.EventoParroquial e)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_EventoParroquial_Insert(
                        e.Nombre,
                        e.Descripcion,
                        e.FechaInicio,
                        e.FechaFin,
                        e.IdParroquia,
                        e.Activo
                    );
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar Evento Parroquial", ex);
            }
        }

        public static void Modificar(Entidades.Eventos.EventoParroquial e)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_EventoParroquial_Update(e.IdEventoParroquial,
                                                  e.Nombre,
                                                  e.Descripcion,
                                                  e.FechaInicio,
                                                  e.FechaFin,
                                                  e.IdParroquia,
                                                  e.Activo);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar Evento Parroquial", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_EventoParroquial_Delete(id);
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar Evento Parroquial", ex);
            }
        }
    }
}
