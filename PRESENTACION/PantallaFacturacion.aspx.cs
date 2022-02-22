using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION
{
    public partial class PantallaFacturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario usu = NegocioCine.ObtenerUsuario(Session["Email"].ToString());
                lblMostrarUsuario.Text = usu.Nombre + " " + usu.Apellido;

                Pelicula peli = NegocioCine.ObtenerPelicula(int.Parse(Session["idPelicula"].ToString()));
                lblMostrarFuncion.Text = peli.Nombre;
                lblMostrarFecha.Text = Session["Fecha"].ToString() + " , " + Session["Hora"].ToString();
                lblMostrarSucursal.Text = Session["Sucursal"].ToString().Split(':')[1];
                lblMostrarDireccion.Text = Session["Direccion"].ToString().Split(':')[1];
                if (peli.Formato3D)
                {
                    lblMostrarFormato.Text = "3D";
                }
                else
                {
                    lblMostrarFormato.Text = "2D";
                }
                DetalleReserva();
            }
        }

        private void DetalleReserva()
        {
            string reservas = Session["ButacasReservadas"].ToString();
            string[] butacas = reservas.Split(new char[] {' '});
            lblMostrarButacas.Text = "";
            foreach (string s in butacas)
            {
                int v = int.Parse(s);
                int fila = (v - 1) / 10 + 1;
                int butaca = (v - 1) % 10 + 1;
                lblMostrarButacas.Text += "Fila: " + fila + " Butaca: " + butaca + "\n";
            }
            int cant = butacas.Length;
            double precio = double.Parse(Session["Precio"].ToString());
            lblMostrarEntradas.Text += cant.ToString();
            lblMostrarTotal.Text += (cant * precio).ToString();
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Usuario usu = NegocioCine.ObtenerUsuario(Session["Email"].ToString());
            Session["ID"] = usu.Id;
            Session["Dni"] = usu.Dni;
            Response.Redirect("PantallaPagar.aspx");
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaButacas.aspx");
        }

        protected void btnLogoCine_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx");
        }
    }
}