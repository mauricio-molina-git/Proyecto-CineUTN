using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Reservada
    {
        public int Reserva { get; set; }
        public int Fila { get; set; }
        public int Butaca { get; set; }

        public Reservada() { }

        public Reservada(int reserva, int fila, int butaca)
        {
            Reserva = reserva;
            Fila = fila;
            Butaca = butaca;
        }
    }
}
