using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PRESENTACION
{
    public class Formato
    {
        private static string[] mes = { "ene", "feb", "mar", "abr", "may", "jun", "jul", "ago", "sep", "oct", "nov", "dic" };

        public static string FechaCorta(int fecha)
        {
            int d = fecha % 100;
            int m = (fecha / 100) % 100;
            int a = fecha / 10000;
            return string.Format("{0, 2}/{1, 2:00}/{2, 4}", d, m, a);
        }
        public static string FechaLarga(int fecha)
        {
            int d = fecha % 100;
            int m = (fecha / 100) % 100;
            int a = fecha / 10000;
            return string.Format("{0, 2} {1, 3} {2, 4}", d, mes[m-1], a);
        }

        public static string Hora(int hora)
        {
            int m = hora % 100;
            int h = hora / 100;
            return string.Format("{0, 2}:{1, 2:00}", h, m);
        }

        public static void CargarMeses(DropDownList lista)
        {
            int m = 1;
            foreach (string s in mes)
            {
                lista.Items.Add(m++ + " " + s);
            }
        }

        public static void CargarDias(DropDownList lista)
        {
            for (int d = 1; d <= 31; d++ )
            {
                lista.Items.Add(d.ToString());
            }
        }

        public static void CargarAnios(DropDownList lista)
        {
            int hoy = 2020; // buscar función para  obtener año actual
            int a = hoy - 100;
            while(hoy >= a)
            {
                lista.Items.Add(hoy.ToString());
                hoy--;
            }
        }

        private static bool esBisiesto(int a)
        {
            return a % 4 == 0 && (a % 100 != 0 || a % 400 == 0);
        }

        public static bool fechaCorrecta(int d, int m, int a) {
            bool ok = d >= 1 && d <= 31 && m >= 1 && m <= 12 && a != 0;
            if(ok && d > 28) {
                switch (m)
                {
                    case 4:
                    case 6: 
                    case 9:
                    case 11:
                        ok = d < 31;
                        break;
                    case 2:
                        ok = d < 29 || (esBisiesto(a) && d < 30);
                        break;
                }
            }
            return ok;
        }
    }
}