using Datos.LinqToSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Seguridad
{
    public class UsuarioCD
    {
        public static List<sp_Usuario_ListarResult> Listar(string valor)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    return db.sp_Usuario_Listar(valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar Usuarios", ex);
            }
        }

        public static sp_Usuario_BuscarPorIdResult BuscarPorId(int id)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_Usuario_BuscarPorId(id).FirstOrDefault();
            }
        }

        public static sp_Usuario_BuscarPorMailResult BuscarPorMail(string mail)
        {
            using (var db = new DControlDataContext())
            {
                return db.sp_Usuario_BuscarPorMail(mail).FirstOrDefault();
            }
        }

        public static void Insertar(Entidades.Seguridad.Usuario p)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Usuario_Insert(p.Email, p.PasswordHash, p.IdLaico, p.IdSacerdote);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar Usuario", ex);
            }
        }

        public static void Modificar(Entidades.Seguridad.Usuario p)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Usuario_Update(p.IdUsuario, p.Email, p.PasswordHash, p.IdLaico, p.IdSacerdote);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al modificar Usuario", ex);
            }
        }

        public static void Eliminar(int id)
        {
            try
            {
                using (var db = new DControlDataContext())
                {
                    db.sp_Usuario_Delete(id);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al eliminar Usuario", ex);
            }
        }
    }
}
