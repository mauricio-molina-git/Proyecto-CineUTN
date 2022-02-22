<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaTarjeta.aspx.cs" Inherits="PRESENTACION.PantallaTarjeta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

<link rel="stylesheet" href="CSS/Tarjetas.css"/>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
</head>

<body>
    <form action="#" class="credit-card-div" runat="server">

    <div class="usuarioConectado">
        <asp:ImageButton ID="btnUsuario" runat="server" Height="50px" Width="50px" style="margin-left:50px" ImageUrl="~/ImagenesBotones/usuario.png" OnClick="btnUsuario_Click" /><br />
        <asp:Label ID="lblusuario" runat="server" style="margin-left:30px" ForeColor="Black">Nombre y Apellido</asp:Label><br />
        <asp:DropDownList ID="ddpPerfil" CssClass="btn btn-info dropdown-toggle dropdown-toggle-split"  data-toggle="dropdown"  aria-haspopup="true" aria-expanded="false"  runat="server" AutoPostBack="True" Visible="False" OnSelectedIndexChanged="ddpPerfil_SelectedIndexChanged"></asp:DropDownList>
    </div>

    <div class="panel panel-default" >
 <div class="panel-heading">
     
      <div class="row ">
    <div class="col-md-12">
        <span class="help-block text-muted small-font" > Numero de tarjeta</span>
        <asp:TextBox ID="txtNumeroTarjeta" TextMode="Number" CssClass="form-control" placeholder="Numero de tarjeta sin espacios" runat="server"></asp:TextBox>
    </div>
    </div>
     <div class="row ">
        <div class="col-md-3 col-sm-3 col-xs-3">
        <span class="help-block text-muted small-font" > Mes de vencimiento</span>
        <asp:TextBox ID="txtMesVencimiento" Type="number" CssClass="form-control" placeholder="MM" runat="server"></asp:TextBox>
    </div>

    <div class="col-md-3 col-sm-3 col-xs-3">
        <span class="help-block text-muted small-font" >  Año de vencimiento</span>
        <asp:TextBox ID="txtAñoVencimiento" Type="number" CssClass="form-control" placeholder="YY" runat="server"></asp:TextBox>
    </div>
        <div class="col-md-3 col-sm-3 col-xs-3">
        <span class="help-block text-muted small-font" >  CCV</span>
        <asp:TextBox ID="txtCodigo" Type="number" CssClass="form-control" placeholder="CCV" runat="server"></asp:TextBox>
    </div>

    <div class="col-md-3 col-sm-3 col-xs-3">
        <asp:Image ID="imgTarjeta" Height="130px" Width="130px" CssClass="img-rounded" ImageUrl="~/ImagenesBotones/Tarjeta.png" runat="server" />
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
                </div>
              <div class="col-md-6 col-sm-6 col-xs-6 pad-adjust">
                  <asp:Button ID="btnPagar" CssClass="btn btn-warning btn-block"  runat="server" Text="Agregar tarjeta" OnClick="btnPagar_Click" />
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
