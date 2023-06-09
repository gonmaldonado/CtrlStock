using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Consultas
    {
        public static DataTable LiastarModelos()
        {

            DataTable dt = new DataTable();
            string strProc = "select NOMBRE from T_MODELOS "+
                "UNION select NOMBRE from T_DOOR_TRIM   " +
                "UNION select NOMBRE from T_CABECERAS  " +
                "UNION select NOMBRE from T_APOYABRAZOS order by NOMBRE " ;
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable FiltrarRegistros(string dia, int Turno)
        {
            DateTime hoy = Convert.ToDateTime(dia);
            DateTime dia2 = hoy.AddDays(1);
            DataTable dt = new DataTable();
            string strProc = "  SELECT CONVERT( VARCHAR , R.Fecha , 103 ) 'FECHA',CONVERT( VARCHAR , R.Hora , 108 ) 'HORA',  M.Nombre 'MODELO',CA.CANTIDAD 'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID=M.ID inner join  T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where ((CONVERT(varchar(10), R.Hora, 108) >='06:00:00' and (CONVERT(varchar(10), R.hora, 108) <'15:40:00') and CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + hoy.ToString("dd/MM/yyyy") + "' , 103 )) ) group by R.Hora,R.Fecha,CA.CANTIDAD, M.Nombre"+  
                             " UNION SELECT CONVERT(VARCHAR, R.Fecha, 103) 'FECHA',CONVERT(VARCHAR, R.Hora, 108) 'HORA',  M.Nombre 'MODELO',CA.CANTIDAD 'CANTIDAD' from T_REGISTROS R inner join T_CABECERAS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where((CONVERT(varchar(10), R.Hora, 108) >= '06:00:00' and(CONVERT(varchar(10), R.hora, 108) < '15:40:00') and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) ) group by R.Hora,R.Fecha,CA.CANTIDAD, M.Nombre"+
                             " UNION SELECT CONVERT(VARCHAR, R.Fecha, 103 ) 'FECHA',CONVERT(VARCHAR, R.Hora, 108) 'HORA',  M.Nombre 'MODELO',CA.CANTIDAD 'CANTIDAD' from T_REGISTROS R inner join T_APOYABRAZOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where((CONVERT(varchar(10), R.Hora, 108) >= '06:00:00' and(CONVERT(varchar(10), R.hora, 108) < '15:40:00') and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) ) group by R.Hora,R.Fecha,CA.CANTIDAD, M.Nombre"+
                             " UNION SELECT CONVERT(VARCHAR, R.Fecha, 103 ) 'FECHA',CONVERT(VARCHAR, R.Hora, 108) 'HORA',  M.Nombre 'MODELO', 'CANTIDAD' = 10 from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID  Where((CONVERT(varchar(10), R.Hora, 108) >= '06:00:00' and(CONVERT(varchar(10), R.hora, 108) < '15:40:00') and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) ) group by R.Hora,R.Fecha, M.Nombre Order by FECHA DESC, HORA DESC";
            string strProc2 = " SELECT CONVERT( VARCHAR , R.Fecha , 103 ) 'FECHA',CONVERT( VARCHAR , R.Hora , 108 ) 'HORA',  M.Nombre 'MODELO',CA.CANTIDAD 'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID=M.ID inner join  T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where  ((CONVERT(varchar(10), R.Hora, 108) >='15:40:00'  and CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + hoy.ToString("dd/MM/yyyy") + "' , 103 )) or ((CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 ) and (CONVERT(varchar(10), R.Hora, 108) <'06:00:00')))) group by R.Hora,R.Fecha,CA.CANTIDAD, M.Nombre"+
                             "UNION SELECT CONVERT(VARCHAR, R.Fecha, 103) 'FECHA',CONVERT(VARCHAR, R.Hora, 108) 'HORA',  M.Nombre 'MODELO',CA.CANTIDAD 'CANTIDAD' from T_REGISTROS R inner join T_CABECERAS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where((CONVERT(varchar(10), R.Hora, 108) >= '15:40:00'  and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00')))) group by R.Hora,R.Fecha,CA.CANTIDAD, M.Nombre"+
                             "UNION SELECT CONVERT(VARCHAR, R.Fecha, 103 ) 'FECHA',CONVERT(VARCHAR, R.Hora, 108) 'HORA',  M.Nombre 'MODELO',CA.CANTIDAD 'CANTIDAD' from T_REGISTROS R inner join T_APOYABRAZOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where((CONVERT(varchar(10), R.Hora, 108) >= '15:40:00'  and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00')))) group by R.Hora,R.Fecha,CA.CANTIDAD, M.Nombre"+
                             "UNION SELECT CONVERT(VARCHAR, R.Fecha, 103 ) 'FECHA',CONVERT(VARCHAR, R.Hora, 108) 'HORA',  M.Nombre 'MODELO', 'CANTIDAD' = 10 from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID  Where((CONVERT(varchar(10), R.Hora, 108) >= '15:40:00'  and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00')))) group by R.Hora,R.Fecha,M.Nombre Order by FECHA DESC, HORA DESC";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            SqlDataAdapter objDaTraer2 = new SqlDataAdapter(strProc2, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            if (Turno == 1)
            {
                objDaTraer.Fill(dt);
            }
            if (Turno == 2)
            {
                objDaTraer2.Fill(dt);

            }
            return dt;
        }
        public static  DataTable ListarRegistros(string dia)
        
            {
            DateTime hoy = Convert.ToDateTime(dia);
            DateTime dia2 = hoy.AddDays(1);
            DataTable dt = new DataTable();
            string strProc = "  SELECT CONVERT( VARCHAR , R.Fecha , 103 ) 'FECHA',CONVERT( VARCHAR , R.Hora , 108 ) 'HORA',  M.Nombre 'MODELO',CA.CANTIDAD 'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join  T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where (CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + hoy.ToString("dd/MM/yyyy") + "' , 103 ) and CONVERT(varchar(10), R.Hora, 108) >='06:00:00') or ((CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 ) and (CONVERT(varchar(10), R.Hora, 108) <'06:00:00'))) group by R.Hora,R.Fecha,CA.CANTIDAD, M.Nombre" +
                             " UNION SELECT CONVERT(VARCHAR, R.Fecha, 103) 'FECHA',CONVERT(VARCHAR, R.Hora, 108) 'HORA',  M.Nombre 'MODELO',CA.CANTIDAD 'CANTIDAD' from T_REGISTROS R inner join T_CABECERAS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where (CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + hoy.ToString("dd/MM/yyyy") + "' , 103 ) and CONVERT(varchar(10), R.Hora, 108) >='06:00:00') or ((CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 ) and (CONVERT(varchar(10), R.Hora, 108) <'06:00:00'))) group by R.Hora,R.Fecha,CA.CANTIDAD, M.Nombre" +
                             " UNION SELECT CONVERT(VARCHAR, R.Fecha, 103 ) 'FECHA',CONVERT(VARCHAR, R.Hora, 108) 'HORA',  M.Nombre 'MODELO',CA.CANTIDAD 'CANTIDAD' from T_REGISTROS R inner join T_APOYABRAZOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where (CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + hoy.ToString("dd/MM/yyyy") + "' , 103 ) and CONVERT(varchar(10), R.Hora, 108) >='06:00:00') or ((CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 ) and (CONVERT(varchar(10), R.Hora, 108) <'06:00:00')))group by R.Hora,R.Fecha,CA.CANTIDAD, M.Nombre" +
                            // " UNION SELECT CONVERT(VARCHAR, R.Fecha, 103 ) 'FECHA',CONVERT(VARCHAR, R.Hora, 108) 'HORA',  TI.TIPO 'MODELO', CA.CANTIDAD 'CANTIDAD' from T_REGISTROS R inner join T_CODIGOS COO on COO.ID = R.ID_CODIGO inner join T_C_TIPOS TI on TI.ID = COO.ID_C_TIPO inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD  Where COO.ID_C_TIPO = 8 and (CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + hoy.ToString("dd/MM/yyyy") + "' , 103 ) and CONVERT(varchar(10), R.Hora, 108) >='06:00:00') or ((CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 ) and (CONVERT(varchar(10), R.Hora, 108) <'06:00:00'))) group by R.Hora,R.Fecha,CA.CANTIDAD, TI.Tipo " +
                             " UNION SELECT CONVERT(VARCHAR, R.Fecha, 103 ) 'FECHA',CONVERT(VARCHAR, R.Hora, 108) 'HORA',  M.Nombre 'MODELO', 'CANTIDAD' = 10 from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID  Where (CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + hoy.ToString("dd/MM/yyyy") + "' , 103 ) and CONVERT(varchar(10), R.Hora, 108) >='06:00:00') or ((CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 ) and (CONVERT(varchar(10), R.Hora, 108) <'06:00:00'))) group by R.Hora,R.Fecha, M.Nombre Order by FECHA DESC, HORA DESC " ;
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ListarContadoresTT(string dia)
        {

            DateTime hoy = Convert.ToDateTime(dia);
            DateTime dia2 = hoy.AddDays(1);
            DataTable dt = new DataTable();
            string strProc = "  SELECT  M.Nombre 'MODELO',SUM(CA.CANTIDAD) 'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID=M.ID inner join  T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where ((CONVERT(varchar(10), R.Hora, 108) >='15:40:00'  and CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + hoy.ToString("dd/MM/yyyy") + "' , 103 )) or ((CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 ) and (CONVERT(varchar(10), R.Hora, 108) <'06:00:00')))) group by  M.Nombre "+ 
                             "UNION SELECT M.Nombre 'MODELO',SUM(CA.CANTIDAD) 'CANTIDAD' from T_REGISTROS R inner join T_CABECERAS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where((CONVERT(varchar(10), R.Hora, 108) >= '15:40:00'  and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00')))) group by M.Nombre "+
                             "UNION SELECT M.Nombre 'MODELO',SUM(CA.CANTIDAD) 'CANTIDAD' from T_REGISTROS R inner join T_APOYABRAZOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where((CONVERT(varchar(10), R.Hora, 108) >= '15:40:00'  and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00'))))group by M.Nombre "+
                             "UNION SELECT M.Nombre 'MODELO',SUM(CA.CANTIDAD) 'CANTIDAD' from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where((CONVERT(varchar(10), R.Hora, 108) >= '15:40:00'  and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00')))) group by M.Nombre Order by MODELO";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ListarDolliesTT(string dia)
        {

            DateTime hoy = Convert.ToDateTime(dia);
            DateTime dia2 = hoy.AddDays(1);
            DataTable dt = new DataTable();
            string strProc =  "SELECT M.Nombre 'MODELO',COUNT(M.ID) 'CANTIDAD' from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID Where((CONVERT(varchar(10), R.Hora, 108) >= '15:40:00'  and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00')))) group by  M.Nombre "+
                              "UNION SELECT M.Nombre 'MODELO',COUNT(M.ID) 'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID Where((CONVERT(varchar(10), R.Hora, 108) >= '15:40:00'  and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00')))) group by  M.Nombre Order by MODELO";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ContadoresxModelo(string dia)
        {

            DateTime hoy = Convert.ToDateTime(dia);
            DateTime dia2 = hoy.AddDays(1);
            DataTable dt = new DataTable();
            string strProc = "select MO.NOMBRE 'MODELO' ,M.ID_CODIGO 'CODIGO', D.TIPO + ' '+ LA.LADO 'DESCRIPCION',HR.NOMBRE 'H/R', AR.NOMBRE 'A/R', SUM(CA.CANTIDAD) 'TOTAL' "+
                             "from R_MODELO_CODIGO M full join T_CODIGOS C on M.ID_CODIGO =C.ID full join T_REGISTROS R1 on R1.ID_CODIGO = M.ID_CODIGO "+
                             " full join T_C_TIPOS D on D.ID = C.ID_C_TIPO full join T_CANTIDADES CA on CA.ID = C.ID_CANTIDAD full join T_LADO LA on "+
                             " LA.ID = C.ID_LADO  full join T_MODELOS MO on MO.ID = M.ID_MODELO  full join T_CABECERAS HR on HR.ID = C.ID full join T_APOYABRAZOS AR on AR.ID = C.ID "+
                             " where MO.NOMBRE is not null and (CONVERT(VARCHAR, R1.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and CONVERT(varchar(10), R1.Hora, 108) >= '06:00:00') or((CONVERT(VARCHAR, R1.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R1.Hora, 108) < '06:00:00')))"+
                             " group by MO.NOMBRE,M.ID_MODELO,M.ID_CODIGO,D.TIPO,CA.CANTIDAD,LA.LADO,AR.NOMBRE,HR.NOMBRE"+
                             " UNION " +
                             "select MO.NOMBRE 'MODELO' ,MO.ID 'CODIGO', D.TIPO + ' '+ LA.LADO 'DESCRIPCION',HR.NOMBRE 'H/R', AR.NOMBRE 'A/R', SUM(CA.CANTIDAD) 'TOTAL'"+
                             "from  T_CODIGOS C  full join T_C_TIPOS D on D.ID = C.ID_C_TIPO full join T_LADO LA on LA.ID = C.ID_LADO  full join T_DOOR_TRIM MO on MO.ID = C.ID "+
                             "full join T_REGISTROS R1 on R1.ID_CODIGO = C.ID full join T_CABECERAS HR on HR.ID = C.ID full join T_APOYABRAZOS AR on AR.ID = C.ID full join T_CANTIDADES CA on CA.ID = C.ID_CANTIDAD "+
                             "where MO.NOMBRE is not null and (CONVERT(VARCHAR, R1.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and CONVERT(varchar(10), R1.Hora, 108) >= '06:00:00') or((CONVERT(VARCHAR, R1.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R1.Hora, 108) < '06:00:00')))"+
                             "group by MO.NOMBRE,MO.ID,D.TIPO,LA.LADO ,CA.CANTIDAD,AR.NOMBRE,HR.NOMBRE";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ComponentesxModelo(string dia)
        {

            DateTime hoy = Convert.ToDateTime(dia);
            DateTime dia2 = hoy.AddDays(1);
            DataTable dt = new DataTable();
            string strProc = "select MO.NOMBRE 'MODELO' ,M.ID_CODIGO 'CODIGO', D.TIPO + ' '+ LA.LADO 'DESCRIPCION',HR.NOMBRE 'HR', AR.NOMBRE 'AR'"+
                             "from R_MODELO_CODIGO M full join T_CODIGOS C on M.ID_CODIGO =C.ID full join T_REGISTROS R1 on R1.ID_CODIGO = M.ID_CODIGO "+
                              "full join T_C_TIPOS D on D.ID = C.ID_C_TIPO full join T_LADO LA on "+ 
                              "LA.ID = C.ID_LADO  inner join T_MODELOS MO on MO.ID = M.ID_MODELO  full join T_CABECERAS HR on HR.ID = C.ID full join T_APOYABRAZOS AR on AR.ID = C.ID "+
                            "where 'MODELO' is not null and (CONVERT(VARCHAR, R1.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and CONVERT(varchar(10), R1.Hora, 108) >= '06:00:00') or((CONVERT(VARCHAR, R1.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R1.Hora, 108) < '06:00:00')))"+
                              "group by MO.NOMBRE,M.ID_MODELO,M.ID_CODIGO,D.TIPO,LA.LADO,AR.NOMBRE,HR.NOMBRE "+
                              "UNION "+ 
                             "select MO.NOMBRE 'MODELO' ,MO.ID 'CODIGO', D.TIPO + ' '+ LA.LADO 'DESCRIPCION',null 'HR',null  'AR'"+
                             "from  T_CODIGOS C  inner join T_C_TIPOS D on D.ID = C.ID_C_TIPO inner join T_LADO LA on LA.ID = C.ID_LADO  inner join T_DOOR_TRIM MO on MO.ID = C.ID "+ 
                             "inner join T_REGISTROS R1 on R1.ID_CODIGO = C.ID "+ 
                             " where 'MODELO' is not null and (CONVERT(VARCHAR, R1.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and CONVERT(varchar(10), R1.Hora, 108) >= '06:00:00') or((CONVERT(VARCHAR, R1.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R1.Hora, 108) < '06:00:00')))"+
                             " group by MO.NOMBRE,MO.ID,D.TIPO,LA.LADO";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ListarContadoresTM(string dia)
        {
            DateTime hoy = Convert.ToDateTime(dia);
            DataTable dt = new DataTable();
            string strProc = " SELECT  M.Nombre 'MODELO',SUM(CA.CANTIDAD) 'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID=M.ID inner join  T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where ((CONVERT(varchar(10), R.Hora, 108) >='06:00:00' and (CONVERT(varchar(10), R.hora, 108) <'15:40:00') and CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + hoy.ToString("dd/MM/yyyy") + "' , 103 )) ) group by  M.Nombre,ca.cantidad " +
                             "UNION SELECT M.Nombre 'MODELO',SUM(CA.CANTIDAD)  'CANTIDAD' from T_REGISTROS R inner join T_CABECERAS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where((CONVERT(varchar(10), R.Hora, 108) >= '06:00:00' and(CONVERT(varchar(10), R.hora, 108) < '15:40:00') and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy")+ "', 103)) ) group by M.Nombre,ca.cantidad " +
                             "UNION SELECT M.Nombre 'MODELO',SUM(CA.CANTIDAD)  'CANTIDAD' from T_REGISTROS R inner join T_APOYABRAZOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where((CONVERT(varchar(10), R.Hora, 108) >= '06:00:00' and(CONVERT(varchar(10), R.hora, 108) < '15:40:00') and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy")+ "', 103)) )group by M.Nombre,ca.cantidad " +
                             "UNION SELECT M.Nombre 'MODELO',SUM(CA.CANTIDAD) 'CANTIDAD' from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD  Where((CONVERT(varchar(10), R.Hora, 108) >= '06:00:00' and(CONVERT(varchar(10), R.hora, 108) < '15:40:00') and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy")+"', 103)) ) group by ca.cantidad, M.Nombre Order by MODELO ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ListarContadores(string dia)
        {
            DateTime hoy = Convert.ToDateTime(dia);
            DateTime dia2 = hoy.AddDays(1);
            DataTable dt = new DataTable();
            string strProc = " SELECT  M.Nombre 'MODELO',SUM(CA.CANTIDAD) 'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID=M.ID inner join  T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where (CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + hoy.ToString("dd/MM/yyyy") + "' , 103 ) and CONVERT(varchar(10), R.Hora, 108) >='06:00:00') or ((CONVERT( VARCHAR , R.Fecha , 103 ) = CONVERT( VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 ) and (CONVERT(varchar(10), R.Hora, 108) <'06:00:00'))) group by  M.Nombre "+ 
                             "UNION SELECT M.Nombre 'MODELO',SUM(CA.CANTIDAD) 'CANTIDAD' from T_REGISTROS R inner join T_CABECERAS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where(CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and CONVERT(varchar(10), R.Hora, 108) >= '06:00:00') or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00'))) group by M.Nombre "+
                             "UNION SELECT M.Nombre 'MODELO',SUM(CA.CANTIDAD) 'CANTIDAD' from T_REGISTROS R inner join T_APOYABRAZOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD Where(CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and CONVERT(varchar(10), R.Hora, 108) >= '06:00:00') or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00')))group by M.Nombre "+
                             "UNION SELECT M.Nombre 'MODELO',SUM(CA.CANTIDAD) 'CANTIDAD' from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID inner join T_CANTIDADES CA on CA.ID = COO.ID_CANTIDAD  Where(CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and CONVERT(varchar(10), R.Hora, 108) >= '06:00:00') or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00'))) group by M.Nombre Order by MODELO ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable FiltrarContadores(string pDesde, string pHasta)//filta por dia de 00 a 00
        {
            DateTime Desde = Convert.ToDateTime(pDesde);
            DateTime Hasta = Convert.ToDateTime(pHasta);
            DateTime dia2 = Hasta.AddDays(1);
            DataTable dt = new DataTable();
            //string strProc = " SELECT M.Nombre 'MODELO', SUM(M.Cantidad)'CANTIDAD' from T_Registro R inner join T_Modelo M on R.Modelo = M.ID Where ((CONVERT( VARCHAR , R.Fecha , 103 ) >= CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 )) and (CONVERT( VARCHAR , R.Fecha , 103 ) <= CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ))) group by M.Nombre ";
            string strProc = " SELECT M.Nombre 'MODELO', SUM(CA.Cantidad)'CANTIDAD' from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS C on M.ID = C.ID inner join  T_CANTIDADES CA on CA.ID = C.ID_CANTIDAD where R.Fecha between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ) group by M.Nombre "+
                "UNION SELECT M.Nombre 'MODELO', SUM(CA.Cantidad)'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID inner join T_CODIGOS C on M.ID = C.ID inner join  T_CANTIDADES CA on CA.ID = C.ID_CANTIDAD where R.Fecha between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ) group by M.Nombre " +
                "UNION SELECT M.Nombre 'MODELO', SUM(CA.Cantidad)'CANTIDAD' from T_REGISTROS R inner join T_CABECERAS M on R.ID_CODIGO = M.ID inner join T_CODIGOS C on M.ID = C.ID inner join  T_CANTIDADES CA on CA.ID = C.ID_CANTIDAD where R.Fecha between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ) group by M.Nombre "+
                "UNION SELECT M.Nombre 'MODELO', SUM(CA.Cantidad)'CANTIDAD' from T_REGISTROS R inner join T_APOYABRAZOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS C on M.ID = C.ID inner join  T_CANTIDADES CA on CA.ID = C.ID_CANTIDAD where R.Fecha between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ) group by M.Nombre order by MODELO ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable FiltrarContadores2(string pDesde, string pHasta)//filtra por dia en SAR de 6 a 6
        {
            DateTime Desde = Convert.ToDateTime(pDesde);
            DateTime Hasta = Convert.ToDateTime(pHasta);
            DateTime dia2 = Hasta.AddDays(1);
            DataTable dt = new DataTable();
            //string strProc = " SELECT M.Nombre 'MODELO', SUM(M.Cantidad)'CANTIDAD' from T_Registro R inner join T_Modelo M on R.Modelo = M.ID Where ((CONVERT( VARCHAR , R.Fecha , 103 ) >= CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 )) and (CONVERT( VARCHAR , R.Fecha , 103 ) <= CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ))) group by M.Nombre ";
            string strProc = " SELECT M.Nombre 'MODELO', SUM(CA.Cantidad)'CANTIDAD' from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS C on M.ID = C.ID inner join  T_CANTIDADES CA on CA.ID = C.ID_CANTIDAD where R.Fecha between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00'))) group by M.Nombre " +
                "UNION SELECT M.Nombre 'MODELO', SUM(CA.Cantidad)'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID inner join T_CODIGOS C on M.ID = C.ID inner join  T_CANTIDADES CA on CA.ID = C.ID_CANTIDAD where R.Fecha between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00'))) group by M.Nombre " +
                "UNION SELECT M.Nombre 'MODELO', SUM(CA.Cantidad)'CANTIDAD' from T_REGISTROS R inner join T_CABECERAS M on R.ID_CODIGO = M.ID inner join T_CODIGOS C on M.ID = C.ID inner join  T_CANTIDADES CA on CA.ID = C.ID_CANTIDAD where R.Fecha between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00'))) group by M.Nombre " +
                "UNION SELECT M.Nombre 'MODELO', SUM(CA.Cantidad)'CANTIDAD' from T_REGISTROS R inner join T_APOYABRAZOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS C on M.ID = C.ID inner join  T_CANTIDADES CA on CA.ID = C.ID_CANTIDAD where R.Fecha between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00'))) group by M.Nombre order by MODELO ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable FiltrarDollies(string pDesde, string pHasta)
        {
            DateTime Desde = Convert.ToDateTime(pDesde);
            DateTime Hasta = Convert.ToDateTime(pHasta);
            DateTime dia2 = Hasta.AddDays(1);
            DataTable dt = new DataTable();
            //string strProc = " SELECT M.Nombre 'MODELO', SUM(M.Cantidad)'CANTIDAD' from T_Registro R inner join T_Modelo M on R.Modelo = M.ID Where ((CONVERT( VARCHAR , R.Fecha , 103 ) >= CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 )) and (CONVERT( VARCHAR , R.Fecha , 103 ) <= CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ))) group by M.Nombre ";
            string strProc = " SELECT M.Nombre 'MODELO', COUNT(M.ID)'CANTIDAD' from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID  where R.Fecha between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 )  group by M.Nombre " +
                             "UNION SELECT M.Nombre 'MODELO', COUNT(M.ID)'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID  where R.Fecha between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 )  group by M.Nombre order by MODELO ";
          
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable FiltrarDollies2(string pDesde, string pHasta)
        {
            DateTime Desde = Convert.ToDateTime(pDesde);
            DateTime Hasta = Convert.ToDateTime(pHasta);
            DateTime dia2 = Hasta.AddDays(1);
            DataTable dt = new DataTable();
            //string strProc = " SELECT M.Nombre 'MODELO', SUM(M.Cantidad)'CANTIDAD' from T_Registro R inner join T_Modelo M on R.Modelo = M.ID Where ((CONVERT( VARCHAR , R.Fecha , 103 ) >= CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 )) and (CONVERT( VARCHAR , R.Fecha , 103 ) <= CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ))) group by M.Nombre ";
            string strProc = " SELECT M.Nombre 'MODELO', COUNT(M.ID)'CANTIDAD' from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID  where R.Fecha between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 ) or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00'))) group by M.Nombre " +
                             "UNION SELECT M.Nombre 'MODELO', COUNT(M.ID)'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID  where R.Fecha between CONVERT( VARCHAR , '" + Desde.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + Hasta.ToString("dd/MM/yyyy") + "' , 103 )or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00'))) group by M.Nombre order by MODELO ";

            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable PendientesDeArmado()
        {
            DataTable dt = new DataTable();
            string strProc = "Select A.ID_CODIGO 'CODIGO',T.TIPO 'DESCRIPCION' , A.CANTIDAD 'CANTIDAD' " +
                " from T_ARMADOS A inner join T_CODIGOS C on A.ID_CODIGO = C.ID inner join T_C_TIPOS T on T.ID = C.ID_C_TIPO " +
                "Where A.CANTIDAD <> 0  order by A.ID";

            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }


        public static string TraerUltimoArmado()
        {
            string strProc = "select CONVERT(VARCHAR,FECHA, 103 ) +' '+CONVERT(VARCHAR,HORA, 108) from T_REGISTROS_ARMADO where ID = (SELECT MAX(ID) FROM T_REGISTROS_ARMADO)";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(strProc, objConexion);
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            return objComAgregar.ExecuteScalar().ToString();
            objConexion.Close();
           
        }
        public static DataTable ListarDolliesTM(string dia)
        {
            DateTime hoy = Convert.ToDateTime(dia);
            DataTable dt = new DataTable();
            string strProc = "SELECT M.Nombre 'MODELO',COUNT(M.ID) 'CANTIDAD' from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID  Where((CONVERT(varchar(10), R.Hora, 108) >= '06:00:00' and(CONVERT(varchar(10), R.hora, 108) < '15:40:00') and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) ) group by M.Nombre "+
                             "UNION SELECT M.Nombre 'MODELO',COUNT(M.ID) 'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID  Where((CONVERT(varchar(10), R.Hora, 108) >= '06:00:00' and(CONVERT(varchar(10), R.hora, 108) < '15:40:00') and CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103)) ) group by M.Nombre Order by MODELO ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ListarDollies(string dia)
        {
            DateTime hoy = Convert.ToDateTime(dia);
            DateTime dia2 = hoy.AddDays(1);
            DataTable dt = new DataTable();
            string strProc = "SELECT M.Nombre 'MODELO',COUNT(M.ID) 'CANTIDAD' from T_REGISTROS R inner join T_MODELOS M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID Where(CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and CONVERT(varchar(10), R.Hora, 108) >= '06:00:00') or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00'))) group by M.Nombre "+
                             "UNION SELECT M.Nombre 'MODELO',COUNT(M.ID) 'CANTIDAD' from T_REGISTROS R inner join T_DOOR_TRIM M on R.ID_CODIGO = M.ID inner join T_CODIGOS COO on COO.ID = M.ID Where(CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + hoy.ToString("dd/MM/yyyy") + "', 103) and CONVERT(varchar(10), R.Hora, 108) >= '06:00:00') or((CONVERT(VARCHAR, R.Fecha, 103) = CONVERT(VARCHAR, '" + dia2.ToString("dd/MM/yyyy") + "', 103) and(CONVERT(varchar(10), R.Hora, 108) < '06:00:00'))) group by M.Nombre Order by MODELO ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }

        public static DataTable TrearGeneral()

        {
            DataTable dt = new DataTable();
            string strProc = " select vt.TIPO 'TIPO',v.ID_VEHICULO 'VEHICULO',f.FILA 'FILA',b.NOMBRE 'MODELO', c.ID 'CODIGO', t.TIPO 'DESCRIPCION', l.LADO 'LADO',  'A'= CASE when b.AIRBAG = 1 and t.ID =1 then cast (1 as bit)  when b.AIRBAG = 1 and t.ID = 2 then cast (1 as bit) else cast (0 as bit) end,'H'= CASE when b.HEATER = 1 and t.ID =1 then cast(1 as bit)  when b.HEATER = 1 and t.ID =2 then cast(1as bit) else cast(0 as bit) end,h.MATERIAL 'MATERIAL',g.COLOR 'COLOR' from T_CODIGOS c inner join T_C_TIPOS t on c.ID_C_TIPO = t.ID inner join T_LADO l  on c.ID_LADO = l.ID inner join R_MODELO_CODIGO m on RTRIM(c.ID) = RTRIM(m.ID_CODIGO) inner join T_MODELOS b on RTRIM(b.ID) = RTRIM(m.ID_MODELO) inner join R_VEHICULO_MODELO v on RTRIM(v.ID_MODELO)=RTRIM(m.ID_MODELO)inner join T_VEHICULOS ve on ve.ID=v.ID_VEHICULO inner join T_V_TIPOS vt on vt.ID=ve.ID_V_TIPO inner join T_FILAS f on f.ID= b.ID_FILA inner join T_MATERIAL h on h.ID=b.ID_MATERIAL inner join T_COLOR g on g.ID= b.ID_COLOR   group by c.ID,t.TIPO,l.LADO,b.NOMBRE,v.ID_VEHICULO,ve.ID,vt.TIPO,f.FILA ,h.MATERIAL,b.AIRBAG,b.HEATER,b.BLOWER,g.COLOR,t.ID order by vt.TIPO,v.ID_VEHICULO, b.NOMBRE";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;

        }
        public static int StockTango(string pModelo)
        {
            int dt;
            string strProc = "select CANT_STOCK from STA19 where COD_DEPOSI = 01 and COD_ARTICU = '" + pModelo.Trim() + "' ";
            SqlConnection objConexion = new SqlConnection(Conexion2.strConexion);
            SqlCommand objDaTraer = new SqlCommand(strProc, objConexion);
            objDaTraer.CommandType = CommandType.Text;
            objConexion.Open();
            dt = Convert.ToInt32(objDaTraer.ExecuteScalar());
            objConexion.Close();
            return dt;

        }
        public static int PendienteTango(string pModelo)
        {
            int dt;
            string strProc = "select CANTIDAD  from T_ARMADOS where ID_CODIGO = '" + pModelo.Trim() + "' ";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objDaTraer = new SqlCommand(strProc, objConexion);
            objDaTraer.CommandType = CommandType.Text;
            objConexion.Open();
            dt = Convert.ToInt32(objDaTraer.ExecuteScalar());
            objConexion.Close();
            return dt;

        }
        public static int AjusteTango(string pModelo)
        {
            int dt;
            string strProc = "select AJUSTE  from T_ARMADOS where ID_CODIGO = '" + pModelo.Trim() + "' ";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objDaTraer = new SqlCommand(strProc, objConexion);
            objDaTraer.CommandType = CommandType.Text;
            objConexion.Open();
            dt = Convert.ToInt32(objDaTraer.ExecuteScalar());
            objConexion.Close();
            return dt;

        }
        public static DataTable TrearBaseStock()

        {
            DataTable dt = new DataTable();
            string strProc = "  select b.NOMBRE 'MODELO', c.ID 'CODIGO', t.TIPO +' '+l.LADO 'DESCRIPCION' from T_CODIGOS c inner join T_C_TIPOS t on c.ID_C_TIPO = t.ID inner join T_LADO l  on c.ID_LADO = l.ID inner join R_MODELO_CODIGO m on RTRIM(c.ID) = RTRIM(m.ID_CODIGO) inner join T_MODELOS b on RTRIM(b.ID) = RTRIM(m.ID_MODELO) inner join R_VEHICULO_MODELO v on RTRIM(v.ID_MODELO)=RTRIM(m.ID_MODELO) group by c.ID,t.TIPO,l.LADO,b.NOMBRE,t.ID "+ 
           "union "+
           "select d.NOMBRE 'MODELO',d.ID 'CODIGO',ct.TIPO + ' ' + l.LADO  'DESCRIPCION' from T_CODIGOS c inner join T_DOOR_TRIM d on d.ID = c.ID inner join T_C_TIPOS ct on ct.ID = c.ID_C_TIPO inner join T_LADO l on l.ID = c.ID_LADO inner join T_MATERIAL m on m.ID = d.ID_MATERIAL  group by d.NOMBRE,d.ID,ct.TIPO,l.LADO,m.MATERIAL order by 'MODELO'";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;

        }
        public static DataTable TrearDoor()

        {
            DataTable dt = new DataTable();
            string strProc = "  select tv.TIPO 'TIPO', f.FILA 'FILA' ,d.NOMBRE 'MODELO',d.ID 'CODIGO',ct.TIPO 'DESCRIPCION',l.LADO 'LADO',m.MATERIAL 'MATERIAL', co.COLOR 'COLOR' from T_CODIGOS c inner join T_DOOR_TRIM d on d.ID=c.ID inner join T_C_TIPOS ct on ct.ID = c.ID_C_TIPO inner join T_LADO l on l.ID = c.ID_LADO inner join T_MATERIAL m on m.ID = d.ID_MATERIAL inner join T_COLOR co on co.ID=d.ID_COLOR inner join T_FILAS f on f.ID = d.ID_FILA inner join T_V_TIPOS tv on tv.ID= d.ID_T_V_TIPOS group by tv.TIPO, d.NOMBRE,d.ID,ct.TIPO,l.LADO,m.MATERIAL,co.COLOR,f.FILA order by d.NOMBRE";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;

        }
        public static DataTable LiastarPatch()
        {

            DataTable dt = new DataTable();
            string strProc = "select ID from T_CODIGOS where ID_C_TIPO = 8 ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static void CargarArmado(string pCodigo, int pCant)
        {
            string strProc = "update T_ARMADOS set CANTIDAD = CANTIDAD + '" + pCant + "' where RTRIM(ID_CODIGO) = '" + pCodigo.Trim() + "'";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(strProc, objConexion);
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
                // se ejecuta siempre
                // cierro la conexion
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }
        }
  
        public static int TrearCantidadCodigo(string pCodigo)
        {

            string strProc = "Select ID_CANTIDAD from T_CODIGOS where RTRIM(ID) = '" + pCodigo.Trim() + "'";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(strProc, objConexion);
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            int Cant = Convert.ToInt32(objComAgregar.ExecuteScalar());
            objConexion.Close();
            return Cant;

        }
        public static int TrearCantidad(int IDCant)
        {

            string strProc = "Select CANTIDAD from T_CANTIDADES where ID = '" + IDCant + "'";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(strProc, objConexion);
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            int Cant = Convert.ToInt32(objComAgregar.ExecuteScalar());
            objConexion.Close();
            return Cant;

        }
        public static void CargarRegistro(string Codigo)
        {
            DateTime Hoy = DateTime.Now;
            TimeSpan Hora = Hoy.TimeOfDay;
            DateTime Fecha = Hoy.Date;
            string strProc = "Insert T_REGISTROS (FECHA,HORA,ID_CODIGO) Values(@Fecha,@Hora,'" + Codigo.Trim() + "')";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(strProc, objConexion);
            objComAgregar.Parameters.AddWithValue("@Fecha", Fecha);
            objComAgregar.Parameters.AddWithValue("@Hora", Hora);
            objComAgregar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComAgregar.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                // throw new Exception("ERROR EN BASE DE DATOS");
            }
            finally
            {
                //    // se ejecuta siempre
                //    // cierro la conexion
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }


        }
    }


}
