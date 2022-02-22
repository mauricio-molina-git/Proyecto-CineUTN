using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using NEGOCIO;
using ENTIDAD;

namespace PRESENTACION
{
    public partial class PantallaIniciarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }

        protected void btnLogoCine_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx?");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PantallaRegistrar.aspx?");
        }

        protected void btnConectar_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtContraseña.Text != "")
            {
                Usuario usu = NegocioCine.VerificarUsuario(txtEmail.Text, txtContraseña.Text);
                if (usu != null)
                {
                    if (usu.Activo)
                    {
                        Session["Email"] = usu.Email;
                        Session["Admin"] = usu.Admin;
                        Session["idUsuario"] = usu.Id;
                        if (usu.Admin)
                        {
                            Response.Redirect("AdminPrincipal.aspx");
                        }
                        else
                        {
                            Response.Redirect("PantallaPrincipal.aspx");
                        }
                    }
                    else
                    {
                        lblErrorConex.Visible = true;
                        lblErrorConex.Text = "El usuario " + usu.Nombre + " " + usu.Apellido + " no está activo.";
                    }
                }
                else
                {
                    lblErrorConex.Visible = true;
                    btnAceptar.Visible = true;
                    btnIngresar.Visible = false;
                    lblErrorConex.Text = "Credenciales incorrectas";
                }
            }
            else
            {
                lblErrorConex.Visible = true;
                btnAceptar.Visible = true;
                btnIngresar.Visible = false;
                lblErrorConex.Text = "Complete los campos.";
            }
        }

        protected void btnLogoCine_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx");
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx");

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblErrorConex.Visible = false;
            btnAceptar.Visible = false;
            btnIngresar.Visible = true;
        }
    }
}