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
    public partial class AdminModificarClasificacion : System.Web.UI.Page
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

                foreach (Calificacion c in NegocioCine.ObtenerCalificaciones())
                {
                    dropCalificacion.Items.Add(c.Id + " " + c.Nombre);
                }

                string calificacion = dropCalificacion.SelectedValue;
                calificacion = int.Parse(calificacion.Split(new char[] { ' ' })[0]).ToString();
                Calificacion cali = NegocioCine.ObtenerCalificacionMod(int.Parse(calificacion));

                Activo = chkActivo.Checked;
                Nombre = txtCalificacion.Text = cali.Nombre;
                chkActivo.Checked = cali.Activo;
            }
        }

        private void habilitarEdicion(bool habilitado)
        {
            txtCalificacion.Enabled = habilitado;
            chkActivo.Enabled = habilitado;

            btnCancelar.Visible = habilitado;

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
            Response.Redirect("AdminModificarClasificacion.aspx");
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
                Nombre = txtCalificacion.Text;
                Activo = chkActivo.Checked;

                string calificacion = dropCalificacion.SelectedValue;
                calificacion = int.Parse(calificacion.Split(new char[] { ' ' })[0]).ToString();

                if(NegocioCine.ModificarCalificacion(int.Parse(calificacion),txtCalificacion.Text, chkActivo.Checked))
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Modificado!";
                    btnOk.Visible = true;
                }
                habilitarEdicion(false);
            }
        }

        protected void dropCalificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string calificacion = dropCalificacion.SelectedValue;
            calificacion = int.Parse(calificacion.Split(new char[] { ' ' })[0]).ToString();
            Calificacion cali = NegocioCine.ObtenerCalificacionMod(int.Parse(calificacion));

            Nombre = txtCalificacion.Text = cali.Nombre;
            chkActivo.Checked = cali.Activo;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminModificarClasificacion.aspx");
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