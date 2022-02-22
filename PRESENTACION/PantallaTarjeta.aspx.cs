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
    public partial class PantallaTarjeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioCine.Conectar();
                ddpPerfil.Items.Add("Seleccione opción");
                ddpPerfil.Items.Add("Perfil");
                ddpPerfil.Items.Add("Compras realizadas");
                ddpPerfil.Items.Add("Agregar Tarjetas");
                ddpPerfil.Items.Add("Cerrar Sesión");

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
                }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            bool exito;

            DateTime hoy = DateTime.Now;
            int a = hoy.Year;
            int m = hoy.Month;
            int a1 = 0, m1 = 0;

            if(txtAñoVencimiento.Text != string.Empty && txtMesVencimiento.Text != string.Empty)
            {
               a1 =  int.Parse(txtAñoVencimiento.Text);
               m1 =  int.Parse(txtMesVencimiento.Text);
            }

            exito = a1 > a || (a1 == a && m1 > m); 

            exito = exito && txtNombreApellido.Text.Length > 0;
            exito = exito && txtDNI.Text.Length > 0;
            exito = exito && txtCodigo.Text.Length == 3;
            exito = exito && txtNumeroTarjeta.Text.Length == 16;

            if (exito)
            {
                string email = Session["Email"].ToString();
                Usuario usu = NegocioCine.ObtenerUsuario(email);

                if (NegocioCine.AgregarTarjeta(usu.Id, long.Parse(txtNumeroTarjeta.Text),
                                               int.Parse(txtMesVencimiento.Text), int.Parse(txtAñoVencimiento.Text),
                                               int.Parse(txtCodigo.Text), int.Parse(txtDNI.Text), txtNombreApellido.Text))
                {
                    lblMensaje.Visible = true;
                    btnAceptar.Visible = true;
                    lblMensaje.Text = "Tarjeta ingresada correctamente";
                }
                else
                {
                    lblMensaje.Visible = true;
                    btnAceptar.Visible = true;
                    lblMensaje.Text = "Tarjeta ya ingresada";
                }
            }
            else
            {
                lblMensaje.Visible = true;
                btnAceptar.Visible = true;
                lblMensaje.Text = "Revise los datos ingresados.";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
            btnAceptar.Visible = false;
            btnPagar.Visible = true;

        }

        protected void ddpPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddpPerfil.SelectedIndex == 1)
            {
                Response.Redirect("PantallaDatosUsuario.aspx");
            }

            if (ddpPerfil.SelectedIndex == 2)
            {
                Response.Redirect("ConsultaReservas.aspx");
            }

            if (ddpPerfil.SelectedIndex == 3)
            {
                Response.Redirect("PantallaTarjeta.aspx");
            }
            if (ddpPerfil.SelectedIndex == 4)
            {
                Session["Email"] = null;
                Response.Redirect("PantallaPrincipal.aspx");
            }
        }

        protected void btnUsuario_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaDatosUsuario.aspx");
        }
    }
}
