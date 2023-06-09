using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Linea
    {
        public string MODELO { get; set; }
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public int TANGO { get; set; }
        public int PENDIENTE { get; set; }
        public int AJUSTE { get; set; }
        public int STOCK { get; set; }
    }
}
