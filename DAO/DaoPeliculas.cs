using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ENTIDAD;

namespace DATOS
{
    class DaoPeliculas
    {
        AccesoDatos ac = new AccesoDatos();

        public DataSet ObtenerListView()
        {
            string consulta = "Select * from Peliculas where formato ='2D/3D'";
            string ruta = ac.ObtenerRuta();
            SqlConnection cn = ac.ObtenerConexion();
            cn.Open();
            SqlDataAdapter adaptador = ac.ObtenerAdaptador(consulta, cn);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Peliculas");
            return ds;
        }

    }
}
