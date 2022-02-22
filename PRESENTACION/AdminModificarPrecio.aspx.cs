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
    public partial class AdminModificarPrecio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["Email"].ToString();
            Usuario usu = NegocioCine.ObtenerUsuario(email);

            if (usu != null)
            {
                lblUsuario.Text = usu.Nombre + " " + usu.Apellido;
                btnLinkCerrarSesion.Visible = true;
            }

            if (!IsPostBack)
            {
                NegocioCine.Conectar();
                Precio precio = NegocioCine.ObtenerPrecio(chkFormato.Checked);
                txtPrecio.Text = precio.Importe.ToString(); 
            }
        }

        private void habilitarEdicion(bool habilitado)
        {
            txtPrecio.Enabled = habilitado;
            btnCancelar.Visible = habilitado;
            chkFormato.Enabled = Visible;

            if (habilitado)
            {
                btnEditar.Text = "Aceptar";
            }
            else
            {
                btnEditar.Text = "Editar";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminModificarPrecio.aspx");
            habilitarEdicion(false);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Text == "Editar")
            {
                habilitarEdicion(true);
            }
            else
            {
                if (NegocioCine.ModificarPrecio(chkFormato.Checked, double.Parse(txtPrecio.Text)))
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Modificado!";
                    btnOk.Visible = true;
                }
                habilitarEdicion(false);
            }
        }

        protected void chkFormato_CheckedChanged(object sender, EventArgs e)
        {
            Precio precio = NegocioCine.ObtenerPrecio(chkFormato.Checked);
            txtPrecio.Text = precio.Importe.ToString();
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

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminModificarPrecio.aspx");
        }
    }
}