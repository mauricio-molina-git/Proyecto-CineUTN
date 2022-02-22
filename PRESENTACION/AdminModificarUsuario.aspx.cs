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
    public partial class AdminModificarUsuario : System.Web.UI.Page
    {
        private string Nombre;
        private string Apellido;
        private int Dni;
        private string Genero;
        private int Nacimiento;
        private string Email;
        private string Telefono;
        private string Contraseña;
        private bool Admin;
        private bool Activo;
        private int a, m, d;
        private int fecha;
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

                foreach (Usuario u in NegocioCine.ObtenerUsuarios())
                {
                    dropUsuarios.Items.Add(u.Id + " " + u.Email);
                }
                string user = dropUsuarios.SelectedValue;
                user = int.Parse(user.Split(new char[] { ' ' })[0]).ToString();
                Usuario usuario = NegocioCine.ObtenerUsuariosMod(int.Parse(user));

                Nombre = txtNombre.Text = usuario.Nombre;
                Apellido = txtApellido.Text = usuario.Apellido;
                txtDni.Text = usuario.Dni.ToString();

                dropGenero.Items.Add(usuario.Genero);

                if(dropGenero.SelectedItem.Text == "Masculino")
                {
                    dropGenero.Items.Add("Femenino");
                }
                else
                {
                    dropGenero.Items.Add("Masculino");
                }

                Email = txtEmail.Text = usuario.Email;
                Telefono = txtTelefono.Text = usuario.Telefono;


                txtContraseña.Text = usuario.Password;
                chkAdmin.Checked = usuario.Admin;
                chkActivo.Checked = usuario.Activo;
                Nacimiento = usuario.Nacimiento;

                a = Nacimiento / 10000;
                m = (Nacimiento / 100) % 100;
                d = Nacimiento % 100;
                
                txtDia.Text = d.ToString();
                txtMes.Text = m.ToString();
                txtAño.Text = a.ToString();
            }
        }

        private void habilitarEdicion(bool habilitado)
        {
            txtNombre.Enabled = habilitado;
            txtApellido.Enabled = habilitado;
            txtDni.Enabled = habilitado;
            dropGenero.Enabled = habilitado;
            txtTelefono.Enabled = habilitado;
            txtContraseña.Enabled = habilitado;
            chkActivo.Enabled = habilitado;
            chkAdmin.Enabled = habilitado;
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
            Response.Redirect("AdminModificarUsuario.aspx");
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
                Nombre = txtNombre.Text;
                Apellido = txtApellido.Text;
                Genero = dropGenero.Items.ToString();
                Email = txtEmail.Text;
                Telefono = txtTelefono.Text;
                Contraseña = txtContraseña.Text;
                Admin = chkActivo.Checked;
                Activo = chkActivo.Checked;

                d = int.Parse(txtDia.Text);
                m = int.Parse(txtMes.Text);
                a = int.Parse(txtAño.Text);

                string user = dropUsuarios.SelectedValue;
                user = int.Parse(user.Split(new char[] { ' ' })[0]).ToString();

                if (Formato.fechaCorrecta(d, m, a))
                {
                    fecha = a * 10000 + m * 100 + d;
                    if (NegocioCine.ModificarUsuario(int.Parse(user), txtNombre.Text, txtApellido.Text,
                    int.Parse(txtDni.Text), dropGenero.SelectedValue.ToString(), fecha, txtEmail.Text, txtTelefono.Text,
                    txtContraseña.Text, chkAdmin.Checked, chkActivo.Checked))
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "Usuario modificado!";
                        btnOk.Visible = true;
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

        protected void dropUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropGenero.Items.Clear();

            string user = dropUsuarios.SelectedValue;
            user = int.Parse(user.Split(new char[] { ' ' })[0]).ToString();
            Usuario usuario = NegocioCine.ObtenerUsuariosMod(int.Parse(user));

            Nombre = txtNombre.Text = usuario.Nombre;
            Apellido = txtApellido.Text = usuario.Apellido;
            txtDni.Text = usuario.Dni.ToString();

            Nacimiento = usuario.Nacimiento;

            a = Nacimiento / 10000;
            m = (Nacimiento / 100) % 100;
            d = Nacimiento % 100;

            txtDia.Text = d.ToString();
            txtMes.Text = m.ToString();
            txtAño.Text = a.ToString();

            dropGenero.Items.Add(usuario.Genero);

            if (dropGenero.SelectedItem.Text == "Masculino Actual")
            {
                dropGenero.Items.Add("Femenino");
            }
            else
            {
                dropGenero.Items.Add("Masculino");
            }

            Email = txtEmail.Text = usuario.Email;
            Telefono = txtTelefono.Text = usuario.Telefono;

            txtContraseña.Text = usuario.Password;
            chkAdmin.Checked = usuario.Admin;
            chkActivo.Checked = usuario.Activo;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminModificarUsuario.aspx");
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
    }
}