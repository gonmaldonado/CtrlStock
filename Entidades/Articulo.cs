using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Articulo
    {
        public string ID { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal CANTIDAD { get; set; }
        public decimal VAL_CRITICO { get; set; }
        public string UM { get; set; }
        public bool HABILITADO { get; set; }

    }
}
