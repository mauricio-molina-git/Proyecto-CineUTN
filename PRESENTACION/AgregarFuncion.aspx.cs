using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;
using ENTIDAD;

namespace PRESENTACION
{
    public partial class AgregarFuncion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioCine.Conectar();

            foreach (Pelicula p in NegocioCine.ObtenerPeliculas())
            {
                //  dropPelicula.Items.Clear();
                dropPelicula.Items.Add(p.Id + " " + p.Nombre);
            }

            foreach (Sala s in NegocioCine.ObtenerSalas())
            {
                //  dropSala.Items.Clear();
                dropSala.Items.Add(s.Id + " " + s.Nombre);
            }
        }
        public static bool AgregarFuncion(int Pelicula, int Sala, int Fecha, int Hora)
        {
            return NegocioCine.AgregarFuncion(Pelicula, Sala, Fecha, Hora);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool exito;

            exito = txtFecha.Text.Length > 0;
            exito = exito && txtHora.Text.Length > 0;

            if (exito)
            {
                string p = dropPelicula.SelectedValue.ToString();
                int pelicula = int.Parse(p.Split(new char[] { ' ' })[0]);

                p = dropSala.SelectedValue.ToString();

                int sala = int.Parse(p.Split(new char[] { ' ' })[0]);

                AgregarFuncion(pelicula, sala, int.Parse(txtFecha.Text), int.Parse(txtHora.Text));
            }
            else
            {
                //errormsg.Text += "Error: Debe completar todos los datos";
            }
        }
    }
}