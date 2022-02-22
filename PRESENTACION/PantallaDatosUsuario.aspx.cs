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

namespace PRESENTACION
{
    public partial class PantallaDatosUsuario : System.Web.UI.Page
    {
        private string Nombre;
        private string Apellido;
        private int Dni;
        private string Telefono;
        private string Email;
        int Nacimiento;
        int d;
        int m; 
        int a;
        int fecha;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Session["Email"] != null)
                {
                    Usuario usuario = NegocioCine.ObtenerUsuario(Session["Email"].ToString());

                    if (usuario != null)
                    {
                        lblusuario.Text = usuario.Nombre + " " + usuario.Apellido;

                        ddpPerfil.Items.Add("Seleccione opción");
                        ddpPerfil.Items.Add("Compras realizadas");
                        ddpPerfil.Items.Add("Agregar Tarjetas");
                        ddpPerfil.Items.Add("Cerrar Sesión");

                        Session["idUsuario"] = usuario.Id;
                        Nombre = txtNombre.Text = usuario.Nombre;
                        Apellido = txtApellido.Text = usuario.Apellido;
                        txtDni.Text = usuario.Dni.ToString();
                        Dni = usuario.Dni;
                        Telefono = txtTelefono.Text = usuario.Telefono;
                        Email = txtEmail.Text = usuario.Email;
                        Nacimiento = usuario.Nacimiento;

                        a = Nacimiento / 10000;
                        m = (Nacimiento / 100) % 100;
                        d = Nacimiento % 100;

                        txtDia.Text = d.ToString();
                        txtMes.Text = m.ToString();
                        txtAño.Text = a.ToString();
                    }
                }
            }
        }

        protected void btnLogoCine_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx?");
        }

        protected void btnLinkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("PantallaPrincipal.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Text == "Editar")
            {
                habilitarEdicion(true);
            }
            else
            {
                Nombre = txtNombre.Text;
                Apellido = txtApellido.Text;
                Telefono = txtTelefono.Text;
                Dni = int.Parse(txtDni.Text);
                Email = txtEmail.Text;

                d = int.Parse(txtDia.Text);
                m = int.Parse(txtMes.Text);
                a = int.Parse(txtAño.Text);

                if (Formato.fechaCorrecta(d, m, a))
                {
                    fecha = a * 10000 + m * 100 + d;

                    if (NegocioCine.ModificarDatosUser(
                        txtNombre.Text,
                        txtApellido.Text,
                        int.Parse(txtDni.Text),
                        txtTelefono.Text,
                        fecha,
                        txtEmail.Text))
                    {
                        lblMensaje.Text = "Datos modificados.";
                        lblMensaje.Visible = true;
                        btnOk.Visible = true;
                        btnEditar.Visible = false;
                    }
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Fecha incorrecta.";
                    btnOk.Visible = true;
                    btnEditar.Visible = false;
                }

                habilitarEdicion(false);
            }
        }

        private void habilitarEdicion(bool habilitado)
        {
            txtNombre.Enabled = habilitado;
            txtApellido.Enabled = habilitado;
            txtTelefono.Enabled = habilitado;
            txtDni.Enabled = habilitado;
            txtDia.Enabled = habilitado;
            txtMes.Enabled = habilitado;
            txtAño.Enabled = habilitado;

            btnCancelar.Visible = habilitado;

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
            Response.Redirect("PantallaDatosUsuario.aspx");

            habilitarEdicion(false);
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            btnOk.Visible = false;
            btnEditar.Visible = true;
            lblMensaje.Visible = false;

            Usuario usuario = NegocioCine.ObtenerUsuario(Session["Email"].ToString());
            Nombre = txtNombre.Text = usuario.Nombre;
            Apellido = txtApellido.Text = usuario.Apellido;
            txtDni.Text = usuario.Dni.ToString();
            Dni = usuario.Dni;
            Telefono = txtTelefono.Text = usuario.Telefono;
            Email = txtEmail.Text = usuario.Email;
            Nacimiento = usuario.Nacimiento;
            lblusuario.Text = usuario.Nombre + " " + usuario.Apellido;
            a = Nacimiento / 10000;
            m = (Nacimiento / 100) % 100;
            d = Nacimiento % 100;

            txtDia.Text = d.ToString();
            txtMes.Text = m.ToString();
            txtAño.Text = a.ToString();
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx?");
        }

        protected void ddpPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddpPerfil.SelectedIndex == 1)
            {
                Response.Redirect("ConsultaReservas.aspx");
            }

            if (ddpPerfil.SelectedIndex == 2)
            {
                Response.Redirect("PantallaTarjeta.aspx");
            }
            if (ddpPerfil.SelectedIndex == 3)
            {
                Session["Email"] = null;
                Response.Redirect("PantallaPrincipal.aspx");
            }
        }

        protected void btnLogoCine_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx");
        }
    }
}