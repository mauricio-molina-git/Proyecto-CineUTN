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
    public partial class AdminAgregarUsuario : System.Web.UI.Page
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
                dropGenero.Items.Add("Femenino");
                dropGenero.Items.Add("Masculino");

                Session["Fecha"] = 0;
            }
        }

        public static bool AgregarUsuario(string Nombre, string Apellido, int dni, string Genero, int Nacimiento, string Email, string Telefono, string Password, bool Admin, bool Activo)
        {
            return NegocioCine.AgregarUsuario(Nombre, Apellido, dni, Genero, Nacimiento, Email, Telefono, Password, Admin, Activo); 
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool exito;

            exito = int.Parse(Session["Fecha"].ToString()) != 0;
            exito = exito && txtApellido.Text.Length > 0;
            exito = exito && txtDni.Text.Length > 0;
            exito = exito && txtEmail.Text.Length > 0;
            exito = exito && txtTelefono.Text.Length > 0;
            exito = exito && txtContraseña.Text.Length > 0;

            if (exito)
            {
                if (AgregarUsuario(txtNombre.Text, txtApellido.Text,int.Parse(txtDni.Text), dropGenero.SelectedValue.ToString(),
                    int.Parse(Session["Fecha"].ToString()), txtEmail.Text, txtTelefono.Text, txtContraseña.Text, chkAdmin.Checked, true))
                {
                    errormsg.Visible = true;
                    btnOk.Visible = true;
                    btnResetear.Visible = false;
                    errormsg.Text = "Usuario agregado!";
                }
                else
                {
                    errormsg.Visible = true;
                    btnOk.Visible = true;
                    btnResetear.Visible = false;
                    errormsg.Text = "Correo ya registrado.";
                }
            }
            else
            {
                errormsg.Visible = true;
                btnOk.Visible = true;
                btnResetear.Visible = false;
                errormsg.Text = "Formulario incompleto";
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

        protected void btnResetear_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAgregarUsuario.aspx");
        }
    }
}