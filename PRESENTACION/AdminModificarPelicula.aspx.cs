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
    public partial class AdminModificarPelicula : System.Web.UI.Page
    {
        private string Nombre;
        private string Imagen;
        private string Sinopsis;

        int Calificacion;
        bool Formato3D;
        int Duracion;
        int Genero;

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

                foreach (Pelicula p in NegocioCine.ObtenerPeliculas())
                {
                    dropPelicula.Items.Add(p.Id + " " + p.Nombre);
                }

                foreach (Calificacion c in NegocioCine.ObtenerCalificacionesActivas())
                {
                    ddpClasificacion.Items.Add(c.Id + " - " + c.Nombre);
                }

                foreach (Genero g in NegocioCine.ObtenerGenerosActivos())
                {
                    ddpGeneros.Items.Add(g.Id + " - " + g.Nombre);
                }

                string peli = dropPelicula.SelectedValue;
                peli = int.Parse(peli.Split(new char[] { ' ' })[0]).ToString();
                Pelicula pelicula = NegocioCine.ObtenerPeliculaMod(int.Parse(peli));

                Nombre = txtNmbrePelicula.Text = pelicula.Nombre;
                Imagen = txtImagen.Text = pelicula.Imagen;
                Sinopsis = txtSinopsis.Text = pelicula.Sinopsis;

                txtCalificacion.Text = pelicula.Calificacion.ToString();
                chk3D.Checked = pelicula.Formato3D;
                txtDuracion.Text = pelicula.Duracion.ToString();
                txtGenero.Text = pelicula.Genero.ToString();
                FileUpload1.Visible = false;
                chkActiva.Checked = pelicula.Activa;
            }
        }

        private void habilitarEdicion(bool habilitado)
        {
            txtImagen.Enabled = habilitado;
            txtSinopsis.Enabled = habilitado;
            txtCalificacion.Enabled = habilitado;
            txtDuracion.Enabled = habilitado;
            txtGenero.Enabled = habilitado;
            FileUpload1.Visible = habilitado;
            FileUpload1.Enabled = habilitado;
            btnCancelar.Visible = habilitado;
            chk3D.Enabled = habilitado;
            chkActiva.Enabled = habilitado;
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
            Response.Redirect("AdminModificarPelicula.aspx");
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
                if (FileUpload1.PostedFile != null)
                {
                    HttpPostedFile myFile = FileUpload1.PostedFile;
                    if (myFile.ContentLength > 0)
                    {
                        txtImagen.Text = "~/ImagenesPeliculas/" + FileUpload1.PostedFile.FileName;
                    }
                }

                Nombre = txtNmbrePelicula.Text;
                Imagen = txtImagen.Text;
                Sinopsis = txtSinopsis.Text;
                Calificacion = int.Parse(txtCalificacion.Text);
                Duracion = int.Parse(txtDuracion.Text);
                Genero = int.Parse(txtGenero.Text);

                string peli = dropPelicula.SelectedValue;
                peli = int.Parse(peli.Split(new char[] { ' ' })[0]).ToString();

                if(NegocioCine.ModificarPelicula(int.Parse(peli), txtNmbrePelicula.Text,
                    txtImagen.Text, int.Parse(txtCalificacion.Text),
                    chk3D.Checked, int.Parse(txtDuracion.Text),
                    int.Parse(txtGenero.Text), txtSinopsis.Text, chkActiva.Checked))
                {
                    lblMensaje.Text = "Pelicula modificada!";
                    lblMensaje.Visible = true;
                    btnOk.Visible = true;
                }
                else
                {
                    lblMensaje.Visible = true;
                    btnOk.Visible = true;
                    lblMensaje.Text = "Nombre no disponible";
                }

                habilitarEdicion(false);
            }
        }

        protected void dropPelicula_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblReferenciaGenero.Visible = false;
            ddpGeneros.Visible = false;
            btnOcultarRefGen.Visible = false;
            lblReferenciaClasificacion.Visible = false;
            ddpClasificacion.Visible = false;
            btnOcultarRefClas.Visible = false;

            string peli = dropPelicula.SelectedValue;
            peli = int.Parse(peli.Split(new char[] { ' ' })[0]).ToString();
            Pelicula pelicula = NegocioCine.ObtenerPeliculaMod(int.Parse(peli));

            Nombre = txtNmbrePelicula.Text = pelicula.Nombre;
            Imagen = txtImagen.Text = pelicula.Imagen;
            Sinopsis = txtSinopsis.Text = pelicula.Sinopsis;

            txtCalificacion.Text = pelicula.Calificacion.ToString();
            chk3D.Checked = pelicula.Formato3D;
            txtDuracion.Text = pelicula.Duracion.ToString();
            txtGenero.Text = pelicula.Genero.ToString();
            chkActiva.Checked = pelicula.Activa;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminModificarPelicula.aspx");
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

        protected void btnReferenciaClasificacion_Click(object sender, EventArgs e)
        {
            lblReferenciaClasificacion.Visible = true;
            ddpClasificacion.Visible = true;
            btnOcultarRefClas.Visible = true;
        }

        protected void lblOcultarRefClas_Click(object sender, EventArgs e)
        {
            lblReferenciaClasificacion.Visible = false;
            ddpClasificacion.Visible = false;
            btnOcultarRefClas.Visible = false;
        }

        protected void btnReferenciaGen_Click(object sender, EventArgs e)
        {
            ddpGeneros.Visible = true;
            lblReferenciaGenero.Visible = true;
            btnOcultarRefGen.Visible = true;
        }

        protected void btnOcultarRefGen_Click(object sender, EventArgs e)
        {
            lblReferenciaGenero.Visible = false;
            ddpGeneros.Visible = false;
            btnOcultarRefGen.Visible = false;
        }
    }
}