<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaIniciarSesion.aspx.cs" Inherits="PRESENTACION.PantallaIniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

   <link rel="stylesheet" href="CSS/Login.css"/>
   <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>

</head>
<body>
    <form id="form1" runat="server">

        <div class ="logoCine">        
            <asp:ImageButton ID="btnLogoCine" runat="server" ImageUrl="~/ImagenesBotones/logo mauri.png" OnClick="btnLogoCine_Click1" style="width:125px; height:115px; padding-left:10px; padding-top:10px"/>            
        </div>

        <div class="FormularioLogin">
            <asp:Image ID="imgUserLogin" ImageUrl="~/ImagenesBotones/UserLogin.png" Height="100px" Width="100px" style="margin-left:90px;" runat="server" /><br /><br />
            <asp:Label ID="lblTitulo" runat="server" Text="Iniciar sesión" Style="margin-left:90px"></asp:Label><br />
            <asp:Label ID="lblEmail" runat="server" Text="Correo:"></asp:Label><br />
            <asp:TextBox ID="txtEmail" runat="server" placeholder="correo@ejemplo.com" CssClass="btn btn-light" Width="220px" BorderColor="#E8E1DF" ></asp:TextBox><br />
            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label><br />       
            <asp:TextBox ID="txtContraseña" runat="server" placeholder="Password" CssClass="btn btn-light" style="width:220px" BorderColor="#E8E1DF"  TextMode="Password"></asp:TextBox><br /><br />
            <asp:Button ID="btnIngresar" runat="server" CssClass="btn btn-info" style="width:180px; margin-left:50px; margin-top:-6px " Text="Ingresar"  OnClick="btnConectar_Click"/><br />
            <asp:Label ID="lblMensajeRegistrar" runat="server" Text="¿No tienes ninguna cuenta?"></asp:Label>          
            <asp:Button ID="btnRegistrar" runat="server" Text="Crear una." CssClass="btn btn-link" OnClick="btnRegistrar_Click"/>
        </div>  

        <div class="Alerta">
            <asp:Label ID="lblErrorConex" class="alert alert-danger" role="alert" runat="server" ForeColor="Black" Visible="False"></asp:Label>
            <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-danger" Visible="false" Text="Aceptar" OnClick="btnAceptar_Click" />
        </div>

        </form>
</body>
</html>
