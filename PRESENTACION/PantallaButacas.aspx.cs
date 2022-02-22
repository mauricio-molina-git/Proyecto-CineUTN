using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;
using ENTIDAD;
using System.Drawing;

namespace PRESENTACION
{
    public partial class PantallaButacas : System.Web.UI.Page
    {
        private static List<Funcion> funciones = null;
        private static List<int> vistas;
        private static ImageButton[] butacas = new ImageButton[80];
        private static int indiceFuncion;
        private static int cantFunciones;
        private static int idPelicula;
        private static int idSucursal;


        private List<Reservada> reservadas = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            iniciarPagina();
            if (Session["idPelicula"] == null)
            {
                if (!IsPostBack)
                {
                    indiceFuncion = 0;
                    mostrar();
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    ddpPerfil.Items.Add("Seleccione opción");
                    ddpPerfil.Items.Add("Perfil");
                    ddpPerfil.Items.Add("Compras realizadas");
                    ddpPerfil.Items.Add("Agregar Tarjetas");
                    ddpPerfil.Items.Add("Cerrar Sesión");

                    idPelicula = (int)Session["idPelicula"];
                    idSucursal = (int)Session["idSucursal"];
                    funciones = NegocioCine.ObtenerFunciones(idPelicula, idSucursal);
                    cantFunciones = funciones.Count;
                    indiceFuncion = 0;
                    vistas = new List<int>();
                    if (cantFunciones > 0)
                    {
                        mostrar();
                    }
                    else
                    {
                        lblTitulo.Text = "No hay funiones de esa película";
                    }
                }
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

        private void mostrar()
        {
            lblPelicula.Text = "Pelicula: ";
            lblFormato.Text = "Formato: ";
            lblFecha.Text = "Fecha: ";
            lblHora.Text = "Horario: ";
            lblDireccion.Text = "Direccion: ";
            lblSucursal.Text = "Sucursal: ";
            lblSala.Text = "Sala: ";
            habilitarButacas();
            Pelicula pelicula = NegocioCine.ObtenerPelicula(idPelicula);
            lblPelicula.Text += pelicula.Nombre.ToString();
            
            if(pelicula.Formato3D)
            {
                lblFormato.Text += "3D";
            }
            else
            {
                lblFormato.Text += "2D";
            }
            Funcion funcion = funciones[indiceFuncion];
            Sala sala = NegocioCine.ObtenerSala(funcion.Sala);
            Sucursal sucursal = NegocioCine.ObtenerSucursal(sala.Sucursal);
            lblFecha.Text += Formato.FechaLarga(funcion.Fecha);
            lblHora.Text += Formato.Hora(funcion.Hora);
            lblDireccion.Text += sucursal.Direccion;
            lblSucursal.Text += sucursal.Nombre;

            lblSala.Text += sala.Nombre;

            Session["Fecha"] = lblFecha.Text;
            Session["Hora"] = lblHora.Text;
            Session["Sucursal"] = lblSucursal.Text;
            Session["Direccion"] = lblDireccion.Text;

            reservadas = NegocioCine.ButacasReservadas(funcion.Id);
            foreach (Reservada res in reservadas)
            {
                int fila = res.Fila - 1;
                int butaca = res.Butaca - 1;
                int i = fila * 10 + butaca;
                if (butacas[i] != null)
                {
                    butacas[i].BackColor = Color.Red;
                    butacas[i].Enabled = false;
                }                
            }
            btnAnterior.Enabled = indiceFuncion > 0;
            btnSiguiente.Enabled = indiceFuncion < cantFunciones - 1;
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            vistas.Clear();
            btnComprar.Enabled = false;
            indiceFuncion--;
            mostrar();  
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            vistas.Clear();
            indiceFuncion++;
            mostrar();
        }

        private void habilitarButacas()
        {
            for (int i = 0; i < 80; i++)
            {
                butacas[i].BackColor = Color.Black;
                butacas[i].Enabled = true;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Session["idPelicula"] = idPelicula;
            Response.Redirect("PantallaDetallesPeliculas.aspx");
        }

        protected void btnLogoCine_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx");
        }

        protected void btnUsuario_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaIniciarSesion.aspx");
        }

