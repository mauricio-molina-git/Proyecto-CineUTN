using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    public class Datos
    {
        private String conexion;

        public Datos(String conexion)
        {
            this.conexion = conexion;
        }

        public SqlCommand Procedimiento(string procedimiento)
        {
            SqlCommand comando = new SqlCommand(procedimiento, new SqlConnection(conexion))
            {
                CommandType = CommandType.StoredProcedure
            };
            return comando;
        }

        public List<Registro> Consultar(string strSQL)
        {
            List<Registro> resultado = new List<Registro>();
            DataTable tabla;
            SqlCommand comando = null;
            try
            {
                comando = new SqlCommand(strSQL, new SqlConnection(conexion));
                comando.Connection.Open();
                tabla = new DataTable();
                new SqlDataAdapter(comando).Fill(tabla);
                foreach (DataRow row in tabla.Rows)
                {
                    Registro reg = new Registro();
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        reg.Add(row[i].ToString());
                    }
                    resultado.Add(reg);
                }
            }
            catch
            {
                resultado = null;
            }
            finally
            {
                if (comando != null)
                {
                    comando.Connection.Close();
                }
            }
            return resultado;
        }

        public bool Ejecutar(SqlCommand comando)
        {
            bool exito;
            try
            {
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
                comando.Connection.Close();
            }
            return exito;
        }
    }
}
