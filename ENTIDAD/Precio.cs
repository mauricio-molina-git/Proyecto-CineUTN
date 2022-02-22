using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Precio
    {
        public bool Formato3D { get; set; }
        public float Importe { get; set; }

        public Precio(bool formato3d, float precio) {
            Formato3D = formato3d;
            Importe = precio;
        }
    }
}
