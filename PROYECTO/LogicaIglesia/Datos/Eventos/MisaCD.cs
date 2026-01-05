using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Eventos
{
    public class MisaCD
    {
        public static List<sp_Misa_ListarResult> Listar(string valor)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_Misa_Listar(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Misas", ex);
            }
        }

        public static sp_Misa_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_Misa_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Eventos.Misa p)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    var result = db.sp_Misa_Insert(
                        p.IdCapilla,
                        p.IdSacerdote,
                        p.Fecha,
                        p.MontoRecaudado,
                        p.Estado,
                        p.IdSolicitudSacramental
                    );

                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar Misa", ex);
            }
        }

        public static void Modificar(Entidades.Eventos.Misa p)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Misa_Update(
                        p.IdMisa,
                        p.IdCapilla,
                        p.IdSacerdote,
                        p.Fecha,
                        p.MontoRecaudado,
                        p.Estado,
                        p.IdSolicitudSacramental
                        );
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar Misa", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Misa_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar Misa", ex);
            }
        }

        public static void GenerarAutomatico(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_GenerarMisas_Automatico(fechaInicio, fechaFin);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al ejecutar generación automática de misas", ex);
            }
        }
    }
}
