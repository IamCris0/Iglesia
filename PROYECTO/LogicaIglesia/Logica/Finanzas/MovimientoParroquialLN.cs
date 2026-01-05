using Datos.Finanzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Finanzas
{
    public class MovimientoParroquialLN
    {
        public List<Entidades.Finanzas.Vistas.VMovimientoParroquial> Listar(String dato)
        {
            List<Entidades.Finanzas.Vistas.VMovimientoParroquial> lista =
                new List<Entidades.Finanzas.Vistas.VMovimientoParroquial>();

            try
            {
                var datos = MovimientoParroquialCD.Listar(dato);
                foreach (var item in datos)
                {
                    lista.Add(new Entidades.Finanzas.Vistas.VMovimientoParroquial(
                        item.idMovimientoParroquial,
                        item.FondoParroquial,
                        item.EventoParroquial,
                        item.Fecha,
                        item.Tipo,
                        item.Descripcion,
                        item.Monto
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al listar MovimientoParroquial", ex);
            }

            return lista;
        }

        public void Insertar(Entidades.Finanzas.MovimientoParroquial fc)
        {
            try
            {
                MovimientoParroquialCD.Insertar(fc);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar MovimientoParroquial", ex);
            }
        }

        public void Modificar(Entidades.Finanzas.MovimientoParroquial fc)
        {
            try
            {
                MovimientoParroquialCD.Modificar(fc);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar MovimientoParroquial", ex);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                MovimientoParroquialCD.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar MovimientoParroquial", ex);
            }
        }


        public Entidades.Finanzas.MovimientoParroquial ObtenerPorId(int id)
        {
            try
            {
                var item = MovimientoParroquialCD.BuscarPorId(id);
                if (item == null) return null;

                return new Entidades.Finanzas.MovimientoParroquial(
                        item.idMovimientoParroquial,
                        item.idFondoParroquial,
                        item.Fecha,
                        item.Tipo,
                        item.Descripcion,
                        item.Monto,
                        item.idEventoParroquial
                );
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al obtener MovimientoParroquial", ex);
            }
        }
    }
}
