using System.Data;

namespace Logica
{
    public class UM
    {
        static public int TraerTipoUM(string pUM)
        {
            return Datos.UM.TraerTipoUM(pUM);
        }
        public static DataTable TraerUMs(int tipo)
        {
            return Datos.UM.TraerUM(tipo);
        }
        public static DataTable TraerTodosUMs()
        {
            return Datos.UM.TraerTodosUM();
        }
    }
}
