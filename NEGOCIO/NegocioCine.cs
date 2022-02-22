using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class NegocioCine
    {
        private static Pelicula crearPelicula(Registro reg)
        {
            Pelicula pel = null;
            if (reg != null)
            {
                pel = new Pelicula
                {
                    Id = int.Parse(reg.Get(0)),
                    Nombre = reg.Get(1),
                    Imagen = reg.Get(2),
                    Calificacion = int.Parse(reg.Get(3)),
                    Formato3D = bool.Parse(reg.Get(4)),
                    Duracion = int.Parse(reg.Get(5)),
                    Genero = int.Parse(reg.Get(6)),
                    Sinopsis = reg.Get(7),
                    Activa = bool.Parse(reg.Get(8))
                };
            }
            return pel;
        }

        private static Usuario crearUsuario(Registro reg)
        {
            Usuario usu = null;
            if (reg != null)
            {
                usu = new Usuario
                {
                    Id = int.Parse(reg.Get(0)),
                    Nombre = reg.Get(1),
                    Apellido = reg.Get(2),
                    Genero = reg.Get(3),
                    Nacimiento = int.Parse(reg.Get(4)),
                    Email = reg.Get(5),
                    Telefono = reg.Get(6),
                    Password = reg.Get(7),
                    Admin = bool.Parse(reg.Get(8)),
                    Activo = bool.Parse(reg.Get(9))
                };
            }
            return usu;
        }

        private static Funcion crearFuncion(Registro reg)
        {
            Funcion fun = null;
            if (reg != null)
            {
                fun = new Funcion
                {
                    Id = int.Parse(reg.Get(0)),
                    Pelicula = int.Parse(reg.Get(1)),
                    Sala = int.Parse(reg.Get(2)),
                    Fecha = int.Parse(reg.Get(3)),
                    Hora = int.Parse(reg.Get(4))
                };
            }
            return fun;
        }
        private static Reservada crearReservada(Registro reg)
        {
            Reservada res = null;
            if (reg != null)
            {
                res = new Reservada
                {
                    Reserva = int.Parse(reg.Get(0)),
                    Fila = int.Parse(reg.Get(1)),
                    Butaca = int.Parse(reg.Get(2))
                };
            }
            return res;
        }
        private static Sala crearSala(Registro reg)
        {
            Sala res = null;
            if (reg != null)
            {
                res = new Sala
                {
                    Id = int.Parse(reg.Get(0)),
                    Nombre = reg.Get(1),
                    Sucursal = int.Parse(reg.Get(2)),
                    Filas = int.Parse(reg.Get(3)),
                    Butacas = int.Parse(reg.Get(4))
                };
            }
            return res;
        }

        private static Precio crearPrecio(Registro reg)
        {
            Precio res = null;
            if (reg != null)
            {
                res = new Precio(bool.Parse(reg.Get(0)), float.Parse(reg.Get(1)));
            }
            return res;
        }
        private static Sucursal crearSucursal(Registro reg)
        {
            Sucursal res = null;
            if (reg != null)
            {
                res = new Sucursal
                {
                    Id = int.Parse(reg.Get(0)),
                    Nombre = reg.Get(1),
                    Direccion = reg.Get(2)
                };
            }
            return res;
        }

        private static Genero crearGenero(Registro reg)
        {
            Genero gen = null;
            if (reg != null)
            {
                gen = new Genero
                {
                    Id = int.Parse(reg.Get(0)),
                    Nombre = reg.Get(1)
                };
            }
            return gen;
        }

        private static Calificacion crearCalificacion(Registro reg)
        {
            Calificacion cal = null;
            if (reg != null)
            {
                cal = new Calificacion
                {
                    Id = int.Parse(reg.Get(0)),
                    Nombre = reg.Get(1)
                };
            }
            return cal;
        }

        private static Tarjeta crearTarjeta(Registro reg)
        {
            Tarjeta tar = null;
            if (reg != null)
            {
                tar = new Tarjeta
                {
                    IdUsuario = int.Parse(reg.Get(0)),
                    NumTarjeta = long.Parse(reg.Get(1)),
                    MesVencimiento = int.Parse(reg.Get(2)),
                    AnioVencimiento = int.Parse(reg.Get(3)),
                    CodSeguridad = int.Parse(reg.Get(4)),
                    DniTitular = int.Parse(reg.Get(5)),
                    NombreTitular = reg.Get(6)
                };
            }
            return tar;
        }

        private static Usuario ModificarDatosUsuario(Registro reg)
        {
            Usuario user = null;
            if (reg != null)
            {
                user = new Usuario
                {
                    Nombre = reg.Get(0),
                    Apellido = reg.Get(1),
                    Telefono = reg.Get(2),
                    Nacimiento = int.Parse(reg.Get(3))
                };
            }
            return user;
        }

        public static Calificacion ObtenerCalificacion(int id)
        {
            return crearCalificacion(DatosCine.ObtenerCalificacion(id));
        }

        public static Genero ObtenerGenero(int id)
        {
            return crearGenero(DatosCine.ObtenerGenero(id));
        }

        public static Pelicula ObtenerPelicula(int id)
        {
            return crearPelicula(DatosCine.ObtenerPelicula(id));
        }

        public static Sucursal ObtenerSucursal(int id)
        {
            return crearSucursal(DatosCine.ObtenerSucursal(id));
        }

        public static Sala ObtenerSala(int id)
        {
            return crearSala(DatosCine.ObtenerSala(id));
        }

        public static Precio ObtenerPrecio(bool formato3d)
        {
            return crearPrecio(DatosCine.ObtenerPrecio(formato3d));
        }

        public static List<Sucursal> ObtenerSucursales()
        {
            List<Sucursal> resultado = new List<Sucursal>();

            foreach (Registro registro in DatosCine.ObtenerSucursales())
            {
                resultado.Add(crearSucursal(registro));
            }
            return resultado;
        }

        public static List<Genero> ObtenerGeneros()
        {
            List<Genero> resultado = new List<Genero>();

            foreach (Registro registro in DatosCine.ObtenerGeneros())
            {
                resultado.Add(crearGenero(registro));
            }

            return resultado;
        }

        public static List<Genero> ObtenerGenerosActivos()
        {
            List<Genero> resultado = new List<Genero>();

            foreach (Registro registro in DatosCine.ObtenerGenerosActivos())
            {
                resultado.Add(crearGenero(registro));
            }

            return resultado;
        }

        public static List<Calificacion> ObtenerCalificaciones()
        {
            List<Calificacion> resultado = new List<Calificacion>();

            foreach (Registro registro in DatosCine.ObtenerCalificaciones())
            {
                resultado.Add(crearCalificacion(registro));
            }

            return resultado;
        }
        public static List<Calificacion> ObtenerCalificacionesActivas()
        {
            List<Calificacion> resultado = new List<Calificacion>();

            foreach (Registro registro in DatosCine.ObtenerCalificacionesActivas())
            {
                resultado.Add(crearCalificacion(registro));
            }

            return resultado;
        }

        public static List<Pelicula> ObtenerPeliculas()
        {
            List<Pelicula> resultado = new List<Pelicula>();

            foreach (Registro registro in DatosCine.ObtenerPeliculas())
            {
                resultado.Add(crearPelicula(registro));
            }

            return resultado;
        }

        public static List<Pelicula> ObtenerPeliculasActivas()
        {
            List<Pelicula> resultado = new List<Pelicula>();

            foreach (Registro registro in DatosCine.ObtenerPeliculasActivas())
            {
                resultado.Add(crearPelicula(registro));
            }

            return resultado;
        }

        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> resultado = new List<Usuario>();

            foreach (Registro registro in DatosCine.ObtenerUsuarios())
            {
                resultado.Add(crearUsuario(registro));
            }
            return resultado;
        }

        public static List<Sala> ObtenerSalas()
        {
            List<Sala> resultado = new List<Sala>();

            foreach (Registro registro in DatosCine.ObtenerSalas())
            {
                resultado.Add(crearSala(registro));
            }
            return resultado;
        }

        public static List<Pelicula> ObtenerPeliculasPorFormato(bool formato3D) {
            List<Pelicula> peliculas = null;
            List<Registro> registros = DatosCine.ObtenerPeliculasPorFormato(formato3D);
            if (registros != null)
            {
                peliculas = new List<Pelicula>();
                foreach (Registro reg in registros)
                {
                    peliculas.Add(crearPelicula(reg));
                }
            }
            return peliculas;
        }

        public static Usuario ObtenerUsuario(string email)
        {
            Usuario usu = null;
            Registro reg = DatosCine.ObtenerUsuario(email);
            if (reg != null)
            {
                usu = new Usuario
                {
                    Id = int.Parse(reg.Get(0)),
                    Nombre = reg.Get(1),
                    Apellido = reg.Get(2),
                    Genero = reg.Get(3),
                    Nacimiento = int.Parse(reg.Get(4)),
                    Email = reg.Get(5),
                    Telefono = reg.Get(6),
                    Password = reg.Get(7),
                    Admin = bool.Parse(reg.Get(8)),
                    Dni = int.Parse(reg.Get(10))
                };
            }
            return usu;
        }

        public static Pelicula ObtenerPeliculaMod(int id)
        {
            Pelicula peli = null;
            Registro reg = DatosCine.ObtenerPeliculasMod(id);
            if (reg != null)
            {
                peli = new Pelicula
                {
                    Id = int.Parse(reg.Get(0)),
                    Nombre = reg.Get(1),
                    Imagen = reg.Get(2),
                    Calificacion = int.Parse(reg.Get(3)),
                    Formato3D = bool.Parse(reg.Get(4)),
                    Duracion = int.Parse(reg.Get(5)),
                    Genero = int.Parse(reg.Get(6)),
                    Sinopsis = reg.Get(7),
                    Activa = bool.Parse(reg.Get(8))
                };
            }
            return peli;
        }

        public static Usuario ObtenerUsuariosMod(int id)
        {
            Usuario usu = null;
            Registro reg = DatosCine.ObtenerUsuariosMod(id);

            if (reg != null)
            {
                usu = new Usuario
                {
                    Id = int.Parse(reg.Get(0)),
                    Nombre = reg.Get(1),
                    Apellido = reg.Get(2),
                    Genero = reg.Get(3),
                    Nacimiento = int.Parse(reg.Get(4)),
                    Email = reg.Get(5),
                    Telefono = reg.Get(6),
                    Password = reg.Get(7),
                    Admin = bool.Parse(reg.Get(8)),
                    Activo = bool.Parse(reg.Get(9)),
                    Dni = int.Parse(reg.Get(10))
                };
            }
            return usu;
        }

        public static Tarjeta ObtenerTarjetaMostrar(int idUsuario, long numTarjeta)
        {
            Tarjeta tar = null;
            Registro reg = DatosCine.ObtenerTarjetasMostrar(idUsuario, numTarjeta);
            if (reg != null)
            {
                tar = new Tarjeta
                {
                    IdUsuario = int.Parse(reg.Get(0)),
                    NumTarjeta = long.Parse(reg.Get(1)),
                    MesVencimiento = int.Parse(reg.Get(2)),
                    AnioVencimiento = int.Parse(reg.Get(3)),
                    CodSeguridad = int.Parse(reg.Get(4)),
                    DniTitular = int.Parse(reg.Get(5)),
                    NombreTitular = reg.Get(6)
                };
            }
            return tar;
        }

        public static Calificacion ObtenerCalificacionMod(int id)
        {
            Calificacion cali = null;
            Registro reg = DatosCine.ObtenerCalificacionesMod(id);
            if (reg != null)
            {
                cali = new Calificacion
                {
                    Id = int.Parse(reg.Get(0)),
                    Nombre = reg.Get(1),
                    Activo = bool.Parse(reg.Get(2))
                };
            }
            return cali;
        }

        public static Genero ObtenerGeneroMod(int id)
        {
            Genero gen = null;
            Registro reg = DatosCine.ObtenerGeneroMod(id);
            if (reg != null)
            {
                gen = new Genero
                {
                    Id = int.Parse(reg.Get(0)),
                    Nombre = reg.Get(1),
                    Activo = bool.Parse(reg.Get(2)),
                };
            }
            return gen;
        }

        public static int AgregarReserva(int usuario, int funcion)
        {
            return DatosCine.AgregarReserva(usuario, funcion);
        }

        public static bool ModificarDatosUser(string nombre, string apellido,int dni, string telefono ,int nacimiento, string email)
        {
            return DatosCine.ModificarDatosUsuario(nombre, apellido, dni, telefono, nacimiento, email);
        }

        public static bool ModificarPelicula(int id, string nombre, string imagen, int calificacion, bool formato3d, int duracion, int genero, string sinopsis, bool activa)
        {
            return DatosCine.ModificarPelicula(id, nombre, imagen, calificacion, formato3d, duracion, genero, sinopsis, activa);    
        }

        public static bool ModificarUsuario(int id, string nombre, string apellido, int dni, string genero, int nacimiento, string email, string telefono, string password, bool admin, bool activo)
        {
            return DatosCine.ModificarUsuario(id, nombre, apellido, dni, genero, nacimiento, email, telefono, password, admin, activo);
        }


        public static bool ModificarCalificacion(int id, string nombre, bool activo)
        {
            return DatosCine.ModificarCalificacion(id, nombre, activo);
        }

        public static bool ModificarGenero(int id, string nombre, bool activo)
        {
            return DatosCine.ModificarGenero(id,nombre, activo);
        }

        public static bool ModificarPrecio(bool Formato3D, double Precio)
        {
            return DatosCine.ModificarPrecio(Formato3D, Precio);
        }

        public static bool AgregarReservada(int reserva, int fila, int butaca)
        {
            return DatosCine.AgregarReservada(reserva, fila, butaca);
        }

        public static bool AgregarFuncion(int pelicula, int sala, int fecha, int hora)
        {
            return DatosCine.AgregarFuncion(pelicula, sala, fecha, hora);
        }

        public static bool AgregarGenero(string nombre, bool activo)
        {
            return DatosCine.AgregarGenero(nombre, activo);
        }

        public static bool AgregarClasificacion(string nombre, bool activo)
        {
            return DatosCine.AgregarClasificacion(nombre, activo);
        }

        public static bool AgregarUsuario(string nombre, string apellido, int dni, string genero, int nacimiento, string email, string telefono, string password, bool admin, bool activo)
        {
            return DatosCine.AgregarUsuario(nombre, apellido, dni, genero, nacimiento, email, telefono, password, admin, activo);
        }

        public static bool AgregarTarjeta(int IdUsuario, long NumTarjeta, int MesVencimiento, int AnioVencimiento, int CodSeguridad, int DniTitular, string NombreTitular)
        {
            return DatosCine.AgregarTarjetas(IdUsuario, NumTarjeta, MesVencimiento, AnioVencimiento, CodSeguridad, DniTitular, NombreTitular);
        }

        public static bool AgregarPelicula(string nombre, string imagen, int clasificacion, bool formato3d, int duracion, int genero, string sinopsis, bool activo)
        {
            return DatosCine.AgregarPelicula(nombre, imagen, clasificacion, formato3d, duracion, genero, sinopsis, activo);
        }

        public static Usuario VerificarUsuario(string usuario, string pass)
        {
            Usuario usu = null;
            Registro reg = DatosCine.VerificarUsuario(usuario, pass);
            if (reg != null)
            {
                usu = new Usuario
                {
                    Id = int.Parse(reg.Get(0)),
                    Nombre = reg.Get(1),
                    Apellido = reg.Get(2),
                    Genero = reg.Get(3),
                    Nacimiento = int.Parse(reg.Get(4)),
                    Email = reg.Get(5),
                    Telefono = reg.Get(6),
                    Password = reg.Get(7),
                    Admin = bool.Parse(reg.Get(8)),
                    Activo = bool.Parse(reg.Get(9)),
                    Dni = int.Parse(reg.Get(10))
                };
            }
            return usu;
        }

        public static bool VerificarEmail(string email)
        {
            return DatosCine.ExisteEmail(email);
        }

        public static List<Funcion> ObtenerFunciones(int pelicula, int sucursal)
        {
            List<Funcion> funciones = null;
            List<Registro> registros = DatosCine.ObtenerFunciones(pelicula, sucursal);
            if (registros != null)
            {
                funciones = new List<Funcion>();
                foreach (Registro reg in registros)
                {
                    funciones.Add(crearFuncion(reg));
                }
            }
            return funciones;
        }

        public static List<List<string>> ObtenerReservas(string email)
        {
            List<List<string>> resultado = new List<List<string>>();
            foreach (Registro reg in DatosCine.ObtenerReservas(email)) {
                resultado.Add(reg.Campos);
            }
            return resultado;
        }

        public static List<Funcion> ObtenerFunciones(int pelicula)
        {
            List<Funcion> funciones = null;
            List<Registro> registros = DatosCine.ObtenerFunciones(pelicula);
            if (registros != null)
            {
                funciones = new List<Funcion>();
                foreach (Registro reg in registros)
                {
                    funciones.Add(crearFuncion(reg));
                }
            }
            return funciones;
        }

        public static List<Tarjeta> ObtenerTarjeta(int idUsuario)
        {
            List<Tarjeta> tarjetas = null;
            List<Registro> registros = DatosCine.ObtenerTarjetas(idUsuario);
            if (registros != null)
            {
                tarjetas = new List<Tarjeta>();
                foreach (Registro reg in registros)
                {
                    tarjetas.Add(crearTarjeta(reg));
                }
            }
            return tarjetas;
        }

        public static void Conectar()
        {
            DatosCine.Conectar();
        }
        public static List<Reservada> ButacasReservadas(int funcion)
        {
            List<Reservada> reservadas = null;
            List<Registro> registros = DatosCine.ButacasReservadas(funcion);
            if (registros != null)
            {
                reservadas = new List<Reservada>();
                foreach (Registro reg in registros)
                {
                    reservadas.Add(crearReservada(reg));
                }
            }

            return reservadas;
        }

        public static int VendidasPorFormato(bool formato3D)
        {
            return DatosCine.VendidasPorFormato(formato3D);
        }

        public static int RecaudacionPorFormato(bool formato3D)
        {
            return DatosCine.RecaudacionPorFormato(formato3D);
        }

        public static string PeliculaMasVista(bool formato3D)
        {
            return DatosCine.PeliculaMasVista(formato3D);
        }

        public static int ReportePorPelicula(int id, int desde, int hasta)
        {
            return DatosCine.ReportePorPelicula(id, desde, hasta);
        }

        public static int ReportePorSucursal(int id, int desde, int hasta)
        {
            return DatosCine.ReportePorSucursal(id, desde, hasta);
        }

        public static int ReportePorGenero(int id, int desde, int hasta)
        {
            return DatosCine.ReportePorGenero(id, desde, hasta);
        }

    }
}
