using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Logica
{
    public class Consultas
    {
        public static DataTable TraerMovimientos(string pDia)
        {
            return Datos.Consultas.ListarRegistros(pDia);
        }
        public static DataTable TraerContadorM(string pDia)
        {
            return Datos.Consultas.ListarContadoresTM(pDia);
        }
        public static DataTable TraerContadorT(string pDia)
        {
            return Datos.Consultas.ListarContadoresTT(pDia);
        }
        public static DataTable TraerContador(string pDia)
        {
            return Datos.Consultas.ListarContadores(pDia);
        }
       /// <summary>
       /// TraerRegistros: Traer los registros segun dia y turno
       /// </summary>
       /// <param name="pDia"></param>
       /// <param name="Turno"></param>
       /// <returns></returns>
        public static DataTable TraerRegistros(string pDia,int Turno)
        {
            return Datos.Consultas.FiltrarRegistros(pDia,Turno);
        }
        /// <summary>
        /// TraerRegistros:Trae los registros segun Dia de ambos turnos.
        /// </summary>
        /// <param name="pDia"></param>
        /// <returns></returns>
        public static DataTable TraerRegistros(string pDia)
        {
            return Datos.Consultas.ListarRegistros(pDia);
        }

        public static DataTable Reporte(string pDesde , string pHasta)
        {
            return Datos.Consultas.FiltrarContadores(pDesde,pHasta);
        }
        public static DataTable Reporte2(string pDesde, string pHasta)
        {
            return Datos.Consultas.FiltrarDollies(pDesde, pHasta);
        }
        public static DataTable Reporte3(string pDesde, string pHasta)
        {
            return Datos.Consultas.FiltrarContadores2(pDesde, pHasta);
        }
        public static DataTable Reporte4(string pDesde, string pHasta)
        {
            return Datos.Consultas.FiltrarDollies2(pDesde, pHasta);
        }
        public static DataTable ListarModelos()
        {
            return Datos.Consultas.LiastarModelos();
        }
        public static DataTable BDStock()
        {
            return Datos.Consultas.TrearBaseStock();
        }
        public static DataTable ListarPatch()
        {
            return Datos.Consultas.LiastarPatch();
        }
        public static DataTable TraerCantidadSetXModelo(string pDia)
        {
            return Datos.Consultas.ContadoresxModelo(pDia);
        }
        public static DataTable TraerSetXModelo(string pDia)
        {
            return Datos.Consultas.ComponentesxModelo(pDia);
        }
        public static DataTable TraerDolliesT(string pDia)
        {
            return Datos.Consultas.ListarDolliesTT(pDia);
        }
        public static DataTable TraerDolliesM(string pDia)
        {
            return Datos.Consultas.ListarDolliesTM(pDia);
        }
        public static DataTable TraerDollies(string pDia)
        {
            return Datos.Consultas.ListarDollies(pDia);
        }
        public static DataTable TraerPendientesDeArmados()
        {
            return Datos.Consultas.PendientesDeArmado();
        }
        public static string TraerUltimoArmado()
        {
            return Datos.Consultas.TraerUltimoArmado();
        }
        public static DataTable TraerGeneral()
        {
            return Datos.Consultas.TrearGeneral();
        }
        public static DataTable TraerDoor()
        {
            return Datos.Consultas.TrearDoor();
        }
        public static void Armado(string codigo)
        {
            Datos.Consultas.CargarArmado(codigo, Datos.Consultas.TrearCantidad(Datos.Consultas.TrearCantidadCodigo(codigo)));
        }
        public static void CargarRegistro(string Codigo)
        {

            Datos.Consultas.CargarRegistro(Codigo.Replace("'", "-").Trim());
        }
        public static int Tango(string Codigo)
        {
           return Datos.Consultas.StockTango(Codigo);
        }
        public static int Pendiente(string Codigo)
        {
            return Datos.Consultas.PendienteTango(Codigo);
        }
        public static int Ajuste(string Codigo)
        {
            return Datos.Consultas.AjusteTango(Codigo);
        }



    }

}
