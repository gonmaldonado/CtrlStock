using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Logica
{
    public class Movimiento
    {
        static public DataTable TraerMovimientos()
        {
            return Datos.Movimiento.TraerMovimientos();
        }
        static public DataTable TraerMovimientos(string Desde, string Hasta)
        {
            return Datos.Movimiento.TraerMovimientos(Desde,Hasta);
        }
        static public void AltaMovimiento(Entidades.Movimiento pMovimiento)
        {
            Datos.Movimiento.AltaMovimiento(pMovimiento);
        }
    }
}
