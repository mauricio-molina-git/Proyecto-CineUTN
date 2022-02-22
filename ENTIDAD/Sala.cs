using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Sucursal { get; set; }
        public int Filas { get; set; }
        public int Butacas { get; set; }

        public Sala() { }

        public Sala(int id, string nombre, int sucursal, int fila, int butaca)
        {
            Id = id;
            Nombre = nombre;
            Sucursal = sucursal;
            Filas = fila;
            Butacas = butaca;
        }
    }
}
