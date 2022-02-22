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
    public partial class AdminAgregarFuncion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errormsg.Text = "";
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

                foreach (Pelicula p in NegocioCine.ObtenerPeliculasActivas())
                {
                    dropPelicula.Items.Add(p.Id + " " + p.Nombre);
                }

                foreach (Sala s in NegocioCine.ObtenerSalas())
                {
                    dropSala.Items.Add(s.Id + " " + s.Nombre);
                }

                Session["Fecha"] = 0;
            }
        }

        public static bool AgregarFuncion(int Pelicula, int Sala, int Fecha, int Hora)
        {
            return NegocioCine.AgregarFuncion(Pelicula, Sala, Fecha, Hora);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool exito;

            exito = txtHora.Text.Length > 0;
            exito = exito && int.Parse(txtHora.Text) >= 1000 && int.Parse(txtHora.Text) <= 2400;
            exito = exito && int.Parse(Session["Fecha"].ToString()) != 0;
            if (exito)
            {
                string p = dropPelicula.SelectedValue.ToString();
                int pelicula = int.Parse(p.Split(new char[] { ' ' })[0]);

                p = dropSala.SelectedValue.ToString();

                int sala = int.Parse(p.Split(new char[] { ' ' })[0]);

                if(AgregarFuncion(pelicula, sala, int.Parse(Session["Fecha"].ToString()), int.Parse(txtHora.Text)))
                {
                    btnOK.Visible = true;
                    errormsg.Visible = true;
                    errormsg.Text = "Agregado correctamente!";
                    btnResetear.Visible = false;
                }
                else
                {
                    btnOK.Visible = true;
                    errormsg.Visible = true;
                    btnResetear.Visible = false;
                    errormsg.Text = "Esa función ya existe.";
                }
            }
            else
            {
                btnResetear.Visible = false;
                btnOK.Visible = true;
                errormsg.Visible = true;
                errormsg.Text = "Formulario invalido";
            }

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.Visible = false;
            errormsg.Visible = false;
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

        protected void calFecha_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dt = calFecha.SelectedDate;
            int d = dt.Day;
            int m = dt.Month;
            int a = dt.Year;
            int fecha = a * 10000 + m * 100 + d;
            Session["Fecha"] = fecha;
        }

        protected void btnCalendario_Click(object sender, EventArgs e)
        {
            calFecha.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAgregarFuncion.aspx");
        }
    }
}