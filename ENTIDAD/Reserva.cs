using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Reserva
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public int Funcion { get; set; }

        public Reserva() { }

        public Reserva(int id, int usuario, int funcion, int fila, int butaca)
        {
            Id = id;
            Usuario = usuario;
            Funcion = funcion;
        }
    }
}
