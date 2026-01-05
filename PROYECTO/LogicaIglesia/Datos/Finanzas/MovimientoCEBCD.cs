using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Finanzas
{
    public class MovimientoCEBCD
    {
        public static List<sp_MovimientoCEB_ListarResult> Listar(string filtro)
        {
            DControlDataContext db = null;
            try
            {
                using (db = new DControlDataContext())
                {
                    return db.sp_MovimientoCEB_Listar(filtro).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar MovimientoCEB", ex);
            }
            finally
            {
                db = null;
            }
        }

        public static sp_MovimientoCEB_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_MovimientoCEB_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Finanzas.MovimientoCEB item)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_MovimientoCEB_Insert(
                        item.CEB,
                        item.FondoCapilla,
                        item.Fecha,
                        item.Tipo,
                        item.Descripcion,
                        item.Monto,
                        item.EventoCapilla
                    );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar MovimientoCEB", ex);
            }
        }

        public static void Modificar(Entidades.Finanzas.MovimientoCEB item)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_MovimientoCEB_Update(
                        item.IdMovimientoCEB,
                        item.CEB,
                        item.FondoCapilla,
                        item.Fecha,
                        item.Tipo,
                        item.Descripcion,
                        item.Monto,
                        item.EventoCapilla
                        );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar MovimientoCEB", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_MovimientoCEB_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar MovimientoCEB", ex);
            }
        }
    }
}
