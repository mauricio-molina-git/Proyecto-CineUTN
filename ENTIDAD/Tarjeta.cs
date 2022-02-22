using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Tarjeta
    {
        public int IdUsuario { get; set; }
        public long NumTarjeta { get; set; }
        public int MesVencimiento { get; set; }
        public int AnioVencimiento { get; set; }
        public int CodSeguridad { get; set; }
        public int DniTitular { get; set; }
        public string NombreTitular { get; set; }


        public Tarjeta() { }

        public Tarjeta(int idusuario, long numtarjeta, int mesvencimiento, int aniovencimiento, int codseguridad, int dnititular, string nombretitular)
        {
            IdUsuario = idusuario;
            NumTarjeta = numtarjeta;
            MesVencimiento = mesvencimiento;
            AnioVencimiento = aniovencimiento;
            CodSeguridad = codseguridad;
            DniTitular = dnititular;
            NombreTitular = nombretitular;
        }
    }
}