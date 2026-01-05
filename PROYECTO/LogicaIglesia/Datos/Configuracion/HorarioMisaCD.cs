using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Configuracion
{
    public class HorarioMisaCD
    {
        public static List<sp_HorarioMisa_ListarResult> Listar(string valor)
        {
            DControlDataContext db = null;
            try
            {
                using (db = new DControlDataContext())
                {
                    return db.sp_HorarioMisa_Listar(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar HorarioMisa", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static sp_HorarioMisa_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_HorarioMisa_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Configuracion.HorarioMisa of)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_HorarioMisa_Insert(
                        of.IdCapilla,
                        of.DiaSemana,
                        of.Hora,
                        of.Activo
                    );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar HorarioMisa", ex);
            }
        }

        public static void Modificar(Entidades.Configuracion.HorarioMisa of)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_HorarioMisa_Update(
                        of.IdHorarioMisa,
                        of.IdCapilla,
                        of.DiaSemana,
                        of.Hora,
                        of.Activo
                        );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar HorarioMisa", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_HorarioMisa_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar HorarioMisa", ex);
            }
        }

       
    }
}
