<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaPagar.aspx.cs" Inherits="PRESENTACION.PantallaPagar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<link rel="stylesheet" href="CSS/PagoTarjeta.css"/>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
</head>
<body>
    <form action="#" class="credit-card-div" runat="server">
    <div class="panel panel-default" >
 <div class="panel-heading">
     
      <div class="row ">
    <div class="col-md-12">
        <span class="help-block text-muted small-font" > Tarjetas ingresadas:</span>
        <asp:DropDownList ID="ddpTarjetas" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddpTarjetas_SelectedIndexChanged"></asp:DropDownList>
        <span class="help-block text-muted small-font" > Utilizar tarjeta nueva</span>
        <asp:Button ID="btnNuevaTarjeta" CssClass="form-control" runat="server" Text="Presione aqui para utilizar otra tarjeta" OnClick="btnNuevaTarjeta_Click" />
        <span class="help-block text-muted small-font" > Numero de tarjeta</span>
        <asp:TextBox ID="txtNumeroTarjeta" Type="number" CssClass="form-control" placeholder="Numero de tarjeta" runat="server"></asp:TextBox>
    </div>
    </div>
     <div class="row ">
        <div class="col-md-3 col-sm-3 col-xs-3">
        <span class="help-block text-muted small-font" > Mes de vencimiento</span>
        <asp:TextBox ID="txtMesVencimiento" Type="number" TextMode="Number" CssClass="form-control" placeholder="MM"  runat="server"></asp:TextBox>
    </div>

    <div class="col-md-3 col-sm-3 col-xs-3">
        <span class="help-block text-muted small-font" >  Año de vencimiento</span>
        <asp:TextBox ID="txtAñoVencimiento" Type="number" CssClass="form-control" placeholder="YY" runat="server"></asp:TextBox>
    </div>
        <div class="col-md-3 col-sm-3 col-xs-3">
        <span class="help-block text-muted small-font" >  CCV</span>
        <asp:TextBox ID="txtCodigo" Type="number" CssClass="form-control" placeholder="CCV"  runat="server"></asp:TextBox>
    </div>

    <div class="col-md-3 col-sm-3 col-xs-3">
        <asp:Image ID="imgTarjeta" Height="130px" Width="130px" Type="number" CssClass="img-rounded" ImageUrl="~/ImagenesBotones/Tarjeta.png" runat="server" />
    </div>
    </div>
     
    <div class="row ">
        <div class="col-md-12 pad-adjust">
        <span class="help-block text-muted small-font" >Nombre del titular como figura en la tarjeta</span>
        <asp:TextBox ID="txtNombreApellido" CssClass="form-control"  placeholder="Nombre del titular" runat="server"></asp:TextBox>
        <span class="help-block text-muted small-font" >DNI titular de la tarjeta</span>
        <asp:TextBox ID="txtDNI" CssClass="form-control" Type="number" placeholder="DNI titular" runat="server"></asp:TextBox>
        </div>
    </div>
     <div class="row">

<div class="col-md-12 pad-adjust">
    <div class="checkbox">

  </div>
</div>
     </div>
       <div class="row ">
            <div class="col-md-6 col-sm-6 col-xs-6 pad-adjust">
                <asp:Button ID="btnCancelar" CssClass="btn btn-danger"  runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
              <div class="col-md-6 col-sm-6 col-xs-6 pad-adjust">
                  <asp:Button ID="btnPagar" CssClass="btn btn-warning btn-block"  runat="server" Text="Pagar ahora" OnClick="btnPagar_Click" />
              </div>
          </div>
                   </div>
              </div>
       <div class="Alerta">
        <asp:Label ID="lblMensaje" CssClass="alert alert-primary" runat="server" Visible="False"></asp:Label>
        <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="Aceptar" Visible="False" OnClick="btnAceptar_Click" />
    </div>
    </form>
</body>
</html>
