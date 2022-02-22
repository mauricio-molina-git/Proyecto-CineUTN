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
    public partial class AdminModificarGenero : System.Web.UI.Page
    {
        private string Nombre;
        private bool Activo;
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

                foreach (Genero g in NegocioCine.ObtenerGeneros())
                {
                    dropGenero.Items.Add(g.Id + " " + g.Nombre);
                }

                string genero = dropGenero.SelectedValue;
                genero = int.Parse(genero.Split(new char[] { ' ' })[0]).ToString();
                Genero gen = NegocioCine.ObtenerGeneroMod(int.Parse(genero));

                chkActivo.Checked = gen.Activo;
                Nombre = txtGenero.Text = gen.Nombre;            
            }
        }

        private void habilitarEdicion(bool habilitado)
        {
            txtGenero.Enabled = habilitado;
            btnCancelar.Visible = habilitado;
            chkActivo.Enabled = habilitado;

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
            Response.Redirect("AdminModificarGenero.aspx");
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
                Nombre = txtGenero.Text;
                Activo = chkActivo.Checked;

                string genero = dropGenero.SelectedValue;
                genero = int.Parse(genero.Split(new char[] { ' ' })[0]).ToString();

                if (NegocioCine.ModificarGenero(int.Parse(genero), txtGenero.Text, chkActivo.Checked))
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Modificado!";
                    btnOk.Visible = true;
                }
                habilitarEdicion(false);
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminModificarGenero.aspx");
        }

        protected void dropGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            string genero = dropGenero.SelectedValue;
            genero = int.Parse(genero.Split(new char[] { ' ' })[0]).ToString();
            Genero gen = NegocioCine.ObtenerGeneroMod(int.Parse(genero));

            chkActivo.Checked = gen.Activo;
            Nombre = txtGenero.Text = gen.Nombre;
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
    }
}