using Datos.Eventos;
using Datos.Finanzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Finanzas
{
    public class FondoCapillaLN
    {
        public List<Entidades.Finanzas.Vistas.VFondoCapilla> Listar(String dato)
        {
            List<Entidades.Finanzas.Vistas.VFondoCapilla> lista =
                new List<Entidades.Finanzas.Vistas.VFondoCapilla>();

            try
            {
                var datos = FondoCapillaCD.Listar(dato);
                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Finanzas.Vistas.VFondoCapilla(
                        item.idFondoCapilla,
                        item.Nombre,
                        item.Descripcion,
                        item.Capilla,
                        item.Saldo
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar FondoCapilla", ex);
            }

            return lista;
        }

        public void Insertar(Entidades.Finanzas.FondoCapilla fc)
        {
            try
            {
                FondoCapillaCD.Insertar(fc);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar FondoCapilla", ex);
            }
        }

        public Entidades.Finanzas.FondoCapilla ObtenerPorId(int id)
        {
            try
            {
                var item = FondoCapillaCD.BuscarPorId(id);
                if (item == null) return null;

                return new Entidades.Finanzas.FondoCapilla(
                        item.idFondoCapilla,
                        item.Nombre,
                        item.Descripcion,
                        item.idCapilla,
                        item.Saldo
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener FondoCapilla", ex);
            }
        }

        public void Modificar(Entidades.Finanzas.FondoCapilla fc)
        {
            try
            {
                FondoCapillaCD.Modificar(fc);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar FondoCapilla", ex);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                FondoCapillaCD.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar FondoCapilla", ex);
            }
        }
    }
}
