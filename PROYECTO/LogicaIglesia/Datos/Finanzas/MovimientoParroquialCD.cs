using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Finanzas
{
    public class MovimientoParroquialCD
    {
        public static List<sp_MovimientoParroquial_ListarResult> Listar(string filtro)
        {
            DControlDataContext db = null;
            try
            {
                using (db = new DControlDataContext())
                {
                    return db.sp_MovimientoParroquial_Listar(filtro).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar MovimientoParroquial", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static sp_MovimientoParroquial_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_MovimientoParroquial_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Finanzas.MovimientoParroquial item)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_MovimientoParroquial_Insert(
                        item.IdFondoParroquial,
                        item.Fecha,
                        item.Tipo,
                        item.Descripcion,
                        item.Monto,
                        item.IdEventoParroquial
                    );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar MovimientoParroquial", ex);
            }
        }

        public static void Modificar(Entidades.Finanzas.MovimientoParroquial item)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_MovimientoParroquial_Update(
                        item.IdMovimientoParroquial,
                        item.IdFondoParroquial,
                        item.Fecha,
                        item.Tipo,
                        item.Descripcion,
                        item.Monto,
                        item.IdEventoParroquial
                        );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar MovimientoParroquial", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_MovimientoParroquial_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar MovimientoParroquial", ex);
            }
        }
    }
}
