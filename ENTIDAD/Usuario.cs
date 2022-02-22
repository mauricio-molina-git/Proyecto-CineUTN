using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Genero { get; set; }
        public int Nacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public bool Activo { get; set; }
        public int Dni { get; set; }


        public Usuario() { }

        public Usuario(int id, string nombre, string apellido, string genero, int nacimiento, string email, string telefono, string password, bool admin, bool activo, int dni)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Genero = genero;
            Nacimiento = nacimiento;
            Email = email;
            Telefono = telefono;
            Password = password;
            Admin = admin;
            Activo = activo;
            Dni = dni;
        }
    }
}
