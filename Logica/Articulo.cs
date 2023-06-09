using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Articulo
    {
        static public DataTable TraerArticulos()
        {
            return Datos.Articulo.TraerArticulos();
        }
        static public DataTable TraerArticulosHabilitados()
        {
            return Datos.Articulo.TraerArticulosHabilitados();
        }

        static public DataTable TraerFaltantes()
        {

            return Datos.Articulo.TraerFaltantes();


        }
        static public DataTable TraerFaltantesMin()
        {

            return Datos.Articulo.TraerFaltantesMin();


        }
        static public void EntradaArticulo(string pCodigo, decimal pCant)
        {
            Datos.Articulo.EntradaArticulo(pCodigo, pCant);
        }
        static public void AltadeArticulo(Entidades.Articulo pArticulo)
        {
            Datos.Articulo.AltaArticulo(pArticulo);
        }
        static public void SalidaArticulo(string pCodigo, decimal pCant)
        {
            Datos.Articulo.SalidaArticulo(pCodigo, pCant);
        }
        static public Boolean ValidarCodigo(string pCodigo)
        {
            return Datos.Articulo.ValidarCodigo(pCodigo);
        }
        static public void ModificarArticulo(Entidades.Articulo pArticulo)
        {
            Datos.Articulo.ModificarArticulo(pArticulo);
        }
        static public void EliminarArticulo(string pCodigo)
        {
            Datos.Articulo.EliminarArticulo(pCodigo);
        }
    }
}
