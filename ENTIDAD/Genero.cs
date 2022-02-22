using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
   public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public bool Activo { get; set; }
        public Genero() { }

        public Genero(int id, string nombre, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Activo = activo;
        }
    }
}
