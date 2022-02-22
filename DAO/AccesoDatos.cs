using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    class AccesoDatos
    {
        String rutaCine =
      "Data Source=localhost\\sqlexpress;Initial Catalog=Cine;Integrated Security=True";

        public AccesoDatos()
        {
            // TODO: Agregar aquí la lógica del constructor
        }

        public string ObtenerRuta()
        {
            return rutaCine;
        }

        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaCine);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }
    }
}
