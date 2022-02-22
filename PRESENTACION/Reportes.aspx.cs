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
    public partial class Reportes : System.Web.UI.Page
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

            if(!IsPostBack)
            {
                NegocioCine.Conectar();

                foreach (Pelicula p in NegocioCine.ObtenerPeliculas())
                {
                    dropTitulo.Items.Add(p.Id + " " + p.Nombre);
                }
                dropTitulo.SelectedIndex = 0;

                foreach (Genero g in NegocioCine.ObtenerGeneros())
                {
                    dropGenero.Items.Add(g.Id + " " + g.Nombre);
                }
                dropGenero.SelectedIndex = 0;

                foreach(Sucursal s in NegocioCine.ObtenerSucursales())
                {
                    dropSucursal.Items.Add(s.Id + " " + s.Nombre);
                }
                dropSucursal.SelectedIndex = 0;

                DateTime hoy = DateTime.Today;
                int d = hoy.Day;
                int m = hoy.Month;
                int a = hoy.Year;
                int fechaHasta = a * 10000 + m * 100 + d;
                int fechaDesde = (a-5) * 10000 + m * 100 + d;
                Session["FechaDesde"] = fechaDesde;
                Session["FechaHasta"] = fechaHasta;
                calDesde.SelectedDate = new DateTime(a - 5, m, d);
                calHasta.SelectedDate = new DateTime(a, m, d);
            }
        }

        protected void btnPrincipal_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AdminPrincipal.aspx");
        }

        protected void btnRecaudacion3D_Click(object sender, EventArgs e)
        {
            lblRecaudacion3D.Visible = true;
            string nombre = NegocioCine.PeliculaMasVista(true);
            lblRecaudacion3D.Text = nombre;
        }

        protected void btnFacturacion3D_Click(object sender, EventArgs e)
        {
            lblFacturacion3D.Visible = true;
            int total = NegocioCine.RecaudacionPorFormato(true);
            lblFacturacion3D.Text = "$" + total.ToString();
        }

        protected void btnFacturacion2D_Click(object sender, EventArgs e)
        {
            lblFacturacion2D.Visible = true;
            int total = NegocioCine.RecaudacionPorFormato(false);
            lblFacturacion2D.Text = "$" + total.ToString();
        }

        protected void btnRecaudacion2D_Click(object sender, EventArgs e)
        {
            lblRecaudacion2D.Visible = true;           
            string nombre = NegocioCine.PeliculaMasVista(false);
            lblRecaudacion2D.Text = nombre;
        }

        protected void btnVendidas3D_Click(object sender, EventArgs e)
        {
            lblCantVend3D.Visible = true;
            int total = NegocioCine.VendidasPorFormato(true);
            lblCantVend3D.Text = total.ToString() + " " + "entradas";
        }

        protected void btnVendidas2D_Click(object sender, EventArgs e)
        {
            lblCantVend2D.Visible = true;
            int total = NegocioCine.VendidasPorFormato(false);
            lblCantVend2D.Text = total.ToString() + " " + "entradas";
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dt = calDesde.SelectedDate;
            int d = dt.Day;
            int m = dt.Month;
            int a = dt.Year;
            int fecha = a * 10000 + m * 100 + d;
            Session["FechaDesde"] = fecha;
        }

        protected void calHasta_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dt = calHasta.SelectedDate;
            int d = dt.Day;
            int m = dt.Month;
            int a = dt.Year;
            int fecha = a * 10000 + m * 100 + d;
            Session["FechaHasta"] = fecha;
        }

        protected void btnFecha_Click(object sender, EventArgs e)
        {
            int fechaDesde = int.Parse(Session["FechaDesde"].ToString());
            int fechaHasta = int.Parse(Session["FechaHasta"].ToString());
            if (fechaDesde <= fechaHasta)
            {
                int id = int.Parse(dropTitulo.SelectedItem.Text.Split(new char[] { ' ' })[0].ToString());
                lblCantidadxTitulo.Text = NegocioCine.ReportePorPelicula(id, fechaDesde, fechaHasta).ToString() + " Entradas";

                id = int.Parse(dropGenero.SelectedItem.Text.Split(new char [] {' '})[0].ToString());
                lblCantidadxGenero.Text=NegocioCine.ReportePorGenero(id ,fechaDesde, fechaHasta).ToString() + " Entradas";
                          
                id = int.Parse(dropSucursal.SelectedItem.Text.Split(new char[] { ' ' })[0].ToString());
                lblCantidadxSucursal.Text = NegocioCine.ReportePorSucursal(id, fechaDesde, fechaHasta).ToString() + " Entradas";
            }
        }

        protected void btnLinkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("PantallaIniciarSesion.aspx");
        }
    }
}