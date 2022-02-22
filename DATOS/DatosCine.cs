using ENTIDAD;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DATOS
{
    public class DatosCine
    {
        private static Datos datos = null;

        public static void Conectar()
        {
            if (datos == null)
            {
                datos = new Datos("Data Source=localhost\\sqlexpress;Initial Catalog=CineUTN;Integrated Security=True");
            }
        }

        public static bool AgregarUsuario(string nombre, string apellido,int dni, string genero, int nacimiento, string email, string telefono, string password, bool admin, bool activo)
        {
            bool exito = !ExisteEmail(email);

            if(exito) {
                SqlCommand comando = datos.Procedimiento("AgregarUsuario");
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Apellido", apellido);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Genero", genero);
                comando.Parameters.AddWithValue("@Nacimiento", nacimiento);
                comando.Parameters.AddWithValue("@Email", email);
                comando.Parameters.AddWithValue("@Telefono", telefono);
                comando.Parameters.AddWithValue("@Password", password);
                comando.Parameters.AddWithValue("@Admin", admin);
                comando.Parameters.AddWithValue("@Activo", activo);

                exito = datos.Ejecutar(comando);
            }

            return exito;
        }

        public static bool AgregarTarjetas(int IdUsuario, long NumTarjeta, int MesVencimiento, int AnioVencimiento, int CodSeguridad, int DniTitular, string NombreTitular)
        {
            bool exito = !ExisteTarjeta(NumTarjeta);
            
            if(exito)
            {
                SqlCommand comando = datos.Procedimiento("AgregarTarjeta");
                comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                comando.Parameters.AddWithValue("@NumTarjeta", NumTarjeta);
                comando.Parameters.AddWithValue("@MesVencimiento", MesVencimiento);
                comando.Parameters.AddWithValue("@AnioVencimiento", AnioVencimiento);
                comando.Parameters.AddWithValue("@CodSeguridad", CodSeguridad);
                comando.Parameters.AddWithValue("@DniTitular", DniTitular);
                comando.Parameters.AddWithValue("@NombreTitular", NombreTitular);

                exito = datos.Ejecutar(comando);
            }
            return exito;
        }

        public static bool AgregarPelicula(string nombre, string imagen, int calificacion, bool formato3D, int duracion, int genero, string sinopsis, bool activo)
        {
            bool exito = !ExistePelicula(nombre);
            
            if(exito)
            {
                SqlCommand comando = datos.Procedimiento("AgregarPelicula");
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Imagen", imagen);
                comando.Parameters.AddWithValue("@Calificacion", calificacion);
                comando.Parameters.AddWithValue("@Formato3D", formato3D);
                comando.Parameters.AddWithValue("@Duracion", duracion);
                comando.Parameters.AddWithValue("@Genero", genero);
                comando.Parameters.AddWithValue("@Sinopsis", sinopsis);
                comando.Parameters.AddWithValue("@Activo", activo);

                exito = datos.Ejecutar(comando);
            }
            return exito;
        }

        public static bool AgregarReservada(int reserva, int fila, int butaca)
        {
            SqlCommand comando = datos.Procedimiento("AgregarReservada");
            comando.Parameters.AddWithValue("@Reserva", reserva);
            comando.Parameters.AddWithValue("@Fila", fila);
            comando.Parameters.AddWithValue("@Butaca", butaca);

            return datos.Ejecutar(comando);
        }

        public static bool AgregarGenero(string nombre, bool activo)
        {
            bool exito = !ExisteGenero(nombre);
            if(exito)
            {
                SqlCommand comando = datos.Procedimiento("AgregarGenero");
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Activo", activo);

                exito = datos.Ejecutar(comando);
            }
            return exito;
        }

        public static bool AgregarClasificacion(string nombre, bool activo)
        {
            bool exito = !ExisteClasificacion(nombre);
            if(exito)
            {
                SqlCommand comando = datos.Procedimiento("AgregarClasificacion");
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Activo", activo);

                exito = datos.Ejecutar(comando);
            }
            return exito;

        }

        public static bool ModificarDatosUsuario( string nombre, string apellido, int dni, string telefono, int nacimiento, string email)
        {
            SqlCommand comando = datos.Procedimiento("ModificarUsuario");

            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Apellido",apellido);
            comando.Parameters.AddWithValue("@Dni", dni);
            comando.Parameters.AddWithValue("@Telefono", telefono);
            comando.Parameters.AddWithValue("@Nacimiento", nacimiento);
            comando.Parameters.AddWithValue("@Email", email);

            return datos.Ejecutar(comando);
        }

        public static bool ModificarPelicula(int id, string nombre, string imagen, int calificacion, bool formato3D, int duracion, int genero, string sinopsis, bool activo)
        {
            {
                SqlCommand comando = datos.Procedimiento("ModificarPelicula");
                comando.Parameters.AddWithValue("@Id", id);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Imagen", imagen);
                comando.Parameters.AddWithValue("@Calificacion", calificacion);
                comando.Parameters.AddWithValue("@Formato3D", formato3D);
                comando.Parameters.AddWithValue("@Duracion", duracion);
                comando.Parameters.AddWithValue("@Genero", genero);
                comando.Parameters.AddWithValue("@Sinopsis", sinopsis);
                comando.Parameters.AddWithValue("@Activo", activo);
                return datos.Ejecutar(comando);
            }
        }

        public static bool ModificarUsuario(int id, string nombre, string apellido, int dni, string genero, int nacimiento, string email, string telefono, string password, bool admin, bool activo)
        {
            SqlCommand comando = datos.Procedimiento("ModificarUser");
            comando.Parameters.AddWithValue("@Id", id);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Apellido", apellido);
            comando.Parameters.AddWithValue("@Dni", dni);
            comando.Parameters.AddWithValue("@Genero", genero);
            comando.Parameters.AddWithValue("@Nacimiento", nacimiento);
            comando.Parameters.AddWithValue("@Email", email);
            comando.Parameters.AddWithValue("@Telefono", telefono);
            comando.Parameters.AddWithValue("@Password", password);
            comando.Parameters.AddWithValue("@Admin", admin);
            comando.Parameters.AddWithValue("@Activo", activo);
            return datos.Ejecutar(comando);
        }
        public static bool ModificarCalificacion(int id, string nombre, bool activo)
        {
            SqlCommand comando = datos.Procedimiento("ModificarClasificacion");
            comando.Parameters.AddWithValue("@Id", id);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Activo", activo);

            return datos.Ejecutar(comando);
        }

        public static bool ModificarGenero(int id, string nombre, bool activo)
        {
            SqlCommand comando = datos.Procedimiento("ModificarGenero");
            comando.Parameters.AddWithValue("@Id", id);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Activo", activo);
            return datos.Ejecutar(comando);
        }

        public static bool ModificarPrecio(bool Formato3D, double Precio)
        {
            SqlCommand comando = datos.Procedimiento("ModificarPrecio");
            comando.Parameters.AddWithValue("@Formato3D", Formato3D);
            comando.Parameters.AddWithValue("@Precio", Precio);
            return datos.Ejecutar(comando);
        }

        public static int AgregarReserva(int usuario, int funcion)
        {
            int idReserva = 0;
            SqlCommand comando = datos.Procedimiento("AgregarReserva");
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Funcion", funcion);
            if(datos.Ejecutar(comando))
            {
                string strSQL =
                    "select max(id) from reserva";
                List<Registro> resultado = datos.Consultar(strSQL);
                if(resultado != null && resultado.Count > 0)
                {
                    idReserva = int.Parse(resultado[0].Get(0));
                }
            }
            return idReserva;
        }

        public static bool AgregarFuncion(int pelicula, int sala, int fecha, int hora)
        {
            bool exito = !ExisteFuncion(pelicula, sala, fecha, hora);

            if(exito)
            {
                SqlCommand comando = datos.Procedimiento("AgregarFuncion");
                comando.Parameters.AddWithValue("@Pelicula", pelicula);
                comando.Parameters.AddWithValue("@Sala", sala);
                comando.Parameters.AddWithValue("@Fecha", fecha);
                comando.Parameters.AddWithValue("@Hora", hora);

                exito = datos.Ejecutar(comando);
            }
            return exito;
        }

        public static Registro ObtenerCalificacion(int id)
        {
            string strSQL =
                "select * from calificacion where id = " + id;
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

        public static Registro ObtenerGenero(int id)
        {
            string strSQL =
                "select * from genero where id = " + id;
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

        public static Registro ObtenerSala(int id)
        {
            string strSQL =
                "select * from sala where id = " + id;
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

        public static Registro ObtenerSucursal(int id)
        {
            string strSQL =
                "select * from sucursal where id = " + id;
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

        public static Registro ObtenerPelicula(int id)
        {
            string strSQL =
                "select * from pelicula where id = " + id;
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

        public static Registro ObtenerPrecio(bool formato3d)
        {
            string strSQL =
                "select * from precio where formato3d = " + (formato3d ? "1" : "0");
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

      
        public static List<Registro> ObtenerSucursales()
        {
            string strSQL =
                "select * from sucursal";
            return datos.Consultar(strSQL);
        }

        public static List<Registro> ObtenerGeneros()
        {
            string strSQL =
                "select * from genero";
            return datos.Consultar(strSQL);
        }
        public static List<Registro> ObtenerGenerosActivos()
        {
            string strSQL =
                "select * from genero where Activo = 1";
            return datos.Consultar(strSQL);
        }

        public static List<Registro> ObtenerCalificaciones()
        {
            string strSQL =
                "select * from calificacion";
            return datos.Consultar(strSQL);
        }

        public static List<Registro> ObtenerCalificacionesActivas()
        {
            string strSQL =
                "select * from calificacion where Activo = 1";
            return datos.Consultar(strSQL);
        }

        public static List<Registro> ObtenerPeliculas()
        {
            string strSQL =
                "select * from pelicula";
            return datos.Consultar(strSQL);
        }

        public static List<Registro> ObtenerPeliculasActivas()
        {
            string strSQL =
                "select * from pelicula WHERE Activo = 1";
            return datos.Consultar(strSQL);
        }

        public static List<Registro> ObtenerUsuarios()
        {
            string strSQL =
                "select * from Usuario";
            return datos.Consultar(strSQL);
        }

        public static List<Registro> ObtenerSalas()
        {
            string strSQL =
                "select * from sala";
            return datos.Consultar(strSQL);
        }

        public static List<Registro> ObtenerPeliculasPorFormato(bool formato3D)
        {
            string strSQL =
                "select * from pelicula where activo = 1 and formato3D = " + (formato3D? "1": "0");
            return datos.Consultar(strSQL);
        }

        public static List<Registro> ObtenerFunciones(int pelicula, int sucursal)
        {
            string strSQL =
                "select f.* from (funcion f inner join sala s on s.id = f.sala)" +
                " inner join pelicula p on p.id = f.pelicula" +
                " where f.pelicula = " + pelicula + " and s.sucursal = " + sucursal + 
                " order by s.id, f.fecha, f.hora";
            return datos.Consultar(strSQL);
        }

        public static List<Registro> ObtenerFunciones(int pelicula)
        {
            string strSQL =
                "select * from funcion" +
                " where pelicula = " + pelicula +
                " order by fecha, hora";
            return datos.Consultar(strSQL);
        }

        public static List<Registro> ObtenerTarjetas(int idUsuario)
        {
            string strSQL =
                "SELECT * FROM Tarjetas WHERE IdUsuario =" + idUsuario;
            return datos.Consultar(strSQL);
        }
        public static List<Registro> ObtenerReservas(string email)
        {
            string strSQL =
                "select p.nombre, s.nombre, f.fecha, f.hora, r.fila, r.butaca" +
                " from usuario u inner join ((reserva v inner join" +
                " ((funcion f inner join sala s on s.id = f.sala)" +
                " inner join pelicula p on f.pelicula = p.id) on v.funcion = f.id)" +
                " inner join reservada r on r.reserva = v.id) on v.usuario = u.id" +
                " where u.email = '" + email + "'";
            return datos.Consultar(strSQL);
        }


        public static Registro ObtenerUsuario(string email)
        {
            string strSQL =
                "select * from usuario where email = " + Comillas(email);
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

        public static Registro ObtenerPeliculasMod(int id)
        {
            string strSQL =
                "select * from pelicula where id = " + id;
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

        public static Registro ObtenerUsuariosMod(int id)
        {
            string strSQL =
                "select * from usuario where id = " + id;
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

        public static Registro ObtenerTarjetasMostrar(int idUsuario, long numTarjeta)
        {
            string strSQL =
                "SELECT * FROM Tarjetas WHERE IdUsuario = " + idUsuario + " AND NumTarjeta =" + numTarjeta;
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

        public static Registro ObtenerCalificacionesMod(int id)
        {
            string strSQL =
                "select * from calificacion where id = " + id;
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

        public static Registro ObtenerGeneroMod(int id)
        {
            string strSQL =
                "select * from genero where id = " + id;
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

        public static Registro VerificarUsuario(string email, string pass)
        {
            string strSQL =
                "SELECT * FROM usuario WHERE email = " + Comillas(email) + " AND password = " + Comillas(pass);
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? resultado[0] : null;
        }

        //VERIFICAR REPLICAS
        public static bool ExisteEmail(string email)
        {
            string strSQL =
                "SELECT id FROM usuario WHERE email = " + Comillas(email);
            return datos.Consultar(strSQL).Count > 0;
        }
        public static bool ExistePelicula(string nombre)
        {
            string strSQL =
                "SELECT id FROM Pelicula WHERE Nombre = " + Comillas(nombre);
            return datos.Consultar(strSQL).Count > 0;
        }
        public static bool ExisteGenero(string nombre)
        {
            string strSQL =
                "SELECT id FROM Genero WHERE Nombre = " + Comillas(nombre);
            return datos.Consultar(strSQL).Count > 0;
        }
        public static bool ExisteClasificacion(string nombre)
        {
            string strSQL =
                "SELECT id FROM Calificacion WHERE Nombre = " + Comillas(nombre);
            return datos.Consultar(strSQL).Count > 0;
        }

        public static bool ExisteFuncion(int pelicula, int sala, int fecha, int hora)
        {
            string strSQL =
                "SELECT id FROM Funcion WHERE Pelicula =" + pelicula + "AND Sala =" + sala +
                "AND Fecha= " + fecha + "AND Hora =" + hora;
            return datos.Consultar(strSQL).Count > 0;
        }

        public static bool ExisteTarjeta(long numero)
        {
            string strSQL =
                "SELECT IdUsuario FROM Tarjetas WHERE NumTarjeta =" + numero;
            return datos.Consultar(strSQL).Count > 0;
        }

        public static List<Registro> ButacasReservadas(int funcion)
        {
            string strSQL =
                "select r.* from reservada r inner join reserva s on r.reserva = s.id where s.funcion = " + funcion;
            return datos.Consultar(strSQL);
        }

        public static List<Registro> ObtenerPeliculas3D()
        {
            string strSQL =
                "select * from pelicula where formato3d = " + true;
            return datos.Consultar(strSQL);
        }

        public static string Comillas(string dato)
        {
            return "'" + dato + "'";
        }


        //REPORTES SIN FECHA
        public static int VendidasPorFormato(bool formato3D)
        {
            int formato = formato3D ? 1 : 0;

            string strSQL =
                "select count(*) as total from pelicula p inner join" +
                " (funcion f inner join (reserva r inner join reservada rs" +
                " on r.id = rs.reserva) on r.funcion = f.id)" +
                " on f.pelicula = p.id where p.formato3d = " + formato;
            List<Registro> resultado = datos.Consultar(strSQL);
            int cant = int.Parse(resultado[0].Get(0));
            return cant;
        }

        public static int RecaudacionPorFormato(bool formato3D)
        {
            int formato = formato3D ? 1 : 0;

            string strSQL =
                "select count(*) as total from pelicula p inner join" +
                " (funcion f inner join (reserva r inner join reservada rs" +
                " on r.id = rs.reserva) on r.funcion = f.id)" +
                " on f.pelicula = p.id where p.formato3d = " + formato;
            List<Registro> resultado = datos.Consultar(strSQL);
            int cant = int.Parse(resultado[0].Get(0));
            strSQL =
                "select precio from precio where formato3D = " + formato;
            resultado = datos.Consultar(strSQL);
            int precio = int.Parse(resultado[0].Get(0));
            return precio * cant;
        }

        public static string PeliculaMasVista(bool formato3D)
        {
            int formato = formato3D ? 1 : 0;

            string strSQL =
                "select p.nombre, count(*) as cantidad from (pelicula p" +
                " inner join funcion f on f.pelicula = p.id) inner join" +
                " (reserva r inner join reservada rs on r.id = rs.reserva)" +
                " on f.id = r.funcion where p.formato3d = " + formato + 
                " group by p.nombre";
            List<Registro> resultado = datos.Consultar(strSQL);
            int max = 0;
            for (int i = 0; i < resultado.Count; i++)
            {
                if (int.Parse(resultado[i].Get(1)) > int.Parse(resultado[max].Get(1)))
                {
                    max = i;
                }
            }

            return resultado[max].Get(0);
        }

        public static int ReportePorPelicula(int id, int desde, int hasta)
        {
            string strSQL =
                "select count(*) from " +
                "reservada r inner join (reserva s " +
                "inner join (funcion f " +
                "inner join pelicula p " +
                "on f.pelicula = p.id) " +
                "on s.funcion = f.id) " +
                "on r.reserva = s.id " +
                "where p.id = " + id;
            if (desde != 0)
            {
                strSQL += " and f.fecha between " + desde + " and " + hasta;
            }
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? int.Parse(resultado[0].Get(0)) : 0;
        }

        public static int ReportePorGenero(int id, int desde, int hasta)
        {
            string strSQL =
                "select count(*) from " +
                "reservada r inner join (reserva s " +
                "inner join (funcion f " +
                "inner join pelicula p " +
                "on f.pelicula = p.id) " +
                "on s.funcion = f.id) " +
                "on r.reserva = s.id " +
                "where p.genero = " + id;
            if (desde != 0)
            {
                strSQL += " and f.fecha between " + desde + " and " + hasta;
            }
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? int.Parse(resultado[0].Get(0)) : 0;
        }

        public static int ReportePorSucursal(int id, int desde, int hasta)
        {
            string strSQL =
                "select count(*) from " +
                "reservada r inner join (reserva s " +
                "inner join (funcion f " +
                "inner join (sala sa " +
                "inner join sucursal su " +
                "on sa.sucursal = su.id) " +
                "on f.sala = sa.id) " +
                "on s.funcion = f.id) " +
                "on r.reserva = s.id " +
                "where su.id = " + id;
            if (desde != 0)
            {
                strSQL += " and f.fecha between " + desde + " and " + hasta;
            }
            List<Registro> resultado = datos.Consultar(strSQL);
            return resultado != null && resultado.Count > 0 ? int.Parse(resultado[0].Get(0)) : 0;
        }

    }
}
