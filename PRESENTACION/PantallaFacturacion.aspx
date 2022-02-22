<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaFacturacion.aspx.cs" Inherits="PRESENTACION.PantallaFacturacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
 <link rel="stylesheet" href="CSS/Facturacion.css">
<body>
    <form id="form1" runat="server">

        <div class ="BotonesPrincipales">
            <asp:ImageButton ID="btnBack" ImageUrl="~/ImagenesBotones/atrasLogin.png" style="width:90px; height:90px; padding-left:10px; padding-top:10px" runat="server" OnClick="btnBack_Click"  />
            <asp:ImageButton ID="btnLogoCine" runat="server" ImageUrl="~/ImagenesBotones/logo mauri.png"  style="width:115px; height:105px; padding-left:10px; padding-top:10px" OnClick="btnLogoCine_Click" />   
        </div>

        <div class="ResumenCompra">
            <asp:Label ID="lblResumen" runat="server" CssClass="display-4" Font-Size="25px" Text="Resumen de compra:"></asp:Label><br /><br />
            <asp:Label ID="lblUsuario" runat="server" Text="Nombre usuario:"></asp:Label>
            <asp:Label ID="lblMostrarUsuario" runat="server" Font-Bold="true"></asp:Label><br /><br />           
            <asp:Label ID="lblFuncion" runat="server" Text="Función:"></asp:Label>
            <asp:Label ID="lblMostrarFuncion" runat="server" Font-Bold="true"></asp:Label><br /><br />
            <asp:Label ID="lblFormato" runat="server" Text="Formato:"></asp:Label>
            <asp:Label ID="lblMostrarFormato" runat="server" Font-Bold="true"></asp:Label><br /><br />
            <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
            <asp:Label ID="lblMostrarFecha" runat="server" Font-Bold="true"></asp:Label><br /><br />
            <asp:Label ID="lblSucursal" runat="server" Text="Sucursal:"></asp:Label>
            <asp:Label ID="lblMostrarSucursal" runat="server" Font-Bold="true"></asp:Label><br /><br />
            <asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label>
            <asp:Label ID="lblMostrarDireccion" runat="server" Font-Bold="true"></asp:Label><br /><br />           
            <asp:Label ID="lblButacas" runat="server" Text="Butacas: "></asp:Label>
            <asp:Label ID="lblMostrarButacas" runat="server" Font-Bold="true"></asp:Label><br /><br />

            <asp:Label ID="lblEntradas" runat="server" Text="Entradas:"></asp:Label>
            <asp:Label ID="lblMostrarEntradas" runat="server" Font-Bold="True" Text="X"></asp:Label><br /><br />
            <asp:Label ID="lblTotal" runat="server" Text="Total a pagar:"></asp:Label>
            <asp:Label ID="lblMostrarTotal" runat="server" Font-Bold="True" Text="$"></asp:Label><br /><br />
            <asp:Button ID="btnPagar" runat="server" CssClass="btn btn-primary" Text="Proceder al pago" OnClick="btnPagar_Click" />
        </div>
    </form>
</body>
</html>
