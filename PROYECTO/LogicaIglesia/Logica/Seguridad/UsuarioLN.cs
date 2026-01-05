using Datos.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Seguridad
{
    public class UsuarioLN
    {
        public List<Entidades.Seguridad.Vistas.VUsuario> Listar(string valor)
        {
            List<Entidades.Seguridad.Vistas.VUsuario> lista = new List<Entidades.Seguridad.Vistas.VUsuario>();

            try
            {
                var datos = UsuarioCD.Listar("");
                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Seguridad.Vistas.VUsuario(
                        item.idUsuario,
                        item.Email,
                        item.Persona,
                        item.TipoUsuario
                        ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar Usuario", ex);
            }

            return lista;
        }

        public Entidades.Seguridad.Usuario ObtenerPorId(int id)
        {
            try
            {
                var aux = UsuarioCD.BuscarPorId(id);
                if (aux == null) return null;

                return new Entidades.Seguridad.Usuario(
                    aux.idUsuario,
                    aux.Email,
                    aux.PasswordHash,
                    aux.idLaico,
                    aux.idSacerdote
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener Usuario", ex);
            }
        }

        public Entidades.Seguridad.Usuario ObtenerPorMail(string mail)
        {
            try
            {
                var aux = UsuarioCD.BuscarPorMail(mail);
                if (aux == null) return null;

                return new Entidades.Seguridad.Usuario(
                    aux.idUsuario,
                    aux.Email,
                    aux.PasswordHash,
                    aux.idLaico,
                    aux.idSacerdote
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener Usuario", ex);
            }
        }

        public string HashSHA256(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        public bool Insertar(Entidades.Seguridad.Usuario of)
        {
            try
            {
                UsuarioCD.Insertar(of);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Usuario", ex);
            }
        }

        public bool Modificar(Entidades.Seguridad.Usuario of)
        {
            try
            {
                UsuarioCD.Modificar(of);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Usuario", ex);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                UsuarioCD.Eliminar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Usuario", ex);
            }
        }
    }
}
