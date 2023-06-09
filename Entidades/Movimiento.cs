using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Movimiento
    {
        public DateTime FECHA { get; set; }
        public DateTime HORA { get; set; }
        public string ID_ARTICULO { get; set; }
        public string DESCRIPCION{ get; set; }
        public string ORIGEN { get; set; }
        public string MOVIMIENTO { get; set; }
        public decimal CANTIDAD{ get; set; }
        public string UM{ get; set; }

    }
}