        protected void btnLogoCine_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx");
        }

        protected void btnUsuario_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaIniciarSesion.aspx");
        }

        //asientos 

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if(ImageButton1.BackColor == Color.Black)
            {
                ImageButton1.BackColor = Color.Orange;
                vistas.Add(1);
            }
            else
            {
                ImageButton1.BackColor = Color.Black;
                vistas.Remove(1);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton2.BackColor == Color.Black)
            {
                ImageButton2.BackColor = Color.Orange;
                vistas.Add(2);
            }
            else
            {
                ImageButton2.BackColor = Color.Black;
                vistas.Remove(2);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton3.BackColor == Color.Black)
            {
                ImageButton3.BackColor = Color.Orange;
                vistas.Add(3);
            }
            else
            {
                ImageButton3.BackColor = Color.Black;
                vistas.Remove(3);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton4.BackColor == Color.Black)
            {
                ImageButton4.BackColor = Color.Orange;
                vistas.Add(4);
            }
            else
            {
                ImageButton4.BackColor = Color.Black;
                vistas.Remove(4);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton5.BackColor == Color.Black)
            {
                ImageButton5.BackColor = Color.Orange;
                vistas.Add(5);
            }
            else
            {
                ImageButton5.BackColor = Color.Black;
                vistas.Remove(5);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton6.BackColor == Color.Black)
            {
                ImageButton6.BackColor = Color.Orange;
                vistas.Add(6);
            }
            else
            {
                ImageButton6.BackColor = Color.Black;
                vistas.Remove(6);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton7.BackColor == Color.Black)
            {
                ImageButton7.BackColor = Color.Orange;
                vistas.Add(7);
            }
            else
            {
                ImageButton7.BackColor = Color.Black;
                vistas.Remove(7);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton8.BackColor == Color.Black)
            {
                ImageButton8.BackColor = Color.Orange;
                vistas.Add(8);
            }
            else
            {
                ImageButton8.BackColor = Color.Black;
                vistas.Remove(8);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton9.BackColor == Color.Black)
            {
                ImageButton9.BackColor = Color.Orange;
                vistas.Add(9);
            }
            else
            {
                ImageButton9.BackColor = Color.Black;
                vistas.Remove(9);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton10.BackColor == Color.Black)
            {
                ImageButton10.BackColor = Color.Orange;
                vistas.Add(10);
            }
            else
            {
                ImageButton10.BackColor = Color.Black;
                vistas.Remove(10);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton11.BackColor == Color.Black)
            {
                ImageButton11.BackColor = Color.Orange;
                vistas.Add(11);
            }
            else
            {
                ImageButton11.BackColor = Color.Black;
                vistas.Remove(11);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton12.BackColor == Color.Black)
            {
                ImageButton12.BackColor = Color.Orange;
                vistas.Add(12);
            }
            else
            {
                ImageButton12.BackColor = Color.Black;
                vistas.Remove(12);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton13_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton13.BackColor == Color.Black)
            {
                ImageButton13.BackColor = Color.Orange;
                vistas.Add(13);
            }
            else
            {
                ImageButton13.BackColor = Color.Black;
                vistas.Remove(13);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton14_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton14.BackColor == Color.Black)
            {
                ImageButton14.BackColor = Color.Orange;
                vistas.Add(14);
            }
            else
            {
                ImageButton14.BackColor = Color.Black;
                vistas.Remove(14);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton15_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton15.BackColor == Color.Black)
            {
                ImageButton15.BackColor = Color.Orange;
                vistas.Add(15);
            }
            else
            {
                ImageButton15.BackColor = Color.Black;
                vistas.Remove(15);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton16_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton16.BackColor == Color.Black)
            {
                ImageButton16.BackColor = Color.Orange;
                vistas.Add(16);
            }
            else
            {
                ImageButton16.BackColor = Color.Black;
                vistas.Remove(16);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton17_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton17.BackColor == Color.Black)
            {
                ImageButton17.BackColor = Color.Orange;
                vistas.Add(17);
            }
            else
            {
                ImageButton17.BackColor = Color.Black;
                vistas.Remove(17);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton18_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton18.BackColor == Color.Black)
            {
                ImageButton18.BackColor = Color.Orange;
                vistas.Add(18);
            }
            else
            {
                ImageButton18.BackColor = Color.Black;
                vistas.Remove(18);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton19_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton19.BackColor == Color.Black)
            {
                ImageButton19.BackColor = Color.Orange;
                vistas.Add(19);
            }
            else
            {
                ImageButton19.BackColor = Color.Black;
                vistas.Remove(19);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton20_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton20.BackColor == Color.Black)
            {
                ImageButton20.BackColor = Color.Orange;
                vistas.Add(20);
            }
            else
            {
                ImageButton20.BackColor = Color.Black;
                vistas.Remove(20);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton21_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton21.BackColor == Color.Black)
            {
                ImageButton21.BackColor = Color.Orange;
                vistas.Add(21);
            }
            else
            {
                ImageButton21.BackColor = Color.Black;
                vistas.Remove(21);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton22_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton22.BackColor == Color.Black)
            {
                ImageButton22.BackColor = Color.Orange;
                vistas.Add(22);
            }
            else
            {
                ImageButton22.BackColor = Color.Black;
                vistas.Remove(22);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton23_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton23.BackColor == Color.Black)
            {
                ImageButton23.BackColor = Color.Orange;
                vistas.Add(23);
            }
            else
            {
                ImageButton23.BackColor = Color.Black;
                vistas.Remove(23);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton24_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton24.BackColor == Color.Black)
            {
                ImageButton24.BackColor = Color.Orange;
                vistas.Add(24);
            }
            else
            {
                ImageButton24.BackColor = Color.Black;
                vistas.Remove(24);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton25_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton25.BackColor == Color.Black)
            {
                ImageButton25.BackColor = Color.Orange;
                vistas.Add(25);
            }
            else
            {
                ImageButton25.BackColor = Color.Black;
                vistas.Remove(25);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton26_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton26.BackColor == Color.Black)
            {
                ImageButton26.BackColor = Color.Orange;
                vistas.Add(26);
            }
            else
            {
                ImageButton26.BackColor = Color.Black;
                vistas.Remove(26);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton27_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton27.BackColor == Color.Black)
            {
                ImageButton27.BackColor = Color.Orange;
                vistas.Add(27);
            }
            else
            {
                ImageButton27.BackColor = Color.Black;
                vistas.Remove(27);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton28_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton28.BackColor == Color.Black)
            {
                ImageButton28.BackColor = Color.Orange;
                vistas.Add(28);
            }
            else
            {
                ImageButton28.BackColor = Color.Black;
                vistas.Remove(28);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton29_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton29.BackColor == Color.Black)
            {
                ImageButton29.BackColor = Color.Orange;
                vistas.Add(29);
            }
            else
            {
                ImageButton29.BackColor = Color.Black;
                vistas.Remove(29);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton30_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton30.BackColor == Color.Black)
            {
                ImageButton30.BackColor = Color.Orange;
                vistas.Add(30);
            }
            else
            {
                ImageButton30.BackColor = Color.Black;
                vistas.Remove(30);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton31_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton31.BackColor == Color.Black)
            {
                ImageButton31.BackColor = Color.Orange;
                vistas.Add(31);
            }
            else
            {
                ImageButton31.BackColor = Color.Black;
                vistas.Remove(31);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton32_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton32.BackColor == Color.Black)
            {
                ImageButton32.BackColor = Color.Orange;
                vistas.Add(32);
            }
            else
            {
                ImageButton32.BackColor = Color.Black;
                vistas.Remove(32);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton33_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton33.BackColor == Color.Black)
            {
                ImageButton33.BackColor = Color.Orange;
                vistas.Add(33);
            }
            else
            {
                ImageButton33.BackColor = Color.Black;
                vistas.Remove(33);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton34_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton34.BackColor == Color.Black)
            {
                ImageButton34.BackColor = Color.Orange;
                vistas.Add(34);
            }
            else
            {
                ImageButton34.BackColor = Color.Black;
                vistas.Remove(34);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton35_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton35.BackColor == Color.Black)
            {
                ImageButton35.BackColor = Color.Orange;
                vistas.Add(35);
            }
            else
            {
                ImageButton35.BackColor = Color.Black;
                vistas.Remove(35);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton36_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton36.BackColor == Color.Black)
            {
                ImageButton36.BackColor = Color.Orange;
                vistas.Add(36);
            }
            else
            {
                ImageButton36.BackColor = Color.Black;
                vistas.Remove(36);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton37_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton37.BackColor == Color.Black)
            {
                ImageButton37.BackColor = Color.Orange;
                vistas.Add(37);
            }
            else
            {
                ImageButton37.BackColor = Color.Black;
                vistas.Remove(37);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton38_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton38.BackColor == Color.Black)
            {
                ImageButton38.BackColor = Color.Orange;
                vistas.Add(38);
            }
            else
            {
                ImageButton38.BackColor = Color.Black;
                vistas.Remove(38);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton39_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton39.BackColor == Color.Black)
            {
                ImageButton39.BackColor = Color.Orange;
                vistas.Add(39);
            }
            else
            {
                ImageButton39.BackColor = Color.Black;
                vistas.Remove(39);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton40_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton40.BackColor == Color.Black)
            {
                ImageButton40.BackColor = Color.Orange;
                vistas.Add(40);
            }
            else
            {
                ImageButton40.BackColor = Color.Black;
                vistas.Remove(40);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton41_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton41.BackColor == Color.Black)
            {
                ImageButton41.BackColor = Color.Orange;
                vistas.Add(41);
            }
            else
            {
                ImageButton41.BackColor = Color.Black;
                vistas.Remove(41);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton42_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton42.BackColor == Color.Black)
            {
                ImageButton42.BackColor = Color.Orange;
                vistas.Add(42);
            }
            else
            {
                ImageButton42.BackColor = Color.Black;
                vistas.Remove(42);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton43_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton43.BackColor == Color.Black)
            {
                ImageButton43.BackColor = Color.Orange;
                vistas.Add(43);
            }
            else
            {
                ImageButton43.BackColor = Color.Black;
                vistas.Remove(43);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton44_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton44.BackColor == Color.Black)
            {
                ImageButton44.BackColor = Color.Orange;
                vistas.Add(44);
            }
            else
            {
                ImageButton44.BackColor = Color.Black;
                vistas.Remove(44);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton45_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton45.BackColor == Color.Black)
            {
                ImageButton45.BackColor = Color.Orange;
                vistas.Add(45);
            }
            else
            {
                ImageButton45.BackColor = Color.Black;
                vistas.Remove(45);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton46_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton46.BackColor == Color.Black)
            {
                ImageButton46.BackColor = Color.Orange;
                vistas.Add(46);
            }
            else
            {
                ImageButton46.BackColor = Color.Black;
                vistas.Remove(46);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton47_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton47.BackColor == Color.Black)
            {
                ImageButton47.BackColor = Color.Orange;
                vistas.Add(47);
            }
            else
            {
                ImageButton47.BackColor = Color.Black;
                vistas.Remove(47);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton48_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton48.BackColor == Color.Black)
            {
                ImageButton48.BackColor = Color.Orange;
                vistas.Add(48);
            }
            else
            {
                ImageButton48.BackColor = Color.Black;
                vistas.Remove(48);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton49_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton49.BackColor == Color.Black)
            {
                ImageButton49.BackColor = Color.Orange;
                vistas.Add(49);
            }
            else
            {
                ImageButton49.BackColor = Color.Black;
                vistas.Remove(49);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton50_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton50.BackColor == Color.Black)
            {
                ImageButton50.BackColor = Color.Orange;
                vistas.Add(50);
            }
            else
            {
                ImageButton50.BackColor = Color.Black;
                vistas.Remove(50);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton51_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton51.BackColor == Color.Black)
            {
                ImageButton51.BackColor = Color.Orange;
                vistas.Add(51);
            }
            else
            {
                ImageButton51.BackColor = Color.Black;
                vistas.Remove(51);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton52_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton52.BackColor == Color.Black)
            {
                ImageButton52.BackColor = Color.Orange;
                vistas.Add(52);
            }
            else
            {
                ImageButton52.BackColor = Color.Black;
                vistas.Remove(52);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton53_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton53.BackColor == Color.Black)
            {
                ImageButton53.BackColor = Color.Orange;
                vistas.Add(53);
            }
            else
            {
                ImageButton53.BackColor = Color.Black;
                vistas.Remove(53);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton54_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton54.BackColor == Color.Black)
            {
                ImageButton54.BackColor = Color.Orange;
                vistas.Add(54);
            }
            else
            {
                ImageButton54.BackColor = Color.Black;
                vistas.Remove(54);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton55_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton55.BackColor == Color.Black)
            {
                ImageButton55.BackColor = Color.Orange;
                vistas.Add(55);
            }
            else
            {
                ImageButton55.BackColor = Color.Black;
                vistas.Remove(55);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton56_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton56.BackColor == Color.Black)
            {
                ImageButton56.BackColor = Color.Orange;
                vistas.Add(56);
            }
            else
            {
                ImageButton56.BackColor = Color.Black;
                vistas.Remove(56);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton57_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton57.BackColor == Color.Black)
            {
                ImageButton57.BackColor = Color.Orange;
                vistas.Add(57);
            }
            else
            {
                ImageButton57.BackColor = Color.Black;
                vistas.Remove(57);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton58_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton58.BackColor == Color.Black)
            {
                ImageButton58.BackColor = Color.Orange;
                vistas.Add(58);
            }
            else
            {
                ImageButton58.BackColor = Color.Black;
                vistas.Remove(58);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton59_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton59.BackColor == Color.Black)
            {
                ImageButton59.BackColor = Color.Orange;
                vistas.Add(59);
            }
            else
            {
                ImageButton59.BackColor = Color.Black;
                vistas.Remove(59);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton60_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton60.BackColor == Color.Black)
            {
                ImageButton60.BackColor = Color.Orange;
                vistas.Add(60);
            }
            else
            {
                ImageButton60.BackColor = Color.Black;
                vistas.Remove(60);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton61_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton61.BackColor == Color.Black)
            {
                ImageButton61.BackColor = Color.Orange;
                vistas.Add(61);
            }
            else
            {
                ImageButton61.BackColor = Color.Black;
                vistas.Remove(61);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton62_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton62.BackColor == Color.Black)
            {
                ImageButton62.BackColor = Color.Orange;
                vistas.Add(62);
            }
            else
            {
                ImageButton62.BackColor = Color.Black;
                vistas.Remove(62);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton63_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton63.BackColor == Color.Black)
            {
                ImageButton63.BackColor = Color.Orange;
                vistas.Add(63);
            }
            else
            {
                ImageButton63.BackColor = Color.Black;
                vistas.Remove(63);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton64_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton64.BackColor == Color.Black)
            {
                ImageButton64.BackColor = Color.Orange;
                vistas.Add(64);
            }
            else
            {
                ImageButton64.BackColor = Color.Black;
                vistas.Remove(64);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton65_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton65.BackColor == Color.Black)
            {
                ImageButton65.BackColor = Color.Orange;
                vistas.Add(65);
            }
            else
            {
                ImageButton65.BackColor = Color.Black;
                vistas.Remove(65);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton66_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton66.BackColor == Color.Black)
            {
                ImageButton66.BackColor = Color.Orange;
                vistas.Add(66);
            }
            else
            {
                ImageButton66.BackColor = Color.Black;
                vistas.Remove(66);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton67_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton67.BackColor == Color.Black)
            {
                ImageButton67.BackColor = Color.Orange;
                vistas.Add(67);
            }
            else
            {
                ImageButton67.BackColor = Color.Black;
                vistas.Remove(67);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton68_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton68.BackColor == Color.Black)
            {
                ImageButton68.BackColor = Color.Orange;
                vistas.Add(68);
            }
            else
            {
                ImageButton68.BackColor = Color.Black;
                vistas.Remove(68);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton69_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton69.BackColor == Color.Black)
            {
                ImageButton69.BackColor = Color.Orange;
                vistas.Add(69);
            }
            else
            {
                ImageButton69.BackColor = Color.Black;
                vistas.Remove(69);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton70_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton70.BackColor == Color.Black)
            {
                ImageButton70.BackColor = Color.Orange;
                vistas.Add(70);
            }
            else
            {
                ImageButton70.BackColor = Color.Black;
                vistas.Remove(70);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton71_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton71.BackColor == Color.Black)
            {
                ImageButton71.BackColor = Color.Orange;
                vistas.Add(71);
            }
            else
            {
                ImageButton71.BackColor = Color.Black;
                vistas.Remove(71);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton72_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton72.BackColor == Color.Black)
            {
                ImageButton72.BackColor = Color.Orange;
                vistas.Add(72);
            }
            else
            {
                ImageButton72.BackColor = Color.Black;
                vistas.Remove(72);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton73_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton73.BackColor == Color.Black)
            {
                ImageButton73.BackColor = Color.Orange;
                vistas.Add(73);
            }
            else
            {
                ImageButton73.BackColor = Color.Black;
                vistas.Remove(73);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton74_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton74.BackColor == Color.Black)
            {
                ImageButton74.BackColor = Color.Orange;
                vistas.Add(74);
            }
            else
            {
                ImageButton74.BackColor = Color.Black;
                vistas.Remove(74);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton75_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton75.BackColor == Color.Black)
            {
                ImageButton75.BackColor = Color.Orange;
                vistas.Add(75);
            }
            else
            {
                ImageButton75.BackColor = Color.Black;
                vistas.Remove(75);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton76_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton76.BackColor == Color.Black)
            {
                ImageButton76.BackColor = Color.Orange;
                vistas.Add(76);
            }
            else
            {
                ImageButton76.BackColor = Color.Black;
                vistas.Remove(76);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton77_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton77.BackColor == Color.Black)
            {
                ImageButton77.BackColor = Color.Orange;
                vistas.Add(77);
            }
            else
            {
                ImageButton77.BackColor = Color.Black;
                vistas.Remove(77);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton78_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton78.BackColor == Color.Black)
            {
                ImageButton78.BackColor = Color.Orange;
                vistas.Add(78);
            }
            else
            {
                ImageButton78.BackColor = Color.Black;
                vistas.Remove(78);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton79_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton79.BackColor == Color.Black)
            {
                ImageButton79.BackColor = Color.Orange;
                vistas.Add(79);
            }
            else
            {
                ImageButton79.BackColor = Color.Black;
                vistas.Remove(79);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        protected void ImageButton80_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton80.BackColor == Color.Black)
            {
                ImageButton80.BackColor = Color.Orange;
                vistas.Add(80);
            }
            else
            {
                ImageButton80.BackColor = Color.Black;
                vistas.Remove(80);
            }
            btnComprar.Enabled = vistas.Count > 0;
        }

        private void iniciarPagina()
        {
            butacas[0] = ImageButton1;
            butacas[1] = ImageButton2;
            butacas[2] = ImageButton3;
            butacas[3] = ImageButton4;
            butacas[4] = ImageButton5;
            butacas[5] = ImageButton6;
            butacas[6] = ImageButton7;
            butacas[7] = ImageButton8;
            butacas[8] = ImageButton9;
            butacas[9] = ImageButton10;
            butacas[10] = ImageButton11;
            butacas[11] = ImageButton12;
            butacas[12] = ImageButton13;
            butacas[13] = ImageButton14;
            butacas[14] = ImageButton15;
            butacas[15] = ImageButton16;
            butacas[16] = ImageButton17;
            butacas[17] = ImageButton18;
            butacas[18] = ImageButton19;
            butacas[19] = ImageButton20;
            butacas[20] = ImageButton21;
            butacas[21] = ImageButton22;
            butacas[22] = ImageButton23;
            butacas[23] = ImageButton24;
            butacas[24] = ImageButton25;
            butacas[25] = ImageButton26;
            butacas[26] = ImageButton27;
            butacas[27] = ImageButton28;
            butacas[28] = ImageButton29;
            butacas[29] = ImageButton30;
            butacas[30] = ImageButton31;
            butacas[31] = ImageButton32;
            butacas[32] = ImageButton33;
            butacas[33] = ImageButton34;
            butacas[34] = ImageButton35;
            butacas[35] = ImageButton36;
            butacas[36] = ImageButton37;
            butacas[37] = ImageButton38;
            butacas[38] = ImageButton39;
            butacas[39] = ImageButton40;
            butacas[40] = ImageButton41;
            butacas[41] = ImageButton42;
            butacas[42] = ImageButton43;
            butacas[43] = ImageButton44;
            butacas[44] = ImageButton45;
            butacas[45] = ImageButton46;
            butacas[46] = ImageButton47;
            butacas[47] = ImageButton48;
            butacas[48] = ImageButton49;
            butacas[49] = ImageButton50;
            butacas[50] = ImageButton51;
            butacas[51] = ImageButton52;
            butacas[52] = ImageButton53;
            butacas[53] = ImageButton54;
            butacas[54] = ImageButton55;
            butacas[55] = ImageButton56;
            butacas[56] = ImageButton57;
            butacas[57] = ImageButton58;
            butacas[58] = ImageButton59;
            butacas[59] = ImageButton60;
            butacas[60] = ImageButton61;
            butacas[61] = ImageButton62;
            butacas[62] = ImageButton63;
            butacas[63] = ImageButton64;
            butacas[64] = ImageButton65;
            butacas[65] = ImageButton66;
            butacas[66] = ImageButton67;
            butacas[67] = ImageButton68;
            butacas[68] = ImageButton69;
            butacas[69] = ImageButton70;
            butacas[70] = ImageButton71;
            butacas[71] = ImageButton72;
            butacas[72] = ImageButton73;
            butacas[73] = ImageButton74;
            butacas[74] = ImageButton75;
            butacas[75] = ImageButton76;
            butacas[76] = ImageButton77;
            butacas[77] = ImageButton78;
            butacas[78] = ImageButton79;
            butacas[79] = ImageButton80;
            NegocioCine.Conectar();
        }

        protected void btnComprar_Click1(object sender, EventArgs e)
        {
            if(vistas.Count() > 0) {
                Session["FuncionReservada"] = funciones[indiceFuncion].Id;                
                string reservadas = vistas[0].ToString();
                for (int i = 1; i < vistas.Count(); i++)
                {
                    reservadas += " " + vistas[i].ToString();
                }
                Session["ButacasReservadas"] = reservadas;
                Response.Redirect("PantallaFacturacion.aspx");
            }
            else
            {
                Response.Redirect("PantallaPrincipal.aspx");
            }
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Session["idPelicula"] = idPelicula;
            Response.Redirect("PantallaDetallesPeliculas.aspx");
        }

        protected void btnLinkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Session["idPelicula"] = idPelicula;
            Response.Redirect("PantallaDetallesPeliculas.aspx");
        }

        protected void btnUsuario_Click2(object sender, ImageClickEventArgs e)
        {
            if (Session["Email"] == null)
            {
                Response.Redirect("PantallaIniciarSesion.aspx");
            }
            else
            {
                Response.Redirect("PantallaDatosUsuario.aspx");
            }
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