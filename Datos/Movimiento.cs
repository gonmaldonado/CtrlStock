using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Movimiento
    {
        public static void AltaMovimiento(Entidades.Movimiento pMovimiento)
        {
            string sql = " insert into T_MOVIMIENTOS (FECHA,HORA,ID_ARTICULO,DESCRIPCION,ORIGEN,MOVIMIENTO,CANTIDAD,UM) values (@Fecha,@Hora,@Articulo,@Descripcion,@Origen,@Movimiento,@Cantidad,@UM) ";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(sql, objConexion);
            objComAgregar.Parameters.AddWithValue("@Fecha", pMovimiento.FECHA);
            objComAgregar.Parameters.AddWithValue("@Hora", pMovimiento.HORA);
            objComAgregar.Parameters.AddWithValue("@Articulo", pMovimiento.ID_ARTICULO);
            objComAgregar.Parameters.AddWithValue("@Descripcion", pMovimiento.DESCRIPCION);
            objComAgregar.Parameters.AddWithValue("@Origen", pMovimiento.ORIGEN);
            objComAgregar.Parameters.AddWithValue("@Cantidad", pMovimiento.CANTIDAD);
            objComAgregar.Parameters.AddWithValue("@Movimiento", pMovimiento.MOVIMIENTO);
            objComAgregar.Parameters.AddWithValue("@UM", pMovimiento.UM);
 

            objComAgregar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComAgregar.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                throw new Exception("ERROR EN BASE DE DATOS");
            }
            finally
            {

                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }
        }
        public static DataTable TraerMovimientos()
        {
            DataTable dt = new DataTable();
            string sql = "Select  FECHA 'FECHA',HORA 'HORA',RTRIM(ORIGEN) 'ORIGEN',RTRIM(MOVIMIENTO) 'MOVIMIENTO',RTRIM(ID_ARTICULO) 'CODIGO',RTRIM(DESCRIPCION)'DESCRIPCION',CONVERT(DECIMAL (22, 3),CANTIDAD) 'CANTIDAD',RTRIM(UM)'U.M' from T_MOVIMIENTOS order by FECHA DESC,HORA DESC";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(sql, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable TraerMovimientos(string pDesde, string pHasta)
        {
            DateTime Desde = Convert.ToDateTime(pDesde);
            DateTime Hasta = Convert.ToDateTime(pHasta);
            DateTime dia2 = Hasta.AddDays(1);
            DataTable dt = new DataTable();
            string sql = "Select  CONVERT(VARCHAR(10), FECHA ,105)'FECHA',convert(char(8), HORA, 108) 'HORA',RTRIM(ORIGEN) 'ORIGEN',RTRIM(MOVIMIENTO) 'MOVIMIENTO',RTRIM(ID_ARTICULO) 'CODIGO',RTRIM(DESCRIPCION)'DESCRIPCION',CONVERT(DECIMAL (22, 3),CANTIDAD) 'CANTIDAD',RTRIM(UM)'U.M' from T_MOVIMIENTOS where FECHA between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 )  order by ID DESC";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(sql, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
    }
}
