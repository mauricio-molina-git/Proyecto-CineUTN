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
    public partial class AdminPrincipal : System.Web.UI.Page
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
        }

        protected void btnLinkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("PantallaIniciarSesion.aspx");
        }

        protected void btnAgregarPelicula_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAgregarPelicula.aspx");
        }

        protected void btnAgregarFuncion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAgregarFuncion.aspx");
        }

        protected void btnAgregarGenero_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAgregarGenero.aspx");
        }

        protected void btnAgregarClasificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAgregarClasificacion.aspx");
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAgregarUsuario.aspx");
        }

        protected void btnModificarPelicula_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminModificarPelicula.aspx");
        }

        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminModificarUsuario.aspx");
        }

        protected void btnModificarGenero_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminModificarGenero.aspx");
        }

        protected void btnModificarClasificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminModificarClasificacion.aspx");
        }

        protected void btnReportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }

        protected void btnModificarPrecio_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminModificarPrecio.aspx");
        }
    }
}