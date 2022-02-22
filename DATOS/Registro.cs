using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class Registro
    {
        private List<string> campos;

        public Registro(List<string> campos)
        {
            this.campos = campos ?? new List<string>();
        }

        public Registro()
        {
            this.campos = new List<string>();
        }

        public List<string> Campos
        {
            get
            {
                return campos;
            }
        }

        public void Add(string dato)
        {
            campos.Add(dato);
        }

        public string Get(int i)
        {
            return verificarIndice(i) ? campos[i] : null;
        }

        public void Set(int i, string dato)
        {
            if (verificarIndice(i))
            {
                campos[i] = dato;
            }
        }

        public bool verificarIndice(int i)
        {
            return i >= 0 && i < campos.Count;
        }
    }
}
