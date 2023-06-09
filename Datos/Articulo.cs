using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Articulo
    {
        public static void AltaArticulo(Entidades.Articulo pArticulo)
        {
            string sql = " insert into T_ARTICULOS (ID,DESCRIPCION,CANTIDAD,VAL_CRITICO,UM,HABILITADO) values (@Codigo,@Descripcion,@Stock,@ValCritico,@UM,@Habilitado) ";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(sql, objConexion);
            objComAgregar.Parameters.AddWithValue("@Codigo", pArticulo.ID);
            objComAgregar.Parameters.AddWithValue("@Descripcion", pArticulo.DESCRIPCION);
            objComAgregar.Parameters.AddWithValue("@Stock", pArticulo.CANTIDAD);
            objComAgregar.Parameters.AddWithValue("@ValCritico", pArticulo.VAL_CRITICO);
            objComAgregar.Parameters.AddWithValue("@UM", pArticulo.UM);
            objComAgregar.Parameters.AddWithValue("@Habilitado", Convert.ToInt32(pArticulo.HABILITADO));

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

        public static void BajaArticulo(string pCodigo)
        {
            string sql = "delete  from T_ARTICULOS where RTRIM(ID) ='" + pCodigo.Trim() + "'";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComEliminar = new SqlCommand(sql, objConexion);
            objComEliminar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComEliminar.ExecuteNonQuery();
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
        public static void ModificarArticulo(Entidades.Articulo pArticulo)
        {
            string sql = "update T_ARTICULOS set  DESCRIPCION = @Descripcion, CANTIDAD = @Stock,VAL_CRITICO = @ValCritico,UM = @UM, HABILITADO=@Habilitado Where RTRIM(ID) = @Codigo ";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComModificar= new SqlCommand(sql, objConexion);
            objComModificar.CommandType = CommandType.Text;
            objComModificar.Parameters.AddWithValue("@Codigo", pArticulo.ID.Trim());
            objComModificar.Parameters.AddWithValue("@Descripcion", pArticulo.DESCRIPCION);
            objComModificar.Parameters.AddWithValue("@Stock", pArticulo.CANTIDAD);
            objComModificar.Parameters.AddWithValue("@ValCritico", pArticulo.VAL_CRITICO);
            objComModificar.Parameters.AddWithValue("@UM", pArticulo.UM);
            objComModificar.Parameters.AddWithValue("@Habilitado", Convert.ToInt32(pArticulo.HABILITADO));
            try
            {
                objConexion.Open();
                objComModificar.ExecuteNonQuery();
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
        public static DataTable TraerArticulos()
        {
            DataTable dt = new DataTable();
            string sql = "Select ID 'CODIGO',RTRIM(DESCRIPCION )'DESCRIPCION',CONVERT(DECIMAL (22, 3),CANTIDAD) 'STOCK',CONVERT(DECIMAL (22, 3),VAL_CRITICO)'STOCK MIN',RTRIM(UM)'U.M',HABILITADO 'ACTIVO' from T_ARTICULOS order by DESCRIPCION ASC";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(sql, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable TraerArticulosHabilitados()
        {
            DataTable dt = new DataTable();
            string sql = "Select ID 'CODIGO',RTRIM(DESCRIPCION )'DESCRIPCION',CONVERT(DECIMAL (22, 3),CANTIDAD) 'STOCK',CONVERT(DECIMAL (22, 3),VAL_CRITICO)'STOCK MIN',RTRIM(UM)'U.M',HABILITADO 'ACTIVO' from T_ARTICULOS where HABILITADO=1 order by DESCRIPCION ASC";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(sql, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }

        public static void EntradaArticulo(string pCodigo, Decimal pCant)
        {
            string sql = "update T_ARTICULOS set CANTIDAD = CANTIDAD + '" + pCant + "' where RTRIM(ID) = '" + pCodigo.Trim() + "'";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComModificar = new SqlCommand(sql, objConexion);
            objComModificar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComModificar.ExecuteNonQuery();
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



        public static void SalidaArticulo(string pCodigo, decimal pCant)
        {
            string sql = "update T_ARTICULOS set CANTIDAD = CANTIDAD - '" + pCant + "' where RTRIM(ID) = '" + pCodigo.Trim() + "'";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComModificar = new SqlCommand(sql, objConexion);
            objComModificar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComModificar.ExecuteNonQuery();
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

        public static DataTable TraerFaltantes()
        {
            DataTable dt = new DataTable();
            string sql = "Select ID 'CODIGO',RTRIM(DESCRIPCION) 'DESCRIPCION',CONVERT(DECIMAL (22, 3),CANTIDAD) 'STOCK',CONVERT(DECIMAL (22, 3),VAL_CRITICO)'STOCK MIN' ,RTRIM(UM)'U.M',HABILITADO 'ACTIVO' from T_ARTICULOS where CANTIDAD <= VAL_CRITICO and HABILITADO = 1 order by DESCRIPCION ASC";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(sql, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable TraerFaltantesMin()
        {
            DataTable dt = new DataTable();
            string sql = "Select ID 'CODIGO',RTRIM(DESCRIPCION) 'DESCRIPCION',CONVERT(DECIMAL (22, 3),CANTIDAD) 'STOCK',CONVERT(DECIMAL (22, 3),VAL_CRITICO)'STOCK MIN' ,RTRIM(UM)'U.M',HABILITADO 'ACTIVO' from T_ARTICULOS where CANTIDAD < VAL_CRITICO and HABILITADO = 1 order by DESCRIPCION ASC";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(sql, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }

        public static Boolean ValidarCodigo(string pCodigo)
        {
            Boolean Resultado = false;
            int Cant;
            string sql = "SELECT COUNT(*) FROM T_ARTICULOS WHERE RTRIM(ID) = '" + pCodigo.Trim() + "'";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objCom = new SqlCommand(sql, objConexion);
            objCom.CommandType = CommandType.Text;
            objConexion.Open();
            Cant = Convert.ToInt32(objCom.ExecuteScalar());
            objConexion.Close();
            if (Cant != 0)
            {
                Resultado = true;
            }
            return Resultado;


        }
        public static void EliminarArticulo(string pCodigo)
        {
            string sql = "delete  From T_ARTICULOS where RTRIM(ID)='" + pCodigo.Trim() + "' ";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComEliminar = new SqlCommand(sql, objConexion);
            objComEliminar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComEliminar.ExecuteNonQuery();
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

    }
}
