using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION
{
    public partial class PantallaPrincipal : System.Web.UI.Page
    {
        static ImageButton[] botones2D = new ImageButton[4];
        static ImageButton[] botones3D = new ImageButton[4];
        static Label[] labels2D = new Label[4];
        static Label[] labels3D = new Label[4];
        static List<Pelicula> peliculas2D = null;
        static List<Pelicula> peliculas3D = null;
        static int cantidad2D;
        static int cantidad3D;
        static int desde2D;
        static int desde3D;

        protected void Page_Load(object sender, EventArgs e)
        {
            iniciarPagina();
            if (!IsPostBack)
            {
                peliculas2D = NegocioCine.ObtenerPeliculasPorFormato(false);
                peliculas3D = NegocioCine.ObtenerPeliculasPorFormato(true);

                ddpPerfil.Items.Add("Seleccione opción");
                ddpPerfil.Items.Add("Perfil");
                ddpPerfil.Items.Add("Compras realizadas");
                ddpPerfil.Items.Add("Agregar Tarjetas");
                ddpPerfil.Items.Add("Cerrar Sesión");

                cantidad2D = peliculas2D.Count;
                cantidad3D = peliculas3D.Count;
                desde2D = desde3D = 0;
                mostrar2D();
                mostrar3D();
            }

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
            else
            {
                lblusuario.Text = "Sin iniciar sesión";
            }
        }

        private void iniciarPagina()
        {
            //2D
            botones2D[0] = ImageButton1;
            botones2D[1] = ImageButton2;
            botones2D[2] = ImageButton3;
            botones2D[3] = ImageButton4;
            //3D
            botones3D[0] = ImageButton13D;
            botones3D[1] = ImageButton23D;
            botones3D[2] = ImageButton33D;
            botones3D[3] = ImageButton43D;
            //2D
            labels2D[0] = Label1;
            labels2D[1] = Label2;
            labels2D[2] = Label3;
            labels2D[3] = Label4;
            //3D
            labels3D[0] = Label5;
            labels3D[1] = Label6;
            labels3D[2] = Label7;
            labels3D[3] = Label8;
            NegocioCine.Conectar();
        }

        private void mostrar2D() 
        {
            habilitarBotones2D();
            int d = desde2D;
            int i;
            for (i = 0; i < 4 && d < cantidad2D; i++)
            {
                labels2D[i].Visible = true;
                botones2D[i].Visible = true;
                labels2D[i].Text = peliculas2D[d].Nombre;
                botones2D[i].ImageUrl = peliculas2D[d].Imagen;
                d++;
            }

            while(i < 4) {
                labels2D[i].Visible = false;
                botones2D[i].Visible = false;
                i++;
            }
            btnAnterior2D.Enabled = desde2D > 0;
            btnSiguiente2D.Enabled = desde2D + 4 < cantidad2D;
        }

        private void mostrar3D()
        {
            habilitarBotones3D();
            int d = desde3D;
            int i;
            for (i = 0; i < 4 && d < cantidad3D; i++)
            {
                labels3D[i].Visible = true;
                botones3D[i].Visible = true;
                labels3D[i].Text = peliculas3D[d].Nombre;
                botones3D[i].ImageUrl = peliculas3D[d].Imagen;
                d++;
            }

            while (i < 4)
            {
                labels3D[i].Visible = false;
                botones3D[i].Visible = false;
                i++;
            }
            btnAnterior3D.Enabled = desde3D > 0;
            btnSiguiente3D.Enabled = desde3D + 4 < cantidad3D;
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            desde2D -= 4;
            mostrar2D();
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            desde2D += 4;
            mostrar2D();
        }

        protected void btnAnterior3D_Click(object sender, EventArgs e)
        {
            desde3D -= 4;
            mostrar3D();
        }

        protected void btnSiguiente3D_Click(object sender, EventArgs e)
        {
            desde3D += 4;
            mostrar3D();
        }

        //2D
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["idPelicula"] = peliculas2D[desde2D + 0].Id;
            Response.Redirect("PantallaDetallesPeliculas.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Session["idPelicula"] = peliculas2D[desde2D + 1].Id;
            Response.Redirect("PantallaDetallesPeliculas.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Session["idPelicula"] = peliculas2D[desde2D + 2].Id;
            Response.Redirect("PantallaDetallesPeliculas.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Session["idPelicula"] = peliculas2D[desde2D + 3].Id;
            Response.Redirect("PantallaDetallesPeliculas.aspx");
        }

        //3D
        protected void ImageButton13D_Click(object sender, ImageClickEventArgs e)
        {
            Session["idPelicula"] = peliculas3D[desde3D + 0].Id;
            Response.Redirect("PantallaDetallesPeliculas.aspx");
        }

        protected void ImageButton23D_Click(object sender, ImageClickEventArgs e)
        {
            Session["idPelicula"] = peliculas3D[desde3D + 1].Id;
            Response.Redirect("PantallaDetallesPeliculas.aspx");
        }

        protected void ImageButton33D_Click(object sender, ImageClickEventArgs e)
        {
            Session["idPelicula"] = peliculas3D[desde3D + 2].Id;
            Response.Redirect("PantallaDetallesPeliculas.aspx");
        }

        protected void ImageButton43D_Click(object sender, ImageClickEventArgs e)
        {
            Session["idPelicula"] = peliculas3D[desde3D + 3].Id;
            Response.Redirect("PantallaDetallesPeliculas.aspx");
        }

        private void habilitarBotones2D()
        {
            for (int i = 0; i < 4; i++)
            {
                botones2D[i].BackColor = Color.White;
                botones2D[i].Enabled = true;
            }
        }

        private void habilitarBotones3D()
        {
            for (int i = 0; i < 4; i++)
            {
                botones3D[i].BackColor = Color.White;
                botones3D[i].Enabled = true;
            }
        }

        protected void btnUsuario_Click(object sender, ImageClickEventArgs e)
        {
            if(Session["Email"] == null)
            {
                Response.Redirect("PantallaIniciarSesion.aspx");
            } 
            else 
            {
                Response.Redirect("PantallaDatosUsuario.aspx");
            }
        }

        protected void btnLinkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("PantallaPrincipal.aspx");
        }

        protected void btnVerReservas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaReservas.aspx");
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
    }
}