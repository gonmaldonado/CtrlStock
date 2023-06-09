using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class UM
    {
        public static int TraerTipoUM(string pUM)
        {
            int Tipo;
            string sql = "SELECT ID_TIPO FROM T_UM WHERE RTRIM(UNIDAD) = '" + pUM.Trim() + "'";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComTraer = new SqlCommand(sql, objConexion);
            objComTraer.CommandType = CommandType.Text;
            objConexion.Open();
            Tipo = Convert.ToInt32(objComTraer.ExecuteScalar());
            objConexion.Close();
         
            return Tipo;
        }
        public static DataTable TraerUM(int tipo)
        {
            DataTable dt = new DataTable();
            string sql = "select UNIDAD from T_UM where ID_TIPO="+tipo+"";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(sql, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        
                 public static DataTable TraerTodosUM()
        {
            DataTable dt = new DataTable();
            string sql = "select UNIDAD from T_UM ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(sql, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
    }
}
