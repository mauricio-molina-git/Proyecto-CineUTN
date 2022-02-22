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
    public partial class PantallaAdminAgregar : System.Web.UI.Page
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

                foreach (Calificacion c in NegocioCine.ObtenerCalificacionesActivas())
                {
                    dropCalificacion.Items.Add(c.Id + " " + c.Nombre);
                }
                foreach (Genero g in NegocioCine.ObtenerGenerosActivos())
                {
                    dropGenero.Items.Add(g.Id + " " + g.Nombre);
                }
            }
        }

        public static bool AgregarPelicula(string Nombre, string Imagen, int Clasificacion, bool Formato3D, int Duracion, int Genero, string Sinopsis, bool activo)
        {
             return NegocioCine.AgregarPelicula(Nombre, Imagen, Clasificacion, Formato3D, Duracion, Genero, Sinopsis, activo);
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            bool exito;
            HttpPostedFile myFile = null;
            string savePath = "";
            try
            {
                exito = FileUpload1.PostedFile != null;
                if (exito)
                {
                    myFile = FileUpload1.PostedFile;
                    savePath = "~/ImagenesPeliculas/" + FileUpload1.PostedFile.FileName;
                    int file_length = myFile.ContentLength;
                    exito = file_length > 0;
                }
                exito = exito && txtNombre.Text.Length > 0;
                exito = exito && txtDuracion.Text.Length > 0;
                exito = exito && txtSinopsis.Text.Length > 0;

                if (exito)
                {
                    string s = dropCalificacion.SelectedValue.ToString();
                    int calif = int.Parse(s.Split(new char[] { ' ' })[0]);

                    s = dropGenero.SelectedValue.ToString();

                    int genero = int.Parse(s.Split(new char[] { ' ' })[0]);
                    if (AgregarPelicula(txtNombre.Text, savePath, calif, CheckBox1.Checked, int.Parse(txtDuracion.Text), genero, txtSinopsis.Text, true))
                    {
                        errormsg.Visible = true;
                        errormsg.Text = "Agregado!";
                        btnOk.Visible = true;
                        btnLimpiar.Visible = true;
                    }
                    else
                    {
                        btnLimpiar.Visible = false;
                        errormsg.Visible = true;
                        btnOk.Visible = true;
                        errormsg.Text = "Esa pelicula ya existe";
                    }
                }
                else
                {
                    errormsg.Visible = true;
                    errormsg.Text = "Formulario incompleto";
                    btnOk.Visible = true;
                }

            }
            catch (Exception ex)
            {
                errormsg.Text += "Error: savePath = " + savePath;
            }

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            errormsg.Visible = false;
            btnOk.Visible = false;
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

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAgregarPelicula.aspx");
        }
    }
}