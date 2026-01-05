using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Personas
{
    public class LaicoCD
    {
        public static List<sp_Laico_ListarResult> Listar(string valor)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_Laico_Listar(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Laicos", ex);
            }
        }

        public static sp_Laico_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_Laico_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static int Insertar(Entidades.Personas.Laico p)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    var result = db.sp_Laico_Insert(
                        p.Nombres,
                        p.Apellidos,
                        p.Telefono,
                        p.idCapilla,
                        p.Activo
                    );

                    int idGenerado = (int)result.Single().idLaico;
                    return idGenerado;
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar Laico", ex);
            }
        }

        public static void Modificar(Entidades.Personas.Laico p)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Laico_Update(p.idLaico, p.Nombres, p.Apellidos, p.Telefono, p.idCapilla, p.Activo);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar Laico", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Laico_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar Laico", ex);
            }
        }
    }
}
