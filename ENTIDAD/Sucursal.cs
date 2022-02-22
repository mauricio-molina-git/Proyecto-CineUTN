using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public Sucursal() { }

        public Sucursal(int id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
        }
    }
}
