using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public int Calificacion { get; set; }
        public bool Formato3D { get; set; }
        public int Duracion { get; set; }
        public int Genero { get; set; }
        public string Sinopsis { get; set; }
        public bool Activa { get; set; }

        public Pelicula() { }

        public Pelicula(int id, string nombre, string imagen, int calificacion, bool formato3D, int duracion, int genero, string sinopsis, bool activa)
        {
            Id = id;
            Nombre = nombre;
            Imagen = imagen;
            Calificacion = calificacion;
            Formato3D = formato3D;
            this.Duracion = duracion;
            Genero = genero;
            Sinopsis = sinopsis;
            Activa = activa;
        }
    }
}
