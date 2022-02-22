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
    public partial class PantallaRegistrar2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioCine.Conectar();
                dropGenero.Items.Add("Femenino");
                dropGenero.Items.Add("Masculino");
                Session["Fecha"] = 0;
            }
        }

        public static bool AgregarUsuario(string Nombre, string Apellido, int Dni, string Genero, int Nacimiento, string Email, string Telefono, string Password, bool Admin, bool Activo)
        {
            return NegocioCine.AgregarUsuario(Nombre, Apellido, Dni, Genero, Nacimiento, Email, Telefono, Password, Admin, Activo);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool exito;

            exito = txtNombre.Text.Length > 0;
            exito = exito && txtApellido.Text.Length > 0;
            exito = exito && txtDNI.Text.Length > 0;
            exito = exito && txtEmail.Text.Length > 0;
            exito = exito && txtTelefono.Text.Length > 0;
            exito = exito && txtContraseña.Text.Length > 0;
            exito = exito && int.Parse(Session["Fecha"].ToString()) != 0;

            if (exito)
            {

                if (AgregarUsuario(txtNombre.Text, txtApellido.Text, int.Parse(txtDNI.Text), dropGenero.SelectedValue.ToString(),
                    int.Parse(Session["Fecha"].ToString()), txtEmail.Text, txtTelefono.Text, txtContraseña.Text, false, true))
                {
                    btnLogin.Visible = false;
                    btnAceptar.Visible = true;
                    errormsg.Visible = true;
                    errormsg.Text = "Usuario agregado!";
                }
                else
                {
                    btnLogin.Visible = false;
                    errormsg.Visible = true;
                    btnAceptar.Visible = true;
                    errormsg.Text = "Correo ya registrado";
                }
            }
            else
            {
                btnLogin.Visible = false;
                btnAceptar.Visible = true;
                errormsg.Visible = true;
                errormsg.Text = "Formulario incompleto.";
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            btnLogin.Visible = true;
            btnAceptar.Visible = false;
            errormsg.Visible = false;
            calNacimiento.Visible = false;
        }

        protected void btnLogoCine_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx");

        }

        protected void btnVolver_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaIniciarSesion.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("PantallaIniciarSesion.aspx");
        }

        protected void calNacimiento_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dt = calNacimiento.SelectedDate;
            int d = dt.Day;
            int m = dt.Month;
            int a = dt.Year;
            int fecha = a * 10000 + m * 100 + d;
            Session["Fecha"] = fecha;
        }

        protected void btnCalendario_Click(object sender, EventArgs e)
        {
            calNacimiento.Visible = true;
        }
    }
}