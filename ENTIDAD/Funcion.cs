using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Funcion
    {
        public int Id { get; set; }
        public int Pelicula { get; set; }
        public int Sala { get; set; }
        public int Fecha { get; set; }
        public int Hora { get; set; }

        public Funcion() { }

        public Funcion(int id, int pelicula, int sala, int fecha, int hora)
        {
            Id = id;
            Pelicula = pelicula;
            Sala = sala;
            Fecha = fecha;
            Hora = hora;
        }
    }
}
