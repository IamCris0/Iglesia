using Datos.Finanzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Finanzas
{
    public class FondoParroquialLN
    {
        public List<Entidades.Finanzas.Vistas.VFondoParroquial> Listar(String dato)
        {
            List<Entidades.Finanzas.Vistas.VFondoParroquial> lista =
                new List<Entidades.Finanzas.Vistas.VFondoParroquial>();

            try
            {
                var datos = FondoParroquialCD.Listar(dato);
                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Finanzas.Vistas.VFondoParroquial(
                        item.idFondoParroquial,
                        item.Nombre,
                        item.Descripcion,
                        item.Parroquia,
                        item.Saldo
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar FondoParroquial", ex);
            }

            return lista;
        }

        public void Insertar(Entidades.Finanzas.FondoParroquial fc)
        {
            try
            {
                FondoParroquialCD.Insertar(fc);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar FondoParroquial", ex);
            }
        }

        public void Modificar(Entidades.Finanzas.FondoParroquial fc)
        {
            try
            {
                FondoParroquialCD.Modificar(fc);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar FondoParroquial", ex);
            }
        }


        public void Eliminar(int id)
        {
            try
            {
                FondoParroquialCD.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar FondoParroquial", ex);
            }
        }

        public Entidades.Finanzas.FondoParroquial ObtenerPorId(int id)
        {
            try
            {
                var item = FondoParroquialCD.BuscarPorId(id);
                if (item == null) return null;

                return new Entidades.Finanzas.FondoParroquial(
                        item.idFondoParroquial,
                        item.Nombre,
                        item.Descripcion,
                        item.idParroquia,
                        item.Saldo
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener FondoParroquial", ex);
            }
        }
    }
}
