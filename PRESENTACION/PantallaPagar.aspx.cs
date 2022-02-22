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
    public partial class PantallaPagar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNumeroTarjeta.Enabled = false;
                txtNombreApellido.Enabled = false;
                txtMesVencimiento.Enabled = false;
                txtAñoVencimiento.Enabled = false;
                txtDNI.Enabled = false;

                NegocioCine.Conectar();

                foreach (Tarjeta t in NegocioCine.ObtenerTarjeta(int.Parse(Session["ID"].ToString())))
                {
                    ddpTarjetas.Items.Add("Numero de tarjeta:" + " " + t.NumTarjeta + " - "+ "Titular: " + t.NombreTitular);
                }

                string numTarjeta = ddpTarjetas.SelectedValue;
                if(numTarjeta != "")
                {
                    numTarjeta = long.Parse(numTarjeta.Split(new char[] { ' ' })[3]).ToString();

                    Tarjeta tarjeta = NegocioCine.ObtenerTarjetaMostrar(int.Parse(Session["ID"].ToString()), long.Parse(numTarjeta));

                    txtNumeroTarjeta.Text = tarjeta.NumTarjeta.ToString();
                    txtMesVencimiento.Text = tarjeta.MesVencimiento.ToString();
                    txtAñoVencimiento.Text = tarjeta.AnioVencimiento.ToString();
                    txtDNI.Text = tarjeta.DniTitular.ToString();
                    txtNombreApellido.Text = tarjeta.NombreTitular.ToString();
                }
                else
                {
                    ddpTarjetas.Enabled = false;
                }

            }
        }

        protected void ddpTarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumeroTarjeta.Enabled = false;
            txtNombreApellido.Enabled = false;
            txtMesVencimiento.Enabled = false;
            txtAñoVencimiento.Enabled = false;
            txtDNI.Enabled = false;

            string numTarjeta = ddpTarjetas.SelectedValue;
            numTarjeta = long.Parse(numTarjeta.Split(new char[] { ' ' })[3]).ToString();

            Tarjeta tarjeta = NegocioCine.ObtenerTarjetaMostrar(int.Parse(Session["ID"].ToString()), long.Parse(numTarjeta));

            txtNumeroTarjeta.Text = tarjeta.NumTarjeta.ToString();
            txtMesVencimiento.Text = tarjeta.MesVencimiento.ToString();
            txtAñoVencimiento.Text = tarjeta.AnioVencimiento.ToString();
            txtDNI.Text = tarjeta.DniTitular.ToString();
            txtNombreApellido.Text = tarjeta.NombreTitular.ToString();
        }

        protected void btnNuevaTarjeta_Click(object sender, EventArgs e)
        {
            txtNumeroTarjeta.Text = string.Empty;
            txtNombreApellido.Text = string.Empty;
            txtMesVencimiento.Text = string.Empty;
            txtAñoVencimiento.Text = string.Empty;
            txtDNI.Text = string.Empty;

            txtNumeroTarjeta.Enabled = true;
            txtNombreApellido.Enabled = true;
            txtMesVencimiento.Enabled = true;
            txtAñoVencimiento.Enabled = true;
            txtDNI.Enabled = true;
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            bool exito;

            DateTime hoy = DateTime.Now;
            int a = hoy.Year;
            int m = hoy.Month;
            int a1 = 0;
            int m1 = 0;

            if(txtAñoVencimiento.Text != string.Empty && txtMesVencimiento.Text != string.Empty)
            {
                a1 = int.Parse(txtAñoVencimiento.Text);
                m1 = int.Parse(txtMesVencimiento.Text);
            }

            exito = a1 > a || (a1 == a && m1 > m);

            exito = exito && txtNombreApellido.Text.Length > 0;
            exito = exito && txtDNI.Text.Length > 0;
            exito = exito && txtCodigo.Text.Length == 3;
            exito = exito && txtNumeroTarjeta.Text.Length == 16;

            if (exito)
            {
                int idFuncion = int.Parse(Session["FuncionReservada"].ToString());
                int idUsuario = int.Parse(Session["ID"].ToString());
                int idReserva = NegocioCine.AgregarReserva(idUsuario, idFuncion);
                string reservas = Session["ButacasReservadas"].ToString();
                string[] butacas = reservas.Split(new char[] { ' ' });
                foreach (string s in butacas)
                {
                    int v = int.Parse(s);
                    int fila = (v - 1) / 10 + 1;
                    int butaca = (v - 1) % 10 + 1;
                    NegocioCine.AgregarReservada(idReserva, fila, butaca);
                }
                Session["FuncionReservada"] = null;
                Session["ButacasReservadas"] = null;
                lblMensaje.Visible = true;
                btnAceptar.Visible = true;
                lblMensaje.Text = "Compra realizada correctamente";
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Revise los datos ingresados.";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaReservas.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PantallaPrincipal.aspx");
        }
    }
}
