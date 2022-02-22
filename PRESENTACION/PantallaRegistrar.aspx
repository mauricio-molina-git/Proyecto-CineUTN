<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaRegistrar.aspx.cs" Inherits="PRESENTACION.PantallaRegistrar2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
      <link rel="stylesheet" href="CSS/Registrar.css">

</head>
<body>
    <form id="form1" runat="server">

      <div class="logoCine">   
            <asp:ImageButton ID="btnLogoCine" runat="server" ImageUrl="~/ImagenesBotones/logo mauri.png" style="width:125px; height:115px; padding-left:10px; padding-top:10px" OnClick="btnLogoCine_Click"/>  
      </div>

     <div class="FotoForm">
         <asp:Image ID="imgRegistrar" ImageUrl="~/ImagenesBotones/RegistroFoto.jpg" Height="580px" Width="400px" runat="server" />
     </div>

        <div class="FormularioRegistrar">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label><br />
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre"  CssClass="btn btn-light" BorderColor="#E8E1DF"></asp:TextBox><br />
            <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label><br />
            <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido" CssClass="btn btn-light" BorderColor="#E8E1DF"></asp:TextBox><br />
             <asp:Label ID="lblDni" runat="server" Text="DNI:"></asp:Label><br />
            <asp:TextBox ID="txtDNI" runat="server" placeholder="Numero de documento" TextMode="Number" CssClass="btn btn-light" BorderColor="#E8E1DF"></asp:TextBox><br />           
            <asp:Label ID="lblEmail" runat="server" Text="Correo electrónico:"></asp:Label><br />
            <asp:TextBox ID="txtEmail" runat="server" placeholder="correo@ejemplo.com" CssClass="btn btn-light" BorderColor="#E8E1DF"></asp:TextBox><br />

            <asp:Label ID="lblGenero" runat="server" Text="Género:"></asp:Label><br />
            <asp:DropDownList ID="dropGenero" runat="server" Width="200px" CssClass="btn btn-light" BorderColor="#E8E1DF"></asp:DropDownList><br />
            <asp:Label ID="lblNacimiento" runat="server" Text="Fecha de nacimiento:"></asp:Label><br />
            <asp:Button ID="btnCalendario" CssClass="btn btn-light" BorderColor="#E8E1DF" Width="200px" runat="server" Text="Ver calendario" OnClick="btnCalendario_Click" /><br />
            <asp:Label ID="lblTelefono" runat="server" Text="Telefono:"></asp:Label><br />
            <asp:TextBox ID="txtTelefono" runat="server" placeholder="+54-11xxxxxxxx" CssClass="btn btn-light" BorderColor="#E8E1DF"></asp:TextBox><br />
            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label><br />
            <asp:TextBox ID="txtContraseña" runat="server" placeholder="Password" CssClass="btn btn-light" BorderColor="#E8E1DF" TextMode="Password"></asp:TextBox><br /> <br />         
            <asp:Button ID="btnConfirmar" runat="server" Text="Registrar" CssClass="btn btn-info" OnClick="btnConfirmar_Click"/>
            <asp:Button ID="btnLogin" runat="server" Text="Ya tengo una cuenta" CssClass="btn btn-link" OnClick="btnLogin_Click"/><br /><br />

            <br />
        </div>

        <div class="Calendario">
            <asp:Calendar ID="calNacimiento" CssClass="btn btn-info" runat="server" OnSelectionChanged="calNacimiento_SelectionChanged" Visible="False" DayNameFormat="Shortest"></asp:Calendar>
        </div>

        <div class="Alerta">
            <asp:Label ID="errormsg" CssClass="alert alert-danger" runat="server" Visible="False"></asp:Label>
            <asp:Button ID="btnAceptar" runat="server"  Text="Aceptar" CssClass="btn btn-primary" Visible="False" OnClick="btnOk_Click"/>
        </div>
    </form>
</body>
</html>
