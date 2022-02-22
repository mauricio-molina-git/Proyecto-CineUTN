using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using NEGOCIO;
using ENTIDAD;
using System.Web.UI.HtmlControls;

namespace CineUtn
{
    public partial class DetalleReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Mostrar();
                ddpPerfil.Items.Add("Seleccione opción");
                ddpPerfil.Items.Add("Perfil");
                ddpPerfil.Items.Add("Compras realizadas");
                ddpPerfil.Items.Add("Agregar Tarjetas");
                ddpPerfil.Items.Add("Cerrar Sesión");

                if (Session["Email"] != null)
                {
                    string email = Session["Email"].ToString();
                    Usuario usu = NegocioCine.ObtenerUsuario(email);
                    if (usu != null)
                    {
                        lblusuario.Text = usu.Nombre + " " + usu.Apellido;
                        ddpPerfil.Visible = true;
                    }

                    lstSucursales.Items.Clear();
                    foreach (Sucursal sucursal in NegocioCine.ObtenerSucursales())
                    {
                        lstSucursales.Items.Add(sucursal.Id + " " + sucursal.Nombre + " " + sucursal.Direccion);
                    }
                }
                else
                {
                    lblusuario.Text = "Sin iniciar sesión";
                }
            }
        }

        private void Mostrar()
        {
            Pelicula peliculas = null;
            Genero genero = null;
            Calificacion clasificacion = null;
            Precio precio = null;

            NegocioCine.Conectar();
            peliculas = NegocioCine.ObtenerPelicula(Convert.ToInt32(Session["idPelicula"]));
            genero = NegocioCine.ObtenerGenero(peliculas.Genero);
            clasificacion = NegocioCine.ObtenerCalificacion(peliculas.Calificacion);
            precio = NegocioCine.ObtenerPrecio(peliculas.Formato3D);

            Session["Precio"] = precio.Importe;

            imgDetalle.ImageUrl = peliculas.Imagen;
            lblNombrePelicula.Text = peliculas.Nombre;
            lblDuracion.Text += peliculas.Duracion.ToString() + " min";
            lblSinopsis.Text = peliculas.Sinopsis;
            lblGenero.Text += genero.Nombre;
            lblClasificacion.Text += clasificacion.Nombre;
            lblPrecio.Text += precio.Importe;

            if(peliculas.Formato3D)
            {
                lblFormato.Text += "3D";
            }
            else
            {
                lblFormato.Text += "2D";

            }
        }

        protected void btnFunciones_Click(object sender, EventArgs e)
        {
            if (Session["Email"] != null)
            {
                string suc = lstSucursales.SelectedValue.ToString();
                Session["idSucursal"] = int.Parse(suc.Split(new char[] { ' ' })[0]);
                if (NegocioCine.ObtenerFunciones(int.Parse(Session["idPelicula"].ToString()), int.Parse(Session["idSucursal"].ToString())).Count > 0)
                {
                    Response.Redirect("PantallaButacas.aspx");
                }
                else
                {
                    btnAceptar.Visible = true;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No hay funciones de esa película";
                    lstSucursales.Visible = false;            
                }
            }
            else
            {
                lstSucursales.Visible = false;
                btnLogin.Visible = true;
                lblMensaje.Visible = true;
            }
                
        }

        protected void btnLogoPrincipal_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("PantallaIniciarSesion.aspx");
        }

        protected void btnLinkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("PantallaDetallesPeliculas.aspx");
        }

        protected void btnUsuario_Click(object sender, ImageClickEventArgs e)
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

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx");
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            btnAceptar.Visible = false;
            lstSucursales.Visible = true;
            lblMensaje.Visible = false;
        }
    }
 }
