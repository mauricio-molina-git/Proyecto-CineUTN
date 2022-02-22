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
    public partial class AdminAgregarGenero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMje.Text = "";
            NegocioCine.Conectar();
            string email = Session["Email"].ToString();
            Usuario usu = NegocioCine.ObtenerUsuario(email);
            if (usu != null)
            {
                lblUsuario.Text = usu.Nombre + " " + usu.Apellido;
                btnLinkCerrarSesion.Visible = true;
            }
        }

        public static bool AgregarGenero(string nombre, bool activo)
        {
            return NegocioCine.AgregarGenero(nombre, activo);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtGenero.Text != "")
            {
                if (AgregarGenero(txtGenero.Text, true))
                {
                    lblMje.Visible = true;
                    lblMje.Text = "Genero agregado!";
                    btnAgregar.Visible = false;
                    btnResetear.Visible = false;
                    btnOk.Visible = true;
                }
                else
                {
                    lblMje.Visible = true;
                    lblMje.Text = "Genero ya existente.";
                    btnOk.Visible = true;
                    btnAgregar.Visible = false;
                    btnResetear.Visible = false;
                }
            }
            else
            {
                lblMje.Visible = true;
                lblMje.Text = "Formulario incompleto.";
                btnOk.Visible = true;
                btnResetear.Visible = false;
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            lblMje.Visible = false;
            btnOk.Visible =  false;
            txtGenero.Text = string.Empty;
            btnAgregar.Visible = true;
            btnResetear.Visible = true;
        }

        protected void btnLinkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("PantallaIniciarSesion.aspx");
        }

        protected void btnPrincipal_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AdminPrincipal.aspx");
        }

        protected void btnResetear_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAgregarGenero.aspx");
        }
    }
}