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
    public partial class AdminAgregarClasificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioCine.Conectar();
            lblMje.Text = "";

            string email = Session["Email"].ToString();
            Usuario usu = NegocioCine.ObtenerUsuario(email);
            if (usu != null)
            {
                lblUsuario.Text = usu.Nombre + " " + usu.Apellido;
                btnLinkCerrarSesion.Visible = true;
            }
        }

        public static bool AgregarClasificacion(string nombre, bool activo)
        {
            return NegocioCine.AgregarClasificacion(nombre, activo);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtClasificacion.Text != "")
            {
                if (AgregarClasificacion(txtClasificacion.Text, true))
                {
                    lblMje.Visible = true;
                    lblMje.Text = "Clasificación agregada";
                    txtOk.Visible = true;
                    btnResetear.Visible = false;
                }
                else
                {
                    lblMje.Visible = true;
                    lblMje.Text = "Clasificación ya existente";
                    txtOk.Visible = true;
                    btnResetear.Visible = false;
                }
            }
            else
            {
                lblMje.Visible = true;
                lblMje.Text = "Formulario incompleto";
                txtOk.Visible = true;
            }
        }

        protected void txtOk_Click(object sender, EventArgs e)
        {
            lblMje.Visible = false;
            txtOk.Visible = false;
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
            Response.Redirect("AdminAgregarClasificacion.aspx");
        }
    }
}