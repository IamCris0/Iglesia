using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Eventos
{
    public class EventoCapillaCD
    {
        public static List<sp_EventoCapilla_ListarResult> Listar(string filtro)
        {
            using (var dc = new DControlDataContext())
            {
                return dc.sp_EventoCapilla_Listar(filtro).ToList();
            }
        }

        public static sp_EventoCapilla_BuscarPorIdResult BuscarPorId(int idEventoCapilla)
        {
            using (var dc = new DControlDataContext())
            {
                return dc.sp_EventoCapilla_BuscarPorId(idEventoCapilla).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Eventos.EventoCapilla of)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_EventoCapilla_Insert(
                        of.Nombre,
                        of.Descripcion,
                        of.FechaInicio,
                        of.FechaFin,
                        of.IdCapilla,
                        of.Activo
                    );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar EventoCapilla", ex);
            }
        }

        public static void Modificar(Entidades.Eventos.EventoCapilla of)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_EventoCapilla_Update(
                        of.IdEventoCapilla,
                        of.Nombre,
                        of.Descripcion,
                        of.FechaInicio,
                        of.FechaFin,
                        of.IdCapilla,
                        of.Activo
                        );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar EventoCapilla", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_EventoCapilla_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar EventoCapilla", ex);
            }
        }
    }
}
