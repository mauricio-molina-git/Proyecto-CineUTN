using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Calificacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public Calificacion() { }

        public Calificacion(int id, string nombre, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Activo = activo;
        }
    }
}
