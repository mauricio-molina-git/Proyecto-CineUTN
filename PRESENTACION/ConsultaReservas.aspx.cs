using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDAD;
using NEGOCIO;

namespace PRESENTACION
{
    public partial class ConsultaReservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lstReservas.Items.Clear();
            if (!IsPostBack)
            {
                ddpPerfil.Items.Add("Seleccione opción");
                ddpPerfil.Items.Add("Perfil");
                ddpPerfil.Items.Add("Agregar Tarjetas");
                ddpPerfil.Items.Add("Cerrar Sesión");

                if (Session["Email"] != null)
                {
                    string email = Session["Email"].ToString();
                    List<List<string>> reservas = NegocioCine.ObtenerReservas(email);
                    foreach (List<String> reserva in reservas)
                    {
                        lstReservas.Items.Add(
                        String.Format("Pelicula:{0, 30} Sala:{1, 15} Día: {2, 10} Hora: {3, 6} Fila: {4, 4} Butaca: {5, 4}",
                        reserva[0], reserva[1], Formato.FechaCorta(int.Parse(reserva[2])), reserva[3], reserva[4], reserva[5]));
                    }
                }
            }
            else
            {
                lstReservas.Items.Add("No hay reservas");
            }

            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                Usuario usu = NegocioCine.ObtenerUsuario(email);
                if (usu != null)
                {
                    lblusuario.Text = usu.Nombre + " " + usu.Apellido;
                    ddpPerfil.Visible = true;
                }
            }
            else
            {
                lblusuario.Text = "Sin iniciar sesión";
            }
        }

        protected void btnUsuario_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["Email"] == null)
            {
                Response.Redirect("PantallaIniciarSesion.aspx");
            }
            else
            {
                Response.Redirect("PantallaDatosUsuario.aspx");
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx?");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("PantallaPrincipal.aspx");
        }

        protected void btnLogoCine_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx?");
        }

        protected void btnLogoCine_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx");
        }

        protected void ddpPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddpPerfil.SelectedIndex == 1)
            {
                Response.Redirect("PantallaDatosUsuario.aspx");
            }

            if (ddpPerfil.SelectedIndex == 2)
            {
                Response.Redirect("PantallaTarjeta.aspx");
            }
            if (ddpPerfil.SelectedIndex == 3)
            {
                Session["Email"] = null;
                Response.Redirect("PantallaPrincipal.aspx");
            }
        }

        protected void btnUsuario_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaDatosUsuario.aspx");
        }
    }
}